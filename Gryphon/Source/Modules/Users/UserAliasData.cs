using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserAliasData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CeatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string Alias { get; set; }
    }
}
