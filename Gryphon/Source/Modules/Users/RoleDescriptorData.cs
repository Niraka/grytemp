using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class RoleDescriptorData
    {
        public int Id { get; set; }
        public int ContextId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
