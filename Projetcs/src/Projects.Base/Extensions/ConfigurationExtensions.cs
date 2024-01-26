using Microsoft.Extensions.Configuration;
using Projects.Base.Models;

namespace Projects.Base.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDBConnectionString(this IConfiguration configuration)
        {
            DatabaseSettings dbConfiguration = new DatabaseSettings();

            configuration.GetSection(DatabaseSettings.SettingKeyName).Bind(dbConfiguration);

            return dbConfiguration.GetConnectionString();
        }
    }
}
