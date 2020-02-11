using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Users
{
    // Gryphon wont validate titles, at least not for the first iteration of the user system. There are a 
    // very large number of them and their legal weight varies. If a user intentionally provides a title
    // which they dont possess then legal obligations lie with them.
    public class UserName
    {
        private readonly int m_iId;
        private readonly int m_iUserId;
        private readonly DateTime m_createdDate;
        private readonly List<string> m_titles;
        private readonly string m_sFirstName;
        private readonly string m_sSurName;
        private readonly List<string> m_middleNames;
    }
}
