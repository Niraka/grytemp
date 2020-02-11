using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Permissions
{
    internal interface IPermissionModuleConfigProvider
    {
        IPermissionValidator GetPermissionValidator();
        IPermissionTargetValidator GetPermissionTargetValidator();
    }
}
