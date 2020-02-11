using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Requirement
{
    interface IRequirementManager
    {
        /// <summary>
        /// Adds a requirement to the requirements manager.
        /// </summary>
        /// <param name="requirement">The requirement to add</param>
        /// <returns>The id of the added requirement, or -1</returns>
        int AddRequirement(IRequirement requirement);

        /// <summary>
        /// Gets a list of requirement descriptors.
        /// </summary>
        /// <returns>A list of requirement descriptors</returns>
        List<RequirementDescriptor> GetRequirementDescriptors();

        /// <summary>
        /// Queries whether all requirements added to the requirements manager are currently met. Any
        /// requirements that are unable to evaluate their success are considered to have failed. Uncaught
        /// exceptions will propagate.
        /// </summary>
        /// <param name="bAbortOnFirstFail">True to abort requirements evaluation at the first unmet
        /// requirement</param>
        /// <returns>An evaluation detailing the successfulness of the query</returns>
        RequirementEvaluation AreRequirementsMet(bool bAbortOnFirstFail);
    }
}
