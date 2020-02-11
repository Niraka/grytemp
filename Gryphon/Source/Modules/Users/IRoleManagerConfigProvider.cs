using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    internal interface IRoleManagerConfigProvider
    {
        IRoleDescriptorValidator GetRoleValidator();
    }
}
