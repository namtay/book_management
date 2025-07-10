using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IdentityModel.Tokens.Jwt;

namespace RiverBooks.Users.UserEndpoints
{
    internal class Login : Endpoint<UserLoginRequest>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        public Login(UserManager<ApplicationUser> userManager, ILogger logger, IConfiguration config)
        {
            _userManager = userManager;
            _logger = logger;
            _config = config;
        }

        public override void Configure()
        {
            Post("/users/Login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserLoginRequest request, CancellationToken cancellationToken)
        {
              
              var user = await _userManager.FindByEmailAsync(request.Email!);
                if (user == null) {
                _logger.Information("User with {Email} not found.", request);
                await SendUnauthorizedAsync();
                return;
            }
            var loginSuccessful = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!loginSuccessful)
            {
                _logger.Information("{Email} found but login unsuccessful", request);
                await  SendUnauthorizedAsync();
                return;
            }

            var jwtSecret = _config["Auth:JwtSecret"];

            if (string.IsNullOrWhiteSpace(jwtSecret))
            {
                throw new Exception("JwtSecret is missing from configuration!");
            }

            var token = JwtBearer.CreateToken(options =>
            {
                options.SigningKey = jwtSecret;              
                options.User.Claims.Add(("EmailAddress", user.Email!));
                //options.User.Claims.Add(("UserId", user.Id));
            });

            await SendAsync(token);
        }
    }
}
