using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class EngineComponentDescriptor
    {
        private readonly string m_sName;
        private readonly string m_sDescription;
        private readonly Version m_version;

        /// <summary>
        /// Constructs a default engine component descriptor.
        /// </summary>
        public EngineComponentDescriptor()
        {
            m_sName = string.Empty;
            m_sDescription = string.Empty;
            m_version = new Version(0, 0, 0, 0);
        }

        /// <summary>
        /// Constructs an engine component descriptor with the given parameters.
        /// </summary>
        /// <param name="sName">The components name</param>
        /// <param name="sDescription">The components description</param>
        /// <param name="version">The components version</param>
        public EngineComponentDescriptor(string sName, string sDescription, Version version)
        {
            m_sName = sName ?? string.Empty;
            m_sDescription = sDescription ?? string.Empty;
            m_version = version ?? new Version(0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the components name. This value is never null.
        /// </summary>
        /// <returns>The components name</returns>
        public string GetName()
        {
            return m_sName;
        }

        /// <summary>
        /// Gets the components description. This value is never null.
        /// </summary>
        /// <returns>The components description</returns>
        public string GetDescription()
        {
            return m_sDescription;
        }

        /// <summary>
        /// Gets the component version. This value is never null.
        /// </summary>
        /// <returns>The component version</returns>
        public Version GetVersion()
        {
            return m_version;
        }
    }
}
