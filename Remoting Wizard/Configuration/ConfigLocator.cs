using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.Configuration
{
    internal static class ConfigLocator
    {
        public static void Load(string filePath)
        {
            FileInfo file = new FileInfo( filePath);

            if (!file.Directory.Exists) file.Directory.Create();

            if (!file.Exists) file.Create().Flush();

            // open config
            string path = file.FullName;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload in memory of the changed section.
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

            AddOrUpdateAppSettings("test", "Test");
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

    }
}
