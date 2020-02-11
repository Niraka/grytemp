using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class Error : IMessage
    {
        private const int m_iTypeId = 3;
        private readonly int m_iAssociationId;
        private readonly DateTime? m_occurredOn;
        private readonly string m_sText;

        public Error(string sText)
        {
            m_sText = sText;
            m_iAssociationId = -1;
            m_occurredOn = DateTime.Now;
        }

        public Error(string sText, int iAssociationId)
        {
            m_sText = sText;
            m_iAssociationId = iAssociationId;
            m_occurredOn = DateTime.Now;
        }

        public Error(string sText, int iAssociationId, DateTime occurredOn)
        {
            m_sText = sText;
            m_iAssociationId = iAssociationId;
            m_occurredOn = occurredOn;
        }

        public int GetAssociationId()
        {
            return m_iAssociationId;
        }

        public string GetMessageText()
        {
            return m_sText;
        }

        public int GetMessageTypeId()
        {
            return m_iTypeId;
        }

        public DateTime? GetOccurredOn()
        {
            return m_occurredOn;
        }
    }
}