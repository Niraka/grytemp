using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class AssociationDetails
    {
        private readonly string m_sName;
        
        public AssociationDetails(string sName)
        {
            m_sName = sName;
        }

        public string GetName()
        {
            return m_sName;
        }
    }
}
