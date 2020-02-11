using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gryphon.Framework.Api
{
    /// <summary>
    /// The api context manager is responsible for the storage of api contexts. This class is thread
    /// safe.
    /// </summary>
    public class ApiContextManager
    {
        private int m_iNextApiContextId;
        private readonly ConcurrentDictionary<int, ApiContext> m_apiContexts;

        public ApiContextManager(ApiContextManagerConfig config)
        {
            m_iNextApiContextId = 0;
            m_apiContexts = new ConcurrentDictionary<int, ApiContext>();
        }

        public int AddApiContext(ApiContext context)
        {
            if (context == null)
            {
                return -1;
            }

            int iApiContextId = Interlocked.Increment(ref m_iNextApiContextId);
            m_apiContexts.TryAdd(iApiContextId, context);
            return iApiContextId;
        }

        public void RemoveApiContext(int iApiContext)
        {
            ApiContext dummy;
            m_apiContexts.TryRemove(iApiContext, out dummy);
        }

        public ApiContext GetApiContext(int iApiContext)
        {
            ApiContext temp;
            if (m_apiContexts.TryGetValue(iApiContext, out temp))
            {
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
}
