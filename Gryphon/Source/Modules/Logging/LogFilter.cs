using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class LogFilter
    {
        public string MessageText { get; set; }
        public DateTime? EarliestDate { get; set; }
        public DateTime? LatestDate { get; set; }
        public int MessageTypeId { get; set; }
        public int AssociationId { get; set; }
    }
}
