using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class MessageTypeDescriptor
    {
        private readonly int m_iTypeId;
        private readonly string m_sName;
        private readonly string m_sDescription;

        public MessageTypeDescriptor()
        {
            m_iTypeId = -1;
            m_sName = string.Empty;
            m_sDescription = string.Empty;
        }

        public MessageTypeDescriptor(int iTypeId, string sName, string sDescription)
        {
            m_iTypeId = iTypeId;
            m_sName = sName;
            m_sDescription = sDescription;
        }

        public int GetTypeId()
        {
            return m_iTypeId;
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
