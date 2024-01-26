
using Projects.Base.Extensions;

namespace Projects.Base.Models
{
    public class DatabaseSettings
    {
        public const string SettingKeyName = nameof(DatabaseSettings);
        public string? ServerName { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public bool IntegratedSecurity { get; set; }
        public Dictionary<string, object>? ExtendedProperties { get; set; }

        public string GetConnectionString()
        {
            if (string.IsNullOrWhiteSpace(this.ServerName) || string.IsNullOrWhiteSpace(this.DatabaseName))
                throw new ArgumentNullException("Não foi configurado os dados da conexão.");

            string connectionString = "";

            connectionString = "Data Source=" + ServerName;
            connectionString += ";Initial Catalog=" + DatabaseName;
            if (IntegratedSecurity)
                connectionString += ";Integrated Security=True";
            else
            {
                connectionString += ";User Id =" + UserID;
                connectionString += ";Password =" + Password?.Decrypt();
            }

            if (ExtendedProperties?.Count > 0)
            {
                if (connectionString.EndsWith(";") == false) connectionString += ";";
                connectionString += string.Join(";", ExtendedProperties.Select(key => $"{key.Key}={key.Value}"));
            }

            return connectionString;
        }
    }
}
