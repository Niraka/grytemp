using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserAddress
    {
        private readonly int m_iId;
        private readonly int m_iUserId;
        private readonly DateTime m_createdDate;
        private readonly DateTime m_deletedDate;
        private readonly int m_iAddressTypeId;
        private readonly string m_sAddress;

        public UserAddress(int iId, int iUserId, DateTime createdDate, DateTime deletedDate,
            int iAddressTypeId, string sAddress)
        {
            m_iId = iId;
            m_iUserId = iUserId;
            m_createdDate = createdDate;
            m_deletedDate = deletedDate;
            m_iAddressTypeId = iAddressTypeId;
            m_sAddress = sAddress;
        }
    }
}
