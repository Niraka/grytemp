using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationManager
    {
        private readonly IConfigurationEncryptor m_configurationEncryptor;
        private readonly IConfigurationItemValidator m_configurationItemValidator;
        private readonly IConfigurationSourceDetailsValidator m_configurationSourceDetailsValidator;
        private readonly ConcurrentBag<IConfigurationProvider> m_configurationProviders;
        private readonly Semaphore m_configurationLoadLock;
        private int m_iNextSourceId;
        private int m_iNextItemId;

        private readonly ConcurrentBag<int> m_configurationSourceIds;
        private readonly ConcurrentDictionary<int, ConfigurationSource> m_configurationSourcesBySourceId;
        private readonly ConcurrentDictionary<int, Configuration> m_configurationsBySourceId;
        private readonly ConcurrentDictionary<string, ConcurrentBag<int>> m_configurationSourceIdsByName;

        private readonly ConcurrentBag<int> m_configurationItemsIds;
        private readonly ConcurrentDictionary<int, int> m_configurationItemIdsBySourceId;
        private readonly ConcurrentDictionary<string, ConcurrentBag<int>> m_configurationItemIdsByName;

        public ConfigurationManager(ConfigurationManagerConfig config)
        {
            m_iNextSourceId = 0;
            m_iNextItemId = 0;
            m_configurationProviders = new ConcurrentBag<IConfigurationProvider>();
            m_configurationLoadLock = new Semaphore(1, 1);

            m_configurationEncryptor = config.GetConfigurationEncryptor();
            m_configurationItemValidator = config.GetConfigurationItemValidator();
            m_configurationSourceDetailsValidator = config.GetConfigurationSourceDetailsValidator();

            m_configurationSourceIds = new ConcurrentBag<int>();
            m_configurationSourcesBySourceId = new ConcurrentDictionary<int, ConfigurationSource>();
            m_configurationsBySourceId = new ConcurrentDictionary<int, Configuration>();
            m_configurationSourceIdsByName = new ConcurrentDictionary<string, ConcurrentBag<int>>();

            m_configurationItemsIds = new ConcurrentBag<int>();
            m_configurationItemIdsBySourceId = new ConcurrentDictionary<int, int>();
            m_configurationItemIdsByName = new ConcurrentDictionary<string, ConcurrentBag<int>>();
        }

        public void AddConfigurationProvider(IConfigurationProvider provider)
        {
            if (provider == null)
            {
                return;
            }

            m_configurationProviders.Add(provider);
        }
    
        public long GetDecryptedValue(ConfigurationItem<long> item)
        {
            if (item.IsEncryptedAtRest())
            {
                byte[] bytes = BitConverter.GetBytes(item.GetValue());
                string sValue = m_configurationEncryptor.Decrypt(bytes);
                long iTemp;
                if (long.TryParse(sValue, out iTemp))
                {
                    return iTemp;
                }
                else
                {
                    throw new Exception("Decrypted value could not be interpreted as a long");
                }
            }
            else
            {
                return item.GetValue();
            }
        }

        public bool LoadConfiguration()
        {
            if (!m_configurationLoadLock.WaitOne())
            {
                return false;
            }
            
            foreach (IConfigurationProvider provider in m_configurationProviders)
            {
                ConfigurationSourceDetails sourceDetails = null;
                ConfigurationItemDetailsSet itemDetailsSet;
                try
                {
                    sourceDetails = provider.GetConfigurationSourceDetails();
                    itemDetailsSet = provider.GetConfigurationItems();
                }
                catch (Exception)
                {
                    m_configurationLoadLock.Release();
                    throw;
                }

                if (sourceDetails == null)
                {
                    m_configurationLoadLock.Release();
                    throw new Exception("A configuration provider failed to provide configuration source details");
                }

                // The source and item validators are not required but having neither in a production system should
                // generally be considered poor practise. Theres a good justification for having them as optional
                // during development though
                if (m_configurationSourceDetailsValidator != null)
                {
                    ConfigurationSourceValidatorResult result = m_configurationSourceDetailsValidator.IsValid(sourceDetails);
                    if (!result.IsValid())
                    {
                        m_configurationLoadLock.Release();
                        throw new Exception(CreateFormattedExceptionMessage(
                            "A configuration provider specified invalid configuration source details.",
                            result.GetDetails()));
                    }
                }

                ConfigurationItemSet itemSet;
                itemSet.Longs = new List<ConfigurationItem<long>>();
                itemSet.Strings = new List<ConfigurationItem<string>>();
                itemSet.Doubles = new List<ConfigurationItem<double>>();
                itemSet.Bools = new List<ConfigurationItem<bool>>();

                if (m_configurationItemValidator != null)
                {
                    foreach (ConfigurationItemDetails<long> item in itemDetailsSet.Longs)
                    {
                        ConfigurationItemValidatorResult result = m_configurationItemValidator.IsValid(item);
                        if (!result.IsValid())
                        {
                            m_configurationLoadLock.Release();
                            throw new Exception(CreateFormattedExceptionMessage(
                                "A configuration provider specified an invalid configuration item of type 'long'.",
                                result.GetDetails()));
                        }
                        itemSet.Longs.Add(new ConfigurationItem<long>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<double> item in itemDetailsSet.Doubles)
                    {
                        ConfigurationItemValidatorResult result = m_configurationItemValidator.IsValid(item);
                        if (!result.IsValid())
                        {
                            m_configurationLoadLock.Release();
                            throw new Exception(CreateFormattedExceptionMessage(
                                "A configuration provider specified an invalid configuration item of type 'double'.",
                                result.GetDetails()));
                        }
                        itemSet.Doubles.Add(new ConfigurationItem<double>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<string> item in itemDetailsSet.Strings)
                    {
                        ConfigurationItemValidatorResult result = m_configurationItemValidator.IsValid(item);
                        if (!result.IsValid())
                        {
                            m_configurationLoadLock.Release();
                            throw new Exception(CreateFormattedExceptionMessage(
                                "A configuration provider specified an invalid configuration item of type 'string'.",
                                result.GetDetails()));
                        }
                        itemSet.Strings.Add(new ConfigurationItem<string>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<bool> item in itemDetailsSet.Bools)
                    {
                        ConfigurationItemValidatorResult result = m_configurationItemValidator.IsValid(item);
                        if (!result.IsValid())
                        {
                            m_configurationLoadLock.Release();
                            throw new Exception(CreateFormattedExceptionMessage(
                                "A configuration provider specified an invalid configuration item of type 'bool'.",
                                result.GetDetails()));
                        }
                        itemSet.Bools.Add(new ConfigurationItem<bool>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                }
                else
                {
                    foreach (ConfigurationItemDetails<long> item in itemDetailsSet.Longs)
                    {
                        itemSet.Longs.Add(new ConfigurationItem<long>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<double> item in itemDetailsSet.Doubles)
                    {
                        itemSet.Doubles.Add(new ConfigurationItem<double>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<string> item in itemDetailsSet.Strings)
                    {
                        itemSet.Strings.Add(new ConfigurationItem<string>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                    foreach (ConfigurationItemDetails<bool> item in itemDetailsSet.Bools)
                    {
                        itemSet.Bools.Add(new ConfigurationItem<bool>(Interlocked.Increment(ref m_iNextItemId), item));
                    }
                }

                // Create the new source
                ConfigurationSource source = new ConfigurationSource(
                    Interlocked.Increment(ref m_iNextSourceId),
                    sourceDetails.GetName(),
                    sourceDetails.GetDisplayName(),
                    sourceDetails.GetDescription());

                // Create the configuration
                Configuration configuration = new Configuration(
                    source.GetId(),
                    itemSet);

                // Store the configuration and the configuration source
                ConcurrentBag<int> temp;
                if (m_configurationSourceIdsByName.TryGetValue(source.GetName(), out temp))
                {
                    temp.Add(source.GetId());
                }
                else
                {
                    temp = new ConcurrentBag<int>();
                    temp.Add(source.GetId());
                    m_configurationSourceIdsByName.TryAdd(source.GetName(), temp);
                }
                m_configurationSourcesBySourceId.TryAdd(source.GetId(), source);
                m_configurationsBySourceId.TryAdd(source.GetId(), configuration);
                m_configurationSourceIds.Add(source.GetId());

                // Map configuration item ids to configuration source ids
                foreach (ConfigurationItem<long> item in itemSet.Longs)
                {
                    m_configurationItemsIds.Add(item.GetId());
                    m_configurationItemIdsBySourceId.TryAdd(item.GetId(), source.GetId());

                    if (m_configurationItemIdsByName.TryGetValue(item.GetName(), out temp))
                    {
                        temp.Add(item.GetId());
                    }
                    else
                    {
                        temp = new ConcurrentBag<int>();
                        temp.Add(item.GetId());
                        m_configurationItemIdsByName.TryAdd(item.GetName(), temp);
                    }
                }
                foreach (ConfigurationItem<string> item in itemSet.Strings)
                {
                    m_configurationItemsIds.Add(item.GetId());
                    m_configurationItemIdsBySourceId.TryAdd(item.GetId(), source.GetId());

                    if (m_configurationItemIdsByName.TryGetValue(item.GetName(), out temp))
                    {
                        temp.Add(item.GetId());
                    }
                    else
                    {
                        temp = new ConcurrentBag<int>();
                        temp.Add(item.GetId());
                        m_configurationItemIdsByName.TryAdd(item.GetName(), temp);
                    }
                }
                foreach (ConfigurationItem<double> item in itemSet.Doubles)
                {
                    m_configurationItemsIds.Add(item.GetId());
                    m_configurationItemIdsBySourceId.TryAdd(item.GetId(), source.GetId());

                    if (m_configurationItemIdsByName.TryGetValue(item.GetName(), out temp))
                    {
                        temp.Add(item.GetId());
                    }
                    else
                    {
                        temp = new ConcurrentBag<int>();
                        temp.Add(item.GetId());
                        m_configurationItemIdsByName.TryAdd(item.GetName(), temp);
                    }
                }
                foreach (ConfigurationItem<bool> item in itemSet.Bools)
                {
                    m_configurationItemsIds.Add(item.GetId());
                    m_configurationItemIdsBySourceId.TryAdd(item.GetId(), source.GetId());

                    if (m_configurationItemIdsByName.TryGetValue(item.GetName(), out temp))
                    {
                        temp.Add(item.GetId());
                    }
                    else
                    {
                        temp = new ConcurrentBag<int>();
                        temp.Add(item.GetId());
                        m_configurationItemIdsByName.TryAdd(item.GetName(), temp);
                    }
                }
            }
            m_configurationLoadLock.Release();
            return true;
        }

        private string CreateFormattedExceptionMessage(string sBaseMessage, List<string> additionalDetails)
        {
            string sAdditionalDetails = string.Join("\n", additionalDetails);
            if (string.IsNullOrWhiteSpace(sAdditionalDetails))
            {
                sAdditionalDetails = "No additional details were provided.";
            }

            return sBaseMessage + " " + sAdditionalDetails;
        }

        public List<int> GetConfigurationSourceIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_configurationSourceIds);
            return ids;
        }

        public List<int> GetConfigurationSourceIds(string sName)
        {
            return GetConfigurationSourceIds(new List<string> { sName });
        }

        public List<int> GetConfigurationSourceIds(List<string> names)
        {
            List<int> sourceIds = new List<int>();
            foreach (string sName in names)
            {
                ConcurrentBag<int> sourceIdsForName = null;
                if (m_configurationSourceIdsByName.TryGetValue(sName, out sourceIdsForName))
                {
                    sourceIds.AddRange(sourceIdsForName);
                }
                else
                {
                    sourceIds.Add(-1);
                }
            }
            return sourceIds;
        }

        public List<ConfigurationSource> GetConfigurationSources()
        {
            List<ConfigurationSource> sources = new List<ConfigurationSource>();
            foreach (int iId in m_configurationSourceIds)
            {
                ConfigurationSource source = null;
                if (m_configurationSourcesBySourceId.TryGetValue(iId, out source))
                {
                    sources.Add(source);
                }
            }
            return sources;
        }

        public List<ConfigurationSource> GetConfigurationSources(int iId)
        {
            return GetConfigurationSources(new List<int> { iId });
        }

        public List<ConfigurationSource> GetConfigurationSources(List<int> ids)
        {
            List<ConfigurationSource> sources = new List<ConfigurationSource>();
            foreach (int iId in ids)
            {
                ConfigurationSource source = null;
                if (m_configurationSourcesBySourceId.TryGetValue(iId, out source))
                {
                    sources.Add(source);
                }
                else
                {
                    sources.Add(null);
                }
            }
            return sources;
        }



        public List<ConfigurationItem<long>> GetLongItems()
        {
            List<ConfigurationItem<long>> items = new List<ConfigurationItem<long>>();
            foreach (int iItemId in m_configurationItemsIds)
            {
                Configuration config;
                if (m_configurationsBySourceId.TryGetValue(iItemId, out config))
                {
                    items.AddRange(config.GetLongItems(iItemId));
                }
            }
            
            return items;
        }

        public List<ConfigurationItem<long>> GetLongItems(int iId)
        {
            return GetLongItems(new List<int> { iId });
        }

        public List<ConfigurationItem<long>> GetLongItems(List<int> ids)
        {
            List<ConfigurationItem<long>> items = new List<ConfigurationItem<long>>();
            foreach (int iItemId in ids)
            {
                Configuration config;
                if (m_configurationsBySourceId.TryGetValue(iItemId, out config))
                {
                    items.AddRange(config.GetLongItems(iItemId));
                }
            }

            return items;
        }

        public List<ConfigurationItem<long>> GetLongItemsFromSources(int iSourceId)
        {
            List<ConfigurationItem<long>> items = new List<ConfigurationItem<long>>();
            foreach (int iItemId in m_configurationItemsIds)
            {
                Configuration config;
                if (m_configurationsBySourceId.TryGetValue(iItemId, out config))
                {
                    if (config.GetSourceId() == iSourceId)
                    {
                        items.AddRange(config.GetLongItems(iItemId));
                    }
                }
            }

            return items;
        }

        public List<ConfigurationItem<long>> GetLongItemsFromSources(int iSourceId, int iId)
        {
            return GetLongItemsFromSources(iSourceId, new List<int> { iId });
        }

        public List<ConfigurationItem<long>> GetLongItemsFromSources(int iSourceId, List<int> ids)
        {
            List<ConfigurationItem<long>> items = new List<ConfigurationItem<long>>();
            foreach (int iItemId in ids)
            {
                Configuration config;
                if (m_configurationsBySourceId.TryGetValue(iItemId, out config))
                {
                    if (config.GetSourceId() == iSourceId)
                    {
                        items.AddRange(config.GetLongItems(iItemId));
                    }
                }
            }

            return items;
        }
    }
}
