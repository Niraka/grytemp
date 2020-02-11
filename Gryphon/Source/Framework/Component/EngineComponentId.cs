using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class EngineComponentId
    {
        private readonly int m_iUid;

        public EngineComponentId()
        {
            m_iUid = -1;
        }

        public EngineComponentId(int iUid)
        {
            m_iUid = iUid;
        }

        public static bool operator ==(EngineComponentId first, EngineComponentId second)
        {
            bool bFirstIsNull = ReferenceEquals(first, null);
            bool bSecondIsNull = ReferenceEquals(second, null);

            if (bFirstIsNull && bSecondIsNull)
            {
                return true;
            }
            else if (bFirstIsNull || bSecondIsNull)
            {
                return false;
            }
            else
            {
                return first.m_iUid == second.m_iUid;
            }
        }

        public static bool operator !=(EngineComponentId first, EngineComponentId second)
        {
            return !(first != second);
        }

        public override bool Equals(object obj)
        {
            if (!ReferenceEquals(obj, null) && obj.GetType() == typeof(EngineComponentId))
            {
                return this == (EngineComponentId)obj;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return m_iUid.GetHashCode();
        }
    }
}
