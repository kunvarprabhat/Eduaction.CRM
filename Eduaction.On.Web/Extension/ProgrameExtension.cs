using Eduaction.BusinessLogic.Abstract;
using Eduaction.BusinessLogic.Concrete;
using Eduaction.DataModel;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 
namespace Eduaction.On.Web.Extension
{
    public static class ProgrameExtension
    {
        public static void DependencyResolver(this IServiceCollection services, ConfigurationManager configuration)
        {
            AppSettingProvider(configuration);

            // ✅ Register the EducationDbContext
            services.AddDbContext<EducationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            // ⬇️ Your existing repository registrations
            services.AddScoped<ICallTrackerRepository, CallTrackerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILoginInfoRepository, LoginInfoRepository>();
            services.AddSession();
        }

        public static void AppSettingProvider(ConfigurationManager configuration)
        {
            var appSetting = configuration.GetSection("AppSettings");
            ConfigSetting.AdminEmail = appSetting["AdminEmail"];
            ConfigSetting.LogPath = appSetting["LogPath"];
            ConfigSetting.MediaPath = appSetting["MediaPath"];
            ConfigSetting.MediaBaseUrl = appSetting["MediaBaseUrl"];
            ConfigSetting.SqlConnection = configuration.GetConnectionString("DBConnection");
        }
    }
}
