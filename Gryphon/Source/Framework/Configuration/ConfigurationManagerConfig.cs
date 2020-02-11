using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationManagerConfig
    {
        private readonly IConfigurationEncryptor m_encryptor;
        private readonly IConfigurationItemValidator m_itemValidator;
        private readonly IConfigurationSourceDetailsValidator m_sourceDetailsValidator;

        public ConfigurationManagerConfig()
        {
            m_encryptor = null;
            m_itemValidator = null;
            m_sourceDetailsValidator = null;
        }

        public ConfigurationManagerConfig(IConfigurationEncryptor encryptor, 
            IConfigurationItemValidator validator, IConfigurationSourceDetailsValidator sourceDetailsValidator)
        {
            m_encryptor = encryptor;
            m_itemValidator = validator;
            m_sourceDetailsValidator = sourceDetailsValidator;
        }

        public IConfigurationEncryptor GetConfigurationEncryptor()
        {
            return m_encryptor;
        }

        public IConfigurationItemValidator GetConfigurationItemValidator()
        {
            return m_itemValidator;
        }

        public IConfigurationSourceDetailsValidator GetConfigurationSourceDetailsValidator()
        {
            return m_sourceDetailsValidator;
        }
    }
}
