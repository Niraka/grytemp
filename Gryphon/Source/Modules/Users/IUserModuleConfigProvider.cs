using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    internal interface IUserModuleConfigProvider :
        IRoleManagerConfigProvider,
        IAccountManagerConfigProvider,
        IUserManagerConfigProvider
    {

    }
}
