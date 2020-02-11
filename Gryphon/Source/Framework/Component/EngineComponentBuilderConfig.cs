using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class EngineComponentBuilderConfig
    {
        private readonly IEngineComponentIdGenerator m_idDistributor;
        private readonly Api.ApiContextManager m_apiContextManager;
        private readonly Configuration.ConfigurationManager m_configurationManager;

        public EngineComponentBuilderConfig(IEngineComponentIdGenerator idDistributor,
            Api.ApiContextManager apiContextManager,
            Configuration.ConfigurationManager configurationManager)
        {
            m_idDistributor = idDistributor;
            m_apiContextManager = apiContextManager;
            m_configurationManager = configurationManager;
        }

        public IEngineComponentIdGenerator GetIdDistributor()
        {
            return m_idDistributor;
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
