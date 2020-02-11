using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gryphon.Modules.Logging
{
    public class LogManager
    {
        private IMessageValidator m_messageValidator;
        private IMessageParser m_messageParser;

        public LogManager(ILogManagerConfigProvider configProvider)
        {
            if (configProvider != null)
            {
                m_messageValidator = configProvider.GetMessageValidator();
                m_messageParser = configProvider.GetMessageParser();
            }
            else
            {
                m_messageValidator = null;
                m_messageParser = new DefaultMessageParser();
            }
            
            if (m_messageParser == null)
            {
                throw new Exception();
            }
        }
   
        public void WriteToLog(List<ILogWriter> logWriters, IMessage message)
        {
            bool bResult = m_messageValidator.IsValid(message);
            if (!bResult)
            {
                return;
            }

            MessageData messageData = new MessageData();
            messageData.AssociationId = message.GetAssociationId();
            messageData.MessageTypeId = message.GetMessageTypeId();
            messageData.OccurredOn = message.GetOccurredOn();
            messageData.MessageText = message.GetMessageText();
            foreach (ILogWriter writer in logWriters)
            {
                writer.Write(messageData);
            }
        }

        public List<IMessage> ReadFromLog(ILogReader reader, LogFilter filters)
        {
            List<IMessage> messages = new List<IMessage>();
            
            List<MessageData> messageDatas = reader.Read(filters);
            foreach (MessageData data in messageDatas)
            {
                IMessage message = m_messageParser.Parse(data);
                if (message != null)
                {
                    messages.Add(message);
                }
            }
            
            return messages;
        }
    }
}
