using Gryphon.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Net.Core.Configuration
{
    public class CommandLineConfigurationProvider : IConfigurationProvider
    {
        private readonly string[] m_args;

        public CommandLineConfigurationProvider(string[] args)
        {
            m_args = args ?? new string[0];
        }

        public ConfigurationItemDetailsSet GetConfigurationItems()
        {
            ConfigurationItemDetailsSet itemSet;
            itemSet.Longs = new List<ConfigurationItemDetails<long>>();
            itemSet.Doubles = new List<ConfigurationItemDetails<double>>();
            itemSet.Strings = new List<ConfigurationItemDetails<string>>();
            itemSet.Bools = new List<ConfigurationItemDetails<bool>>();

            foreach (string sArg in m_args)
            {
                if (sArg == null || sArg.Length == 0)
                {
                    continue;
                }

                string[] strings = sArg.Split('=');
                if (strings.Length == 1)
                {
                    itemSet.Strings.Add(new ConfigurationItemDetails<string>(
                        strings[0],
                        strings[0],
                        string.Empty,
                        strings[0],
                        false));
                }
                else if (strings.Length == 2)
                {
                    itemSet.Strings.Add(new ConfigurationItemDetails<string>(
                        strings[0],
                        strings[0],
                        string.Empty,
                        strings[1],
                        false));
                }
                else
                {
                    itemSet.Strings.Add(new ConfigurationItemDetails<string>(
                        strings[0],
                        strings[0],
                        string.Empty,
                        sArg.Substring(sArg.IndexOf("=") + 1),
                        false));
                }
            }
            return itemSet;
        }

        public ConfigurationSourceDetails GetConfigurationSourceDetails()
        {
            return new ConfigurationSourceDetails(
                "net-core-command-line",
                ".Net Core command line",
                "Configuration provided by command line parameters passed to a .Net core application");
        }
    }
}
