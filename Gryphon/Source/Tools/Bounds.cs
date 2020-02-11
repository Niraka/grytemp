using System;

namespace Gryphon.Tools
{
    public class Bounds<T> where T : IComparable<T>
    {
        public T lower;
        public T upper;

        public Bounds()
        {
            lower = default(T);
            upper = default(T);
        }

        public Bounds(T lower, T upper)
        {
            this.lower = lower;
            this.upper = upper;
        }
        
        public int CompareTo(Bounds<T> other)
        {
            int i = lower.CompareTo(other.lower);
            if (i == 0)
            {
                return upper.CompareTo(other.upper);
            }
            else
            {
                return i;
            }
        }
    }
}
