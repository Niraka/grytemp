using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class CustomEngineConfigurationProvider : IEngineConfigProvider
    {
        private readonly string m_sGryphonConnectionString;
        private readonly bool m_bShouldAbortOnFirstUnmetRequirement;
        private readonly bool m_bShouldIgnoreUnmentRequirements;
        private readonly bool m_bShouldSkipRequirementEvaluation;

        public CustomEngineConfigurationProvider(string sGryphonConnectionString,
            bool bShouldAbortOnFirstUnmetRequirement,
            bool bShouldIgnoreUnmentRequirements,
            bool bShouldSkipRequirementEvaluation)
        {
            m_sGryphonConnectionString = sGryphonConnectionString;
            m_bShouldAbortOnFirstUnmetRequirement = bShouldAbortOnFirstUnmetRequirement;
            m_bShouldIgnoreUnmentRequirements = bShouldIgnoreUnmentRequirements;
            m_bShouldSkipRequirementEvaluation = bShouldSkipRequirementEvaluation;
        }

        public string GetGryphonConnectionString()
        {
            return m_sGryphonConnectionString;
        }

        public bool ShouldAbortOnFirstUnmetRequirement()
        {
            return m_bShouldAbortOnFirstUnmetRequirement;
        }

        public bool ShouldIgnoreUnmetRequirements()
        {
            return m_bShouldIgnoreUnmentRequirements;
        }

        public bool ShouldSkipRequirementEvaluation()
        {
            return m_bShouldSkipRequirementEvaluation;
        }
    }
}
