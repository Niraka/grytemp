using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    class UserAddressData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int AddressTypeId { get; set; }
        public string Address { get; set; }
    }
}
