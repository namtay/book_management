using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using RiverBooks.Users.UseCases;
using RiverBooks.Users.Data;

namespace RiverBooks.Users
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddUserModuleServices(
            this IServiceCollection services, 
            ConfigurationManager config, 
            Serilog.ILogger logger, 
            List<System.Reflection.Assembly> mediatRAssemblies)

        {

            string? connectionString = config.GetConnectionString("UsersConnectionString");
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<UsersDbContext>();

            services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();

            //if using mediatR in this module, add any assemblies that contain handlers to the extensions.
            mediatRAssemblies.Add(typeof(UsersModuleExtensions).Assembly);

            logger.Information("{Module} module services registered", "Users");

            return services;
        }
    }

 
}
