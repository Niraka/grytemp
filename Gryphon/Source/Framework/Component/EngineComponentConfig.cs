using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class EngineComponentConfig
    {
        private readonly EngineComponentId m_componentId;
        private readonly EngineComponentDescriptor m_componentDescriptor;
        private readonly Api.ApiContextManager m_apiContextManager;
        private readonly Configuration.ConfigurationManager m_configurationManager;

        public EngineComponentConfig()
        {
            m_componentId = null;
            m_componentDescriptor = null;
        }

        public EngineComponentConfig(
            EngineComponentId componentId, 
            EngineComponentDescriptor componentDescriptor,
            Api.ApiContextManager apiContextManager,
            Configuration.ConfigurationManager configurationManager)
        {
            m_componentId = componentId;
            m_componentDescriptor = componentDescriptor;

            m_apiContextManager = apiContextManager;
            m_configurationManager = configurationManager;
        }
        
        public EngineComponentId GetComponentId()
        {
            return m_componentId;
        }

        public EngineComponentDescriptor GetComponentDescriptor()
        {
            return m_componentDescriptor;
        }

        public Api.ApiContextManager GetApiContextManager()
        {
            return m_apiContextManager;
        }
        
        public Configuration.ConfigurationManager GetConfigurationManager()
        {
            return m_configurationManager;
        }
    }
}
