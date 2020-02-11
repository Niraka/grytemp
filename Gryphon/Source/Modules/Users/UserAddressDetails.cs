using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserAddressDetails
    {
        private readonly int m_iUserId;
        private readonly int m_iAddressTypeId;
        private readonly string m_sAddress;

        public UserAddressDetails(int iUserId, int iAddressTypeId, string sAddress)
        {
            m_iUserId = iUserId;
            m_iAddressTypeId = iAddressTypeId;
            m_sAddress = sAddress;
        }
    }
}
