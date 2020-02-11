using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class Module
    {
        private static readonly MessageTypeDescriptor m_infoMessageTypeDescriptor = new MessageTypeDescriptor(
            1, "info", "Information");
        private static readonly MessageTypeDescriptor m_warningMessageTypeDescriptor = new MessageTypeDescriptor(
            2, "warning", "A warning");
        private static readonly MessageTypeDescriptor m_errorMessageTypeDescriptor = new MessageTypeDescriptor(
            3, "error", "An error");
        private static readonly List<MessageTypeDescriptor> messageTypeDescriptors = new List<MessageTypeDescriptor>()
        {
            m_infoMessageTypeDescriptor,
            m_warningMessageTypeDescriptor,
            m_errorMessageTypeDescriptor
        };
        private static readonly Dictionary<int, MessageTypeDescriptor> m_messageTypeDescriptorsById = new Dictionary<int, MessageTypeDescriptor>()
        {
            { m_infoMessageTypeDescriptor.GetTypeId(), m_infoMessageTypeDescriptor },
            { m_warningMessageTypeDescriptor.GetTypeId(), m_warningMessageTypeDescriptor },
            { m_errorMessageTypeDescriptor.GetTypeId(), m_errorMessageTypeDescriptor }
        };
        private static readonly Dictionary<string, int> m_messageTypeDescriptorIdsByName = new Dictionary<string, int>()
        {
            { m_infoMessageTypeDescriptor.GetName(), m_infoMessageTypeDescriptor.GetTypeId() },
            { m_warningMessageTypeDescriptor.GetName(), m_warningMessageTypeDescriptor.GetTypeId() },
            { m_errorMessageTypeDescriptor.GetName(), m_errorMessageTypeDescriptor.GetTypeId() }
        };
        private static readonly List<int> m_messageTypeDescriptorIds = new List<int>()
        {
            m_infoMessageTypeDescriptor.GetTypeId(),
            m_warningMessageTypeDescriptor.GetTypeId(),
            m_errorMessageTypeDescriptor.GetTypeId(),
        };

        private readonly AssociationManager m_associationManager;
        private readonly LogManager m_logManager;

        public Module(IModuleConfigProvider configProvider)
        {
            m_associationManager = new AssociationManager(configProvider);
            m_logManager = new LogManager(configProvider);
        }

        public List<int> CreateAssociations(IAssociationDataPipe pipe, List<AssociationDetails> associationDetails)
        {
            return m_associationManager.CreateAssociations(pipe, associationDetails);
        }

        public void DestroyAssociations(IAssociationDataPipe pipe, List<int> associationIds)
        {
            m_associationManager.DestroyAssociations(pipe, associationIds);
        }

        public List<int> GetAssociationIds(IAssociationDataPipe pipe, List<string> associationNames)
        {
            return m_associationManager.GetAssociationIds(pipe, associationNames);
        }

        public List<Association> GetAssociations(IAssociationDataPipe pipe, List<int> associationIds)
        {
            return m_associationManager.GetAssociations(pipe, associationIds);
        }

        public List<int> GetMessageTypeDescriptorIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_messageTypeDescriptorIds);
            return ids;
        }

        public List<int> GetMessageTypeDescriptorIds(List<string> names)
        {
            List<int> ids = new List<int>();
            foreach (string sName in names)
            {
                int iTemp;
                if (m_messageTypeDescriptorIdsByName.TryGetValue(sName, out iTemp))
                {
                    ids.Add(iTemp);
                }
                else
                {
                    ids.Add(-1);
                }
            }
            return ids;
        }

        public List<MessageTypeDescriptor> GetMessageTypeDescriptors()
        {
            List<MessageTypeDescriptor> descriptors = new List<MessageTypeDescriptor>();
            descriptors.AddRange(messageTypeDescriptors);
            return descriptors;
        }

        public List<MessageTypeDescriptor> GetMessageTypeDescriptors(List<int> ids)
        {
            List<MessageTypeDescriptor> descriptors = new List<MessageTypeDescriptor>();
            foreach (int iId in ids)
            {
                MessageTypeDescriptor temp;
                if (m_messageTypeDescriptorsById.TryGetValue(iId, out temp))
                {
                    descriptors.Add(temp);
                }
                else
                {
                    descriptors.Add(null);
                }
            }
            return descriptors;
        }
        
        public void WriteToLog(List<ILogWriter> logWriters, IMessage message)
        {
            m_logManager.WriteToLog(logWriters, message);
        }

        public List<IMessage> ReadFromLog(ILogReader reader, LogFilter filters)
        {
            return m_logManager.ReadFromLog(reader, filters);
        }
    }
}
