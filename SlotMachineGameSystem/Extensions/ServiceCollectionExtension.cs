using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlotMachineGameSystem.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        // Extension methods
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        //Export the code from Program.cs for better readability.
        //Бuilder.Services it's come form IServiceCollection
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ??
                                   throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
