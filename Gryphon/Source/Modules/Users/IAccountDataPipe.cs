using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    public interface IAccountDataPipe : IIntegration
    {
        Task<List<int>> MergeAccounts(List<AccountDetails> accountDetails); // whats the identifying info??? user id???
        Task<List<int>> GetAccountIds(int iContextId, List<int> userIds);
        Task<List<AccountData>> GetAccounts(List<int> accountIds);
        Task DestroyAccounts(List<int> accountIds);
    }
}
