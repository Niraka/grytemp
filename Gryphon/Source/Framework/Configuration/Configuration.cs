using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Gryphon.Framework.Configuration
{
    public class Configuration
    {
        private readonly int m_iSourceId;

        private readonly Dictionary<int, List<ConfigurationItem<long>>> m_longs;
        private readonly List<int> m_longIds;
        private readonly Dictionary<string, int> m_longIdsByName;

        public Configuration(int iSourceId, ConfigurationItemSet itemSet)
        {
            m_iSourceId = iSourceId;

            m_longs = new Dictionary<int, List<ConfigurationItem<long>>>();
            m_longIds = new List<int>();
            m_longIdsByName = new Dictionary<string, int>();
            
            foreach (ConfigurationItem<long> item in itemSet.Longs)
            {
                if (!m_longs.ContainsKey(item.GetId()))
                {
                    List<ConfigurationItem<long>> list = new List<ConfigurationItem<long>>
                    {
                        item
                    };
                    m_longs.Add(item.GetId(), list);
                }
                else
                {
                    m_longs[item.GetId()].Add(item);
                }

                m_longIds.Add(item.GetId());
                m_longIdsByName.Add(item.GetName(), item.GetId());
            }
        }

        public int GetSourceId()
        {
            return m_iSourceId;
        }

        public List<int> GetLongItemIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_longIds);
            return ids;
        }

        public List<int> GetLongItemIds(string sName)
        {
            return GetLongItemIds(new List<string> { sName });
        }

        public List<int> GetLongItemIds(List<string> names)
        {
            List<int> ids = new List<int>();
            foreach (string sName in names)
            {
                int iTemp = -1;
                if (m_longIdsByName.TryGetValue(sName, out iTemp))
                {
                    ids.Add(iTemp);
                }
                else
                {
                    ids.Add(-1);
                }
            }
            return ids;
        }

        public List<ConfigurationItem<long>> GetLongItems()
        {
            List<ConfigurationItem<long>> items = new List<ConfigurationItem<long>>();
            foreach (int iId in m_longIds)
            {
                List<ConfigurationItem<long>> itemList = null;
                if (m_longs.TryGetValue(iId, out itemList))
                {
                    items.AddRange(itemList);
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
            foreach (int iId in ids)
            {
                List<ConfigurationItem<long>> itemList = null;
                if (m_longs.TryGetValue(iId, out itemList))
                {
                    items.AddRange(itemList);
                }
                else
                {
                    items.Add(null);
                }
            }
            return items;
        }
    }
}
