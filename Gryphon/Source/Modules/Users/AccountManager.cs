using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    internal class AccountManager
    {
        private readonly List<int> m_stateIds;
        private readonly Dictionary<string, int> m_stateIdsByName;
        private readonly Dictionary<int, AccountState> m_statesById;

        public AccountManager(IAccountManagerConfigProvider configProvider)
        {
            if (configProvider == null)
            {
                throw new Exception();
            }

            List<AccountState> states = new List<AccountState>();
            states.Add(new AccountState(0, "active", "An active account"));

            foreach (AccountState state in states)
            {
                m_stateIds.Add(state.GetId());
                m_stateIdsByName.Add(state.GetName(), state.GetId());
                m_statesById.Add(state.GetId(), state);
            }
        }

        public Task<List<int>> GetStateIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_stateIds);
            return Task.FromResult<List<int>>(ids);
        }

        public Task<List<int>> GetStateIds(List<string> stateNames)
        {
            List<int> ids = new List<int>();
            foreach (string sName in stateNames)
            {
                int iTempId;
                if (m_stateIdsByName.TryGetValue(sName, out iTempId))
                {
                    ids.Add(iTempId);
                }
                else
                {
                    ids.Add(-1);
                }
            }

            return Task.FromResult<List<int>>(ids);
        }

        public Task<List<AccountState>> GetAccountStates(List<int> stateIds)
        {
            List<AccountState> states = new List<AccountState>();
            foreach (int iStateId in stateIds)
            {
                AccountState temp;
                if (m_statesById.TryGetValue(iStateId, out temp))
                {
                    states.Add(temp);
                }
                else
                {
                    states.Add(null);
                }
            }

            return Task.FromResult<List<AccountState>>(states);
        }

        public Task<List<Account>> GetAccounts(List<int> accountIds)
        {
            return null;
        }
    }
}
