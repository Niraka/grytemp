using Gryphon.Framework.Configuration;
using System.Collections.Generic;
using System.Reflection;
using Gryphon.Modules.Locale;

namespace Gryphon.Framework
{
    public class EngineConfigurationProvider : IConfigurationProvider
    {
        private const string m_sSourceName = "gryphon";
        private const string m_sSourceDisplayName = "Gryphon";
        private const string m_sSourceDescription = "Gryphon internal configuration provider";

        public EngineConfigurationProvider()
        {
        }
        
        public ConfigurationItemDetailsSet GetConfigurationItems()
        {
            ConfigurationItemDetailsSet itemDetailsSet;
            itemDetailsSet.Longs = new List<ConfigurationItemDetails<long>>();
            itemDetailsSet.Doubles = new List<ConfigurationItemDetails<double>>();
            itemDetailsSet.Strings = new List<ConfigurationItemDetails<string>>();
            itemDetailsSet.Bools = new List<ConfigurationItemDetails<bool>>();

            itemDetailsSet.Strings.Add(new ConfigurationItemDetails<string>(
                "engine-name", 
                "Engine name", 
                "The name of the engine", 
                "gryphon", 
                false));
            itemDetailsSet.Longs.Add(new ConfigurationItemDetails<long>(
                "engine-version-major", 
                "Engine version - Major", 
                "The major version number of the engine", 
                Assembly.GetExecutingAssembly().GetName().Version.Major, 
                false));
            itemDetailsSet.Longs.Add(new ConfigurationItemDetails<long>(
                "engine-version-minor", 
                "Engine version - Minor", 
                "The minor version number of the engine", 
                Assembly.GetExecutingAssembly().GetName().Version.Minor, 
                false));
            itemDetailsSet.Longs.Add(new ConfigurationItemDetails<long>(
                "engine-version-revision", 
                "Engine version - Revision", 
                "The revision version number of the engine", 
                Assembly.GetExecutingAssembly().GetName().Version.Revision, 
                false));
            itemDetailsSet.Longs.Add(new ConfigurationItemDetails<long>(
                "engine-version-build", 
                "Engine version - Build", 
                "The build version number of the engine", 
                Assembly.GetExecutingAssembly().GetName().Version.Build, 
                false));

            return itemDetailsSet;
        }

        public ConfigurationSourceDetails GetConfigurationSourceDetails()
        {
            return new ConfigurationSourceDetails(
                m_sSourceName,
                m_sSourceName,
                m_sSourceDescription);
        }
    }
}
