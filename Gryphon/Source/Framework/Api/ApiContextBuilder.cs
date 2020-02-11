using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    class ApiContextBuilder : IApiContextBuilder
    {
        private readonly Integration.IntegrationManager m_integrationManager;

        public ApiContextBuilder(Integration.IntegrationManager integrationManager)
        {
            m_integrationManager = integrationManager;
        }

        public ApiContext Build(ApiConfig config)
        {
            if (config == null)
            {
                return null;
            }

            if (m_integrationManager == null)
            {
                return null;
            }
            
            return new ApiContext();
        }
    }
}
