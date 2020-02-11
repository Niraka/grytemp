using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api.Database
{
    public class Api
    {
        private readonly int m_iApiContextId;

        public Api(string module, int iApiContextId)
        {
            m_iApiContextId = iApiContextId;
        }
    }
}
