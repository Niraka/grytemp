using Gryphon.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Net.Core.Configuration
{
    class AppSettingsConfigurationProvider : IConfigurationProvider
    {
        public ConfigurationItemDetailsSet GetConfigurationItems()
        {
            ConfigurationItemDetailsSet itemSet;
            itemSet.Longs = new List<ConfigurationItemDetails<long>>();
            itemSet.Doubles = new List<ConfigurationItemDetails<double>>();
            itemSet.Strings = new List<ConfigurationItemDetails<string>>();
            itemSet.Bools = new List<ConfigurationItemDetails<bool>>();

            System.Configuration.Configuration c = null;
            System.Configuration.ConfigurationSectionGroup group = c.GetSectionGroup("");
            foreach (System.Configuration.ConfigurationSection section in group.Sections)
            {
                //????????
            }

            return itemSet;
        }

        public ConfigurationSourceDetails GetConfigurationSourceDetails()
        {
            return new ConfigurationSourceDetails(
                "net-core-app-settings",
                ".Net Core Application Settings",
                "Configuration provided by the 'appsettings.json' file in a .Net core application");
        }
    }
}
