using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    internal interface IUserManagerConfigProvider
    {
        IUserNameValidator GetUserNameValidator();
        IUserAliasValidator GetUserAliasValidator();
        IUserPhoneNumberValidator GetUserPhoneNumberValidator();
        IUserEmailAddressValidator GetUserEmailAddressValidator();
        IUserAddressValidator GetUserAddressValidator();
        IUserServiceHandle GetUserServiceHandle();
    }
}
