using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Requirement
{
    /// <summary>
    /// A requirement descriptor contains information about a requirement.
    /// </summary>
    public class RequirementDescriptor
    {
        private readonly string m_sName;
        private readonly List<string> m_description;

        /// <summary>
        /// Contstructs a default requirement descriptor.
        /// </summary>
        public RequirementDescriptor()
        {
            m_sName = string.Empty;
            m_description = new List<string>();
        }

        /// <summary>
        /// Constructs a requirement descriptor with the given information
        /// </summary>
        /// <param name="sName">The name of the requirement</param>
        /// <param name="sDescription">A description of the requirement</param>
        public RequirementDescriptor(string sName, string sDescription)
        {
            m_sName = sName ?? string.Empty;
            m_description = sDescription != null ? 
                new List<string>() { sDescription } : 
                new List<string>();
        }

        /// <summary>
        /// Constructs a requirement descriptor with the given information
        /// </summary>
        /// <param name="sName">The name of the requirement</param>
        /// <param name="description">A description of the requirement</param>
        public RequirementDescriptor(string sName, List<string> description)
        {
            m_sName = sName ?? string.Empty;
            m_description = description ?? new List<string>();
        }

        /// <summary>
        /// Gets the name of the requirement.
        /// </summary>
        /// <returns>The name of the requirement</returns>
        public string GetName()
        {
            return m_sName;
        }

        /// <summary>
        /// Gets the description of the requirement.
        /// </summary>
        /// <returns>The description of the requirement</returns>
        public List<string> GetDescription()
        {
            return m_description;
        }
    }
}
