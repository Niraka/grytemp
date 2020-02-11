using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public interface IEngineConfigProvider
    {
        /// <summary>
        /// Gets the connection string to the Gryphon master database.
        /// </summary>
        /// <returns>A connection string</returns>
        string GetGryphonConnectionString();

        /// <summary>
        /// Gets a boolean indicating whether or not to skip requirement evaluation entirely. The 
        /// "ignore unmet requirements" and "abort on first unmet requirement" configurations have
        /// no affect when this value is true.
        /// </summary>
        /// <returns>A boolean indicating whether or not to skip requirement evaluation</returns>
        bool ShouldSkipRequirementEvaluation();

        /// <summary>
        /// Gets a boolean indicating whether or not to ignore the result of engine requirement
        /// evaluation. Requirement evaluation still occurs as normal.
        /// </summary>
        /// <returns>A boolean indicating whether or not to ignore engine requirements</returns>
        bool ShouldIgnoreUnmetRequirements();

        /// <summary>
        /// Gets a boolean indicating whether or not to abort requirement evaluation when the first
        /// unmet requirement is encountered. This value is still respected when requirements are
        /// being ignored.
        /// </summary>
        /// <returns>A boolean indicating whether or not to abort requirement evaluation when the
        /// first unmet requirement is encountered</returns>
        bool ShouldAbortOnFirstUnmetRequirement();
    }
}
