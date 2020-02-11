using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class MessageData
    {
        public int MessageTypeId { get; set; }
        public DateTime? OccurredOn { get; set; }
        public int AssociationId { get; set; }
        public string MessageText { get; set; }
    }
}
