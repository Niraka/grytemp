using System;
using System.Collections.Generic;
using System.Data.Entity;
using Gryphon.Modules.Group;
using Gryphon.Modules.Logging;
using Newtonsoft.Json;

namespace GryphonNetFrameworkLauncher
{
    public class GroupDataPipe : IGroupDataPipe
    {
        public class MessageContext : DbContext
        {
            public DbSet<GroupDescriptorData> Descriptors { get; set; }

            public MessageContext() : base(@"Data Source = DESKTOP-L2B8N96; Integrated Security = True; Initial Catalog = GRYPHON; Connection Timeout = 2")
            {   
            }

            protected override void OnModelCreating(DbModelBuilder builder)
            {
                builder.Entity<GroupDescriptorData>().ToTable("GROUP_DEFINITIONS").HasKey(o => o.Id);
            }
        }

        void IGroupDataPipe.AddMembersToGroups(List<int> memberIds, List<int> groupIds)
        {
            throw new NotImplementedException();
        }

        void IGroupDataPipe.DestroyGroups(List<int> groupIds)
        {
            throw new NotImplementedException();
        }

        List<GroupDescriptorData> IGroupDataPipe.GetGroupDescriptors(List<int> groupIds)
        {
            throw new NotImplementedException();
        }

        List<int> IGroupDataPipe.GetGroupIds()
        {
            throw new NotImplementedException();
        }

        List<int> IGroupDataPipe.GetGroupIds(List<string> groupNames)
        {
            throw new NotImplementedException();
        }

        List<GroupData> IGroupDataPipe.GetGroupMembers(List<int> groupIds)
        {
            throw new NotImplementedException();
        }

        List<int> IGroupDataPipe.MergeGroups(List<GroupDescriptorData> details)
        {
            using (var context = new MessageContext())
            {
                foreach (GroupDescriptorData data in details)
                {
                    context.Descriptors.Add(new GroupDescriptorData()
                    {
                        Id = -1,
                        Name = data.Name,
                        Description = data.Description
                    });
                }
                
                context.SaveChanges();
            }

            List<int> a = new List<int>();
            foreach (GroupDescriptorData data in details)
            {
                a.Add(data.Id);
            }
            return a;
        }

        void IGroupDataPipe.RemoveAllMembersFromGroups(List<int> groupIds)
        {
            throw new NotImplementedException();
        }

        void IGroupDataPipe.RemoveMembersFromGroups(List<int> memberIds, List<int> groupIds)
        {
            throw new NotImplementedException();
        }
    }

    public class GroupDescriptorValidator : IGroupDescriptorValidator
    {
        public bool IsValid(GroupDescriptorDetails details)
        {
            return true;
        }
    }

    public class ConfigProvider : IGroupManagerConfigProvider
    {
        private readonly IGroupDescriptorValidator m_groupDescriptorValidator;

        public ConfigProvider(IGroupDescriptorValidator groupDescriptorValidator)
        {
            m_groupDescriptorValidator = groupDescriptorValidator;
        }

        public IGroupDescriptorValidator GetGroupDescriptorValidator()
        {
            return m_groupDescriptorValidator;
        }
    }

    public class MessageValidator : IMessageValidator
    {
        public bool IsValid(IMessage message)
        {
            return true;
        }
    }

    public class MessageParser : IMessageParser
    {
        public IMessage Parse(MessageData data)
        {
            return new GenericMessage(data.MessageTypeId, data.MessageText, data.AssociationId, data.OccurredOn);
        }
    }

    public class LogManagerConfigProvider : ILogManagerConfigProvider
    {
        public IMessageParser GetMessageParser()
        {
            return new MessageParser();
        }

        public IMessageValidator GetMessageValidator()
        {
            return new MessageValidator();
        }
    }

    public class ConsoleLogWriter : ILogWriter
    {
        public bool Write(MessageData messageData)
        {
            string sMessage = "";
            switch (messageData.MessageTypeId)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("INFO:");
                    Console.ResetColor();
                    Console.WriteLine(" " + messageData.MessageText);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("WARNING:");
                    Console.ResetColor();
                    Console.WriteLine(" " + messageData.MessageText);
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR:");
                    Console.ResetColor();
                    Console.WriteLine(" " + messageData.MessageText);
                    break;
                default:
                    break;
            }
            return true;
        }
    }
    
    public class Launcher
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////

            List<ILogWriter> logWriters = new List<ILogWriter>() { new ConsoleLogWriter() };

            LogManager logManager = new LogManager(new LogManagerConfigProvider());
            logManager.WriteToLog(logWriters, new Info("Sharks are cool."));
            logManager.WriteToLog(logWriters, new Warning("Things could be worse but I think we're getting away with it."));
            logManager.WriteToLog(logWriters, new Error("Everythings gone to shit mate."));
            
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}