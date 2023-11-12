using System.Text.Json;

namespace RequestForConsense.BL.ConfigurationManagement
{
    using System.IO;


    public class ConfigurationManager
    {
        private readonly string jsonFilePath;

        public ConfigurationManager(string jsonFilePath)
        {
            this.jsonFilePath = jsonFilePath;
        }

        public string GetConnectionString()
        {
            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize JSON content into a custom object
            var connectionData = JsonSerializer.Deserialize<ConnectionData>(jsonContent);

            // Build the connection string
            string connectionString = $"Server={connectionData.MySqlServer};database={connectionData.MySqlDatabase};User Id={connectionData.MySqlUser};Password={connectionData.MySqlPassword};";

            return connectionString;
        }
    }
}
