using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    /// <summary>
    /// An api dictates the functionality provided by Gryphon.
    /// </summary>
    public class Api
    {
        private readonly int m_iUid;
        public readonly Logging.Api Logging;
        public readonly Database.Api Database;
        
        public Api(
            int iUid,
            Logging.Api loggingApi,
            Database.Api databaseApi)
        {
            m_iUid = iUid;
            Logging = loggingApi;
            Database = databaseApi;
        }

        /// <summary>
        /// Gets the unique id of the api object.
        /// </summary>
        /// <returns>The id of the api object</returns>
        public int GetUid()
        {
            return m_iUid;
        }
    }
}
