using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gryphon.Framework
{
    public class EngineComponentIdGenerator : IEngineComponentIdGenerator
    {
        private int m_iNextUid;

        public EngineComponentIdGenerator()
        {
            m_iNextUid = 0;
        }

        public EngineComponentId GenerateId()
        {
            return new EngineComponentId(Interlocked.Increment(ref m_iNextUid));
        }
    }
}
