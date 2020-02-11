using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    /// <summary>
    /// An api configuration specifies the way in which an api object will operate.
    /// </summary>
    public class ApiConfig
    {
        private readonly string m_sName;
        private readonly int m_iSoftwareId;

        public int iIntegrationSouceIdAssociationPipe;

        /// <summary>
        /// Constructs a default api config.
        /// </summary>
        public ApiConfig()
        {
            m_sName = string.Empty;
            m_iSoftwareId = -1;
        }

        /// <summary>
        /// Constructs an api config with the given parameters.
        /// </summary>
        /// <param name="sName">A user friendly name for the configuration. This value is optional and 
        /// only used for debugging purposes</param>
        /// <param name="iSoftwareId">The id of the software that the api will operate on and as. Use -1
        /// to operate as an "anonymous" api that targets all known software</param>
        public ApiConfig(string sName, int iSoftwareId)
        {
            m_sName = sName ?? string.Empty;
            m_iSoftwareId = iSoftwareId;
        }

        /// <summary>
        /// Gets the api name. This value is never null.
        /// </summary>
        /// <returns>The api name</returns>
        public string GetName()
        {
            return m_sName;
        }

        /// <summary>
        /// Gets the id the software that the api will operate as. An id of -1 indicates an anonymous
        /// configuration that will operate as and on all known software.
        /// </summary>
        /// <returns>The id of the software that the api will operate as, or -1 to operate as all 
        /// software</returns>
        public int GetSoftwareId()
        {
            return m_iSoftwareId;
        }
    }
}
