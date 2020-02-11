using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Tools
{
    public class ProcessResult : IProcessResult
    {
        private readonly bool m_bWasSuccessful;
        private readonly List<string> m_details;

        public ProcessResult()
        {
            m_bWasSuccessful = false;
            m_details = new List<string>();
        }

        public ProcessResult(bool bWasSuccessful)
        {
            m_bWasSuccessful = bWasSuccessful;
            m_details = new List<string>();
        }

        public ProcessResult(bool bWasSuccessful, List<string> details)
        {
            m_bWasSuccessful = bWasSuccessful;
            m_details = details ?? new List<string>();
        }

        public bool WasSuccessful()
        {
            return m_bWasSuccessful;
        }

        public List<string> GetDetails()
        {
            return m_details;
        }
    }
}
