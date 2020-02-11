using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gryphon.Framework.Integration
{
    class IntegrationManager
    {
        private class IntegrationRegister
        {
        }

        private int m_iNextIntegrationSourceId;
        private readonly Dictionary<int, IntegrationSourceDescriptor> m_integrationSources;
        private readonly Dictionary<int, IntegrationRegister> m_integrations;

        public IntegrationManager(IntegrationManagerConfig config)
        {
            m_iNextIntegrationSourceId = 0;
            m_integrations = new Dictionary<int, IntegrationRegister>();
            m_integrationSources = new Dictionary<int, IntegrationSourceDescriptor>();
        }

        public int AddIntegrationSource(IntegrationSourceDescriptor descriptor)
        {
            if (descriptor == null)
            {
                return -1;
            }

            int iIntegrationSourceId = Interlocked.Increment(ref m_iNextIntegrationSourceId);
            m_integrationSources.Add(iIntegrationSourceId, descriptor);
            m_integrations.Add(iIntegrationSourceId, new IntegrationRegister());
            return iIntegrationSourceId;
        }

        public List<IntegrationSourceDescriptor> GetIntegrationDescriptors()
        {
            List<IntegrationSourceDescriptor> descriptors = new List<IntegrationSourceDescriptor>();
            return descriptors;
        }

        public List<IntegrationSourceDescriptor> GetIntegrationDescriptors(int iId)
        {
            return GetIntegrationDescriptors(new List<int>(1) { iId });
        }

        public List<IntegrationSourceDescriptor> GetIntegrationDescriptors(List<int> ids)
        {
            List<IntegrationSourceDescriptor> descriptors = new List<IntegrationSourceDescriptor>();
            return descriptors;
        }
    }
}
