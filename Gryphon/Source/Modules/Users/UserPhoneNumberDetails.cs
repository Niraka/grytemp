using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    public class UserPhoneNumberDetails
    {
        private readonly int m_iUserId;
        private readonly string m_sNumber;

        public UserPhoneNumberDetails(int iUserId, string sNumber)
        {
            m_iUserId = iUserId;
            m_sNumber = sNumber;
        }

        public int GetUserId()
        {
            return m_iUserId;
        }

        public string GetPhoneNumber()
        {
            return m_sNumber;
        }
    }
}
