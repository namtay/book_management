using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverBooks.Users.UserEndpoints
{

    public record CreateUserRequest(string Email, string Password);
    internal class Create: Endpoint <CreateUserRequest>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        public Create (UserManager<ApplicationUser > userManager, ILogger logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email

            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            //await SendOkAsync(newUser);

            // Check result
            if (!result.Succeeded)
            {
                _logger.Error("User creation failed: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                await SendErrorsAsync();
                
                return;
            }

            // Log the password hash after successful creation
            _logger.Information("User created successfully with Email: {Email}, PasswordHash: {PasswordHash}", request.Email, newUser.PasswordHash);

            // Send response with the new user details (excluding password)
            await SendOkAsync(new { newUser.Id, newUser.Email, newUser.PasswordHash });
        }
    }
}
