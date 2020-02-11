using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class GenericMessage : IMessage
    {
        private readonly int m_iTypeId;
        private readonly int m_iAssociationId;
        private readonly DateTime? m_occurredOn;
        private readonly string m_sText;

        public GenericMessage(int iTypeId, string sText, int iAssociationId)
        {
            m_iTypeId = iTypeId;
            m_sText = sText;
            m_iAssociationId = iAssociationId;
        }

        public GenericMessage(int iTypeId, string sText, int iAssociationId, DateTime? occurredOn)
        {
            m_iTypeId = iTypeId;
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
