using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public interface IConfigurationItemValidator
    {
        ConfigurationItemValidatorResult IsValid(ConfigurationItemDetails<long> configuration);
        ConfigurationItemValidatorResult IsValid(ConfigurationItemDetails<double> configuration);
        ConfigurationItemValidatorResult IsValid(ConfigurationItemDetails<string> configuration);
        ConfigurationItemValidatorResult IsValid(ConfigurationItemDetails<bool> configuration);
    }
}
