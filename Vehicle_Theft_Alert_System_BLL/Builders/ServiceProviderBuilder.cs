using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Mapping;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_BLL.Services;
using Vehicle_Theft_Alert_System_DAL;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;
using Vehicle_Theft_Alert_System_DAL.Repositories;

namespace Vehicle_Theft_Alert_System_BLL.Builders
{
    public static class ServiceProviderBuilder
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<IActivityScheduleRepository, ActivityScheduleRepository>();
            serviceCollection.AddScoped<IConnectionRepository, ConnectionRepository>();
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<IFamilyPlanRepository, FamilyPlanRepository>();
            serviceCollection.AddScoped<IFamilyRepository, FamilyRepository>();
            serviceCollection.AddScoped<ITrackerRepository, TrackerRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            serviceCollection.AddDbContext<PostgresContext>(options =>
            {
                options.UseNpgsql("Server=localhost;Database=AlertSystem;Port=5432;User Id=postgres;Password=postgres").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            serviceCollection.AddIdentity<AccountDB, AlertSystemRole>()
                .AddEntityFrameworkStores<PostgresContext>();
            //serviceCollection.AddDefaultIdentity<AccountDB>().AddRoles<IdentityRole>()

            return serviceCollection;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<IActivityScheduleService, ActivityScheduleService>();
            serviceCollection.AddScoped<IConnectionService, ConnectionService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<IFamilyPlanService, FamilyPlanService>();
            serviceCollection.AddScoped<IFamilyService, FamilyService>();
            serviceCollection.AddScoped<ITrackerService, TrackerService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<JwtHandler>();
            serviceCollection.AddScoped<IAuthService, AuthService>();

            return serviceCollection;
        }
        public static async Task createRolesandUsers(this IApplicationBuilder app, RoleManager<AlertSystemRole> roleManager,
            UserManager<AccountDB> userManager, IUserRepository userRepository, ICountryRepository countryRepository)
        {
            IdentityResult roleResult;

            var roleExist = await roleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new AlertSystemRole() { Name = "Admin" });
            }
            var adminCountry = new CountryDB()
            {
                ContinentName = "Ukraine",
                Name = "Ukraine"
            }; 

            var adminProfile = new UserDB()
            {
                PhoneNumber = "admin_phone",
                BirthDate = DateTime.Now,
                FullName = "Admin",
                Gender = "Admin"
            };

            var admin = new AccountDB()
            {
                Email = "Admin@123",
                UserName = "Admin@123",
                BillAmount = 0
            };

            var _admin = await userManager.FindByEmailAsync(admin.Email);
            if (_admin == null)
            {
                var _adminCountry = countryRepository.AddEntity(adminCountry);
                adminProfile.CountryDBId = _adminCountry.Id;

                var _adminProfile = userRepository.AddEntity(adminProfile);
                admin.UserDBId = _adminProfile.Id;

                var createPowerUser = await userManager.CreateAsync(admin, "Admin@123");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");

                }
            }

        }
    }
}
