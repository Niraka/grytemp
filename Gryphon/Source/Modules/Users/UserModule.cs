using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    internal class UserModule
    {
        private readonly RoleManager m_roleManager;
        private readonly UserManager m_userManager;
        private readonly AccountManager m_accountManager;

        public UserModule(IUserModuleConfigProvider configProvider)
        {
            m_roleManager = new RoleManager(configProvider);
            m_userManager = new UserManager(configProvider);
            m_accountManager = new AccountManager(configProvider);
        }

        public async Task<List<int>> A()
        {
            
            List<List<int>> userIds = await m_userManager.GetUserIds(1, new List<string> { "" });
            List<User> users = await m_userManager.GetUsers(userIds[0]);
            return null;
        }
    }
}
