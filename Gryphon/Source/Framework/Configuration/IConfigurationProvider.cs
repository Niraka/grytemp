﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public interface IConfigurationProvider
    {
        ConfigurationSourceDetails GetConfigurationSourceDetails();

        ConfigurationItemDetailsSet GetConfigurationItems();
    }
}
