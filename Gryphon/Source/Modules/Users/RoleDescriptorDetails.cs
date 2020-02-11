using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class RoleDescriptorDetails
    {
        private readonly string m_sName;
        private readonly string m_sDescription;

        public RoleDescriptorDetails(string sName, string sDescription)
        {
            m_sName = sName;
            m_sDescription = sDescription;
        }

        public string GetName()
        {
            return m_sName;
        }

        public string GetDescription()
        {
            return m_sDescription;
        }
    }
}
