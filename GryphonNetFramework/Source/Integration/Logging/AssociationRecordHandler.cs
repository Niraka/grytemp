using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Gryphon.Modules.Logging;

//namespace GryphonNetFramework.Integration.Logging
//{
//    public class AssociationRecordHandler : Gryphon.Modules.Logging.IAssociationPipe
//    {
//        public AssociationRecordHandler()
//        {
//        }
//
//        public void Create(List<Gryphon.Modules.Logging.Association> associations)
//        {
//            using (var context = new MessageContext())
//            {
//                foreach (Gryphon.Modules.Logging.Association association in associations)
//                {
//                    context.Messages.Add(new AssociationRecord()
//                    {
//                        SourceId = 2,
//                        Name = association.GetContext(),
//                        Description = string.Empty
//                    });
//                }
//                
//                context.SaveChanges();
//            }
//        }
//
//        public void Delete()
//        {
//            throw new NotImplementedException();
//        }
//
//        public void Delete(List<int> uids)
//        {
//            throw new NotImplementedException();
//        }
//
//        public List<AssociationDetails> Get()
//        {
//            throw new NotImplementedException();
//        }
//
//        public List<AssociationDetails> Get(List<int> uids)
//        {
//            throw new NotImplementedException();
//        }
//    }
//
//    public class MessageContext : DbContext
//    {
//        public DbSet<AssociationRecord> Messages { get; set; }
//
//        public MessageContext() : base(@"Data Source = DESKTOP-L2B8N96; Integrated Security = True; Initial Catalog = GRYPHON; Connection Timeout = 2")
//        {
//        }
//
//        protected override void OnModelCreating(DbModelBuilder builder)
//        {
//            builder.Entity<AssociationRecord>().ToTable("LOG_ASSOCIATION").HasKey(o => o.Id);
//        }
//    }
//
//    public class AssociationRecord
//    {
//        public int Id { get; set; }
//        public int SourceId { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }
//    }
//}
//