using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    interface IUserDataPipe
    {
        Task<List<int>> MergeUsers(int iContextId, List<UserDetails> details);
        Task<List<int>> MergeUserAddresses(List<UserAddressDetails> details);
        Task<List<int>> MergeUserEmailAddresses(List<UserEmailAddressDetails> details);
        Task<List<int>> MergeUserPhoneNumbers(List<UserPhoneNumberDetails> details);
        Task<List<int>> MergeUserAliases(List<UserAliasDetails> details);
        Task<List<int>> MergeUserNames(List<UserNameDetails> details);
        Task<List<int>> MergeUserSocialMediaHandles(List<UserSocialMediaHandleDetails> details);

        Task DestroyUsers(List<int> ids, bool bImmediate);
        Task DestroyUserAddresses(List<int> ids, bool bImmediate);
        Task DestroyUserEmailAddresses(List<int> ids, bool bImmediate);
        Task DestroyUserPhoneNumbers(List<int> ids, bool bImmediate);
        Task DestroyUserAliases(List<int> ids, bool bImmediate);
        Task DestroyUserNames(List<int> ids, bool bImmediate);
        Task DestroyUserSocialMediaHandles(List<int> ids, bool bImmediate);

        Task<List<List<int>>> GetUserIds(int iContextId, List<string> userNames);
        Task<List<List<int>>> GetUserAddressIds(List<int> userIds, List<int> dataStates);
        Task<List<List<int>>> GetUserEmailAddressIds(List<int> userIds, List<int> dataStates);
        Task<List<List<int>>> GetUserPhoneNumberIds(List<int> userIds, List<int> dataStates);
        Task<List<List<int>>> GetUserAliasIds(List<int> userIds, List<int> dataStates);
        Task<List<List<int>>> GetUserNameIds(List<int> userIds, List<int> dataStates);
        Task<List<List<int>>> GetUserSocialMediaHandleIds(List<int> userIds, List<int> dataStates);

        Task<List<User>> GetUsers(List<int> userIds);
        Task<List<List<UserAddress>>> GetUserAddresses(List<int> addressIds);
        Task<List<List<UserEmailAddress>>> GetUserEmailAddresses(List<int> emailAddressIds);
        Task<List<List<UserPhoneNumber>>> GetUserPhoneNumbers(List<int> phoneNumberIds);
        Task<List<List<UserAlias>>> GetUserAliases(List<int> aliasIds);
        Task<List<List<UserName>>> GetUserNames(List<int> nameIds);
        Task<List<List<UserSocialMediaHandle>>> GetUserSocialMediaHandles(List<int> socialMediaHandleIds);
    }
}
