using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    public class ApiManager
    {
        private readonly ApiContextManager m_apiContextManager;
        private readonly IApiContextBuilder m_apiContextBuilder;
        private readonly IApiBuilder m_apiBuilder;
        private int m_iNextApiId;

        public ApiManager(ApiManagerConfig config)
        {
            m_iNextApiId = 0;
            m_apiBuilder = config.GetApiBuilder();
            m_apiContextBuilder = config.GetApiContextBuilder();
            m_apiContextManager = new ApiContextManager(new ApiContextManagerConfig());
        }

        public ApiContextManager GetContextManager()
        {
            return m_apiContextManager;
        }

        public int AddApiContext(ApiConfig config)
        {
            if (config == null)
            {
                return -1;
            }

            ApiContext context = m_apiContextBuilder.Build(config);
            if (context == null)
            {
                return -1;
            }

            return m_apiContextManager.AddApiContext(context);
        }

        public void RemoveApiContext(int iApiContextId)
        {
            m_apiContextManager.RemoveApiContext(iApiContextId);
        }

        public Api CreateApi(int iApiContextId)
        {
            return m_apiBuilder.Build(++m_iNextApiId, iApiContextId);
        }
    }
}
