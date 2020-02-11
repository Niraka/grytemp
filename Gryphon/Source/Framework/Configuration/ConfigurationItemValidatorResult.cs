using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Configuration
{
    public class ConfigurationItemValidatorResult
    {
        private bool m_bIsValid;
        private List<string> m_details;

        public ConfigurationItemValidatorResult(bool bIsValid)
        {
            m_bIsValid = bIsValid;
            m_details = new List<string>();
        }

        public ConfigurationItemValidatorResult(bool bIsValid, List<string> details)
        {
            m_bIsValid = bIsValid;
            m_details = details ?? new List<string>();
        }

        public bool IsValid()
        {
            return m_bIsValid;
        }

        public List<string> GetDetails()
        {
            return m_details;
        }
    }
}
