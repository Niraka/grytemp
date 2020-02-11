using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserNameData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Titles { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public List<string> MiddleNames { get; set; }
    }
}
