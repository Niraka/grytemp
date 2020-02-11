using System.Collections.Generic;

namespace Gryphon.Framework.Requirement
{
    /// <summary>
    /// A requirement evaluation contains information about the evaluation of one or more 
    /// requirements.
    /// </summary>
    public class RequirementEvaluation
    {
        private readonly int m_iNumRequirementsTargeted;
        private readonly int m_iNumRequirementsEvaluated;
        private readonly int m_iNumRequirementsMet;
        private readonly List<string> m_details;

        /// <summary>
        /// Constructs a default requirement evaluation.
        /// </summary>
        public RequirementEvaluation()
        {
            m_iNumRequirementsTargeted = -1;
            m_iNumRequirementsEvaluated = -1;
            m_iNumRequirementsMet = -1;
            m_details = new List<string>();
        }

        /// <summary>
        /// Constructs a requirement evaluation with the given parameters.
        /// </summary>
        /// <param name="iNumRequirementsTargeted">The number of requirements that would be evaluated if all
        /// requirements were evaluated</param>
        /// <param name="iNumRequirementsEvaluated">The number of requirements that were evaluated</param>
        /// <param name="iNumRequirementsMet">The number of requirements that were met</param>
        /// <param name="details">A list of details associated with the evaluation</param>
        public RequirementEvaluation(int iNumRequirementsTargeted, int iNumRequirementsEvaluated, 
            int iNumRequirementsMet, List<string> details)
        {
            m_iNumRequirementsTargeted = iNumRequirementsTargeted;
            m_iNumRequirementsEvaluated = iNumRequirementsEvaluated;
            m_iNumRequirementsMet = iNumRequirementsMet;
            m_details = details ?? new List<string>();
        }

        /// <summary>
        /// Gets the number of requirements that would be evaluated if all requirements were evaluated.
        /// </summary>
        /// <returns>The number of requirements that would be evaluated if all requirements were evaluted</returns>
        public int GetNumRequirementsTargeted()
        {
            return m_iNumRequirementsTargeted;
        }

        /// <summary>
        /// Gets the number of requirements that were evaluated.
        /// </summary>
        /// <returns>The number of requirements that were evaluated</returns>
        public int GetNumRequirementsEvaluated()
        {
            return m_iNumRequirementsEvaluated;
        }

        /// <summary>
        /// Gets the number of requirements that were met.
        /// </summary>
        /// <returns>The number of requirements that were met</returns>
        public int GetNumRequirementsMet()
        {
            return m_iNumRequirementsMet;
        }

        /// <summary>
        /// Queries whether the requirement evaluation is considered to have passed or not.
        /// </summary>
        /// <returns>True if the requirement evaluation passed, false if it failed</returns>
        public bool HasPassed()
        {
            return m_iNumRequirementsTargeted == m_iNumRequirementsMet;
        }

        /// <summary>
        /// Gets a list of associated details. Details are stored in no particular order.
        /// </summary>
        /// <returns>A list of details associated with the evaluation</returns>
        public List<string> GetDetails()
        {
            return m_details;
        }
    }
}
