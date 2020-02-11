using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public struct ConfigurationItemDetailsSet
    {
        public List<ConfigurationItemDetails<long>> Longs;
        public List<ConfigurationItemDetails<double>> Doubles;
        public List<ConfigurationItemDetails<bool>> Bools;
        public List<ConfigurationItemDetails<string>> Strings;
    }
}
