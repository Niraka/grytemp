using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Requirement
{
    /// <summary>
    /// Defines the necessary functionality for an object to become an engine requirement.
    /// </summary>
    public interface IRequirement
    {
        /// <summary>
        /// Queries whether a requirement is met.
        /// </summary>
        /// <returns>An evaluation detailing the successfulness of the query</returns>
        RequirementEvaluation IsRequirementMet();
        
        /// <summary>
        /// Gets a descriptor for the requirement.
        /// </summary>
        /// <returns>A descriptor for the requirement</returns>
        RequirementDescriptor GetRequirementDescriptor();
    }
}
