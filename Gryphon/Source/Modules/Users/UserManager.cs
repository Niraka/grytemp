using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Users
{
    internal class UserManager
    {
        private readonly IUserAddressValidator m_userAddressValidator;
        private readonly IUserNameValidator m_userNameValidator;
        private readonly IUserAliasValidator m_userAliasValidator;
        private readonly IUserPhoneNumberValidator m_userPhoneNumberValidator;
        private readonly IUserEmailAddressValidator m_userEmailAddressValidator;
        private readonly IUserServiceHandle m_userServiceHandle;

        private readonly List<int> m_userDataStateIds;
        private readonly Dictionary<string, int> m_userDataStateIdsByName;
        private readonly Dictionary<int, UserDataStates> m_userDataStatesById;

        private readonly List<int> m_addressTypeDefinitionIds;
        private readonly Dictionary<string, int> m_addressTypeDefinitionIdsByName;
        private readonly Dictionary<int, UserAddressTypeDefinition> m_addressTypeDefinitionsById;

        private readonly List<int> m_socialMediaServiceDefinitionIds;
        private readonly Dictionary<string, int> m_socialMediaServiceDefinitionIdsByName;
        private readonly Dictionary<int, UserSocialMediaServiceDefinition> m_socialMediaServiceDefinitionsById;

        public UserManager(IUserManagerConfigProvider configProvider)
        {
            if (configProvider == null)
            {
                throw new Exception();
            }

            m_userAddressValidator = configProvider.GetUserAddressValidator();
            m_userNameValidator = configProvider.GetUserNameValidator();
            m_userAliasValidator = configProvider.GetUserAliasValidator();
            m_userPhoneNumberValidator = configProvider.GetUserPhoneNumberValidator();
            m_userEmailAddressValidator = configProvider.GetUserEmailAddressValidator();
            m_userServiceHandle = configProvider.GetUserServiceHandle();

            if (m_userNameValidator == null)
            {
                throw new Exception();
            }
            if (m_userAliasValidator == null)
            {
                throw new Exception();
            }
            if (m_userPhoneNumberValidator == null)
            {
                throw new Exception();
            }
            if (m_userEmailAddressValidator == null)
            {
                throw new Exception();
            }
            if (m_userAddressValidator == null)
            {
                throw new Exception();
            }
            if (m_userServiceHandle == null)
            {
                throw new Exception();
            }

            List<UserDataStates> dataStates = new List<UserDataStates>()
            {
                new UserDataStates(1, "active", "Active data."),
                new UserDataStates(2, "inactive", "Inactive data. Usually kept for history purposes."),
                new UserDataStates(3, "deleted", "Deleted data. Will be removed subject to regulations.")
            };
            List<UserAddressTypeDefinition> userAddressTypeDefinitions = new List<UserAddressTypeDefinition>
            {
                new UserAddressTypeDefinition(1, "uk")
            };
            List<UserSocialMediaServiceDefinition> userSocialMediaServiceDefinitions = new List<UserSocialMediaServiceDefinition>
            {
                new UserSocialMediaServiceDefinition(1, "facebook"),
                new UserSocialMediaServiceDefinition(2, "twitter"),
                new UserSocialMediaServiceDefinition(3, "youtube"),
                new UserSocialMediaServiceDefinition(4, "whatsapp"),
                new UserSocialMediaServiceDefinition(5, "skype"),
                new UserSocialMediaServiceDefinition(6, "instagram"),
                new UserSocialMediaServiceDefinition(7, "tumblr"),
                new UserSocialMediaServiceDefinition(11, "reddit"),
                new UserSocialMediaServiceDefinition(12, "discord"),
                new UserSocialMediaServiceDefinition(13, "linkedin"),
                new UserSocialMediaServiceDefinition(14, "snapchat"),
                new UserSocialMediaServiceDefinition(15, "pinterest"),
                new UserSocialMediaServiceDefinition(16, "telegram"),
                new UserSocialMediaServiceDefinition(17, "medium"),
                new UserSocialMediaServiceDefinition(17, "googleplus")
            };

            m_userDataStateIds = new List<int>();
            m_userDataStateIdsByName = new Dictionary<string, int>();
            m_userDataStatesById = new Dictionary<int, UserDataStates>();
            m_addressTypeDefinitionIds = new List<int>();
            m_addressTypeDefinitionIdsByName = new Dictionary<string, int>();
            m_addressTypeDefinitionsById = new Dictionary<int, UserAddressTypeDefinition>();
            m_socialMediaServiceDefinitionIds = new List<int>();
            m_socialMediaServiceDefinitionIdsByName = new Dictionary<string, int>();
            m_socialMediaServiceDefinitionsById = new Dictionary<int, UserSocialMediaServiceDefinition>();

            foreach (UserAddressTypeDefinition definition in userAddressTypeDefinitions)
            {
                m_addressTypeDefinitionIds.Add(definition.GetId());
                m_addressTypeDefinitionIdsByName.Add(definition.GetName(), definition.GetId());
                m_addressTypeDefinitionsById.Add(definition.GetId(), definition);
            }
            foreach (UserSocialMediaServiceDefinition definition in userSocialMediaServiceDefinitions)
            {
                m_socialMediaServiceDefinitionIds.Add(definition.GetId());
                m_socialMediaServiceDefinitionIdsByName.Add(definition.GetName(), definition.GetId());
                m_socialMediaServiceDefinitionsById.Add(definition.GetId(), definition);
            }
        }


        public Task<List<int>> MergeUsers(int iContextId, List<UserDetails> details)
        {

        }

        public Task<List<int>> MergeUserAddresses(List<UserAddressDetails> details)
        {

        }

        public Task<List<int>> MergeUserEmailAddresses(List<UserEmailAddressDetails> details)
        {

        }

        public Task<List<int>> MergeUserPhoneNumbers(List<UserPhoneNumberDetails> details)
        {

        }

        public Task<List<int>> MergeUserAliases(List<UserAliasDetails> details)
        {

        }

        public Task<List<int>> MergeUserNames(List<UserNameDetails> details)
        {

        }

        public Task<List<int>> MergeUserSocialMediaHandles(List<UserSocialMediaHandleDetails> details)
        {

        }

        public Task DestroyUsers(List<int> ids)
        {

        }

        public Task DestroyUserAddresses(List<int> ids)
        {

        }

        public Task DestroyUserEmailAddresses(List<int> ids)
        {

        }

        public Task DestroyUserPhoneNumbers(List<int> ids)
        {

        }

        public Task DestroyUserAliases(List<int> ids)
        {

        }

        public Task DestroyUserNames(List<int> ids)
        {

        }

        public Task DestroyUserSocialMediaHandles(List<int> ids)
        {

        }

        public Task<List<List<int>>> GetUserIds(int iContextId, List<string> userNames)
        {

        }

        public Task<List<List<int>>> GetUserAddressTypeDefinitionIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserAddressIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserEmailAddressIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserPhoneNumberIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserAliasIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserNameIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserSocialMediaServiceDefinitionIds(List<int> userIds)
        {

        }

        public Task<List<List<int>>> GetUserSocialMediaHandleIds(List<int> userIds)
        {

        }

        public Task<List<User>> GetUsers(List<int> userIds)
        {

        }

        public Task<List<List<UserAddressTypeDefinition>>> GetUserAddressTypeDefinitions(List<int> addressTypeDefinitionIds)
        {

        }

        public Task<List<List<UserAddress>>> GetUserAddresses(List<int> addressIds)
        {

        }

        public Task<List<List<UserEmailAddress>>> GetUserEmailAddresses(List<int> emailAddressIds)
        {

        }

        public Task<List<List<UserPhoneNumber>>> GetUserPhoneNumbers(List<int> phoneNumberIds)
        {

        }

        public Task<List<List<UserAlias>>> GetUserAliases(List<int> aliasIds)
        {

        }

        public Task<List<List<UserName>>> GetUserNames(List<int> nameIds)
        {

        }

        public Task<List<List<UserSocialMediaServiceDefinition>>> GetUserSocialMediaServiceDefinitions(List<int> socialMediaServiceIds)
        {

        }

        public Task<List<List<UserSocialMediaHandle>>> GetUserSocialMediaHandles(List<int> socialMediaHandleIds)
        {

        }
    }
}
