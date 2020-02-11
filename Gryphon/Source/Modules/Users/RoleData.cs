using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class RoleData
    {
        public RoleDescriptorData RoleDescriptor { get; set; }
        public List<int> MemberIds { get; set; }
    }
}
