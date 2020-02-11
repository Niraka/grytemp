using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public struct ConfigurationItemSet
    {
        public List<ConfigurationItem<long>> Longs;
        public List<ConfigurationItem<double>> Doubles;
        public List<ConfigurationItem<bool>> Bools;
        public List<ConfigurationItem<string>> Strings;
    }
}
