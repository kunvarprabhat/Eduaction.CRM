
using Eduaction.BusinessLogic.Abstract;
using Eduaction.BusinessLogic.Concrete;
using Eduaction.DataModel;

namespace Eduaction.On.Web.Extension
{
    public static class ProgrameExtension
    {
        public static void DependencyResolver(this IServiceCollection services, ConfigurationManager configuration)
        {
            AppSettingProvider(configuration);
            services.AddScoped<ICallTrackerRepository, CallTrackerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
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
