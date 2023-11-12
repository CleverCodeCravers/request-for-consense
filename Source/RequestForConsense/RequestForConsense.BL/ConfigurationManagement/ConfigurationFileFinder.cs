namespace RequestForConsense.BL.ConfigurationManagement
{
    public static class ConfigurationFileFinder
    {
        private const string JsonFileName = "config.json";

        public static string FindConfigurationFile(string baseDirectory)
        {
            string currentDirectory = baseDirectory;

            while (!string.IsNullOrEmpty(currentDirectory))
            {
                string jsonFilePath = Path.Combine(currentDirectory, JsonFileName);

                if (File.Exists(jsonFilePath))
                {
                    return jsonFilePath;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            return string.Empty;
        }
    }
}
