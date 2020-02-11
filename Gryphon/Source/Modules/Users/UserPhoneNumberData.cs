using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserPhoneNumberData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string Number { get; set; }
    }
}
