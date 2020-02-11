using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class ReleaseEngineConfigurationProvider : IEngineConfigProvider
    {
        public string GetGryphonConnectionString()
        {
            return "Data Source = DESKTOP - L2B8N96; Integrated Security = True; Initial Catalog = GRYPHON; Connection Timeout = 2";
        }

        public bool ShouldAbortOnFirstUnmetRequirement()
        {
            return true;
        }

        public bool ShouldIgnoreUnmetRequirements()
        {
            return false;
        }

        public bool ShouldSkipRequirementEvaluation()
        {
            return false;
        }
    }
}
