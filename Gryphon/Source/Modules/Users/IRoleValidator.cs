using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    interface IRoleDescriptorValidator
    {
        Tools.ValidationResult IsValid(RoleDescriptorDetails roleDescriptorDetails);
    }
}
