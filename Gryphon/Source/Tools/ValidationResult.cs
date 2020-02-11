using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Tools
{
    public class ValidationResult
    {
        private readonly bool m_bIsValid;
        private readonly string m_sDetails;

        public ValidationResult(bool bIsValid)
        {
            m_bIsValid = bIsValid;
            m_sDetails = string.Empty;
        }

        public ValidationResult(bool bIsValid, string sDetails)
        {
            m_bIsValid = bIsValid;
            m_sDetails = sDetails ?? string.Empty;
        }

        public bool WasValid()
        {
            return m_bIsValid;
        }

        public string GetDetails()
        {
            return m_sDetails;
        }
    }
}
