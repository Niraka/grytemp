using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Gryphon.Tools;

namespace Gryphon.Framework.Requirement
{
    /// <summary>
    /// Handles storage and evaluation of engine requirements.
    /// </summary>
    class RequirementManager : IRequirementManager
    {
        private const int m_iSemaphoreTimeout = 3000;
        private readonly Semaphore m_semaphore;
        private readonly List<Tuple<int, IRequirement>> m_requirements;
        private int m_iNextRequirementId;

        /// <summary>
        /// Constructs a new requirements manager with the given configuration.
        /// </summary>
        /// <param name="config">The configuration</param>
        public RequirementManager(RequirementManagerConfig config)
        {
            if (config == null)
            {
                config = new RequirementManagerConfig();
            }

            m_requirements = new List<Tuple<int, IRequirement>>();
            m_semaphore = new Semaphore(1, 1);
            m_iNextRequirementId = 0;
        }

        /// <summary>
        /// Adds a requirement to the requirements manager. Null requirements are ignored.
        /// </summary>
        /// <param name="requirement">The requirement to add</param>
        /// <returns>The id of the added requirement, or -1</returns>
        public int AddRequirement(IRequirement requirement)
        {
            if (requirement == null)
            {
                return -1;
            }

            int iId = Interlocked.Increment(ref m_iNextRequirementId);

            if (m_semaphore.WaitOne(m_iSemaphoreTimeout))
            {
                m_requirements.Add(new Tuple<int, IRequirement>(iId, requirement));
                m_semaphore.Release();

                return iId;
            }

            return -1;
        }

        /// <summary>
        /// Gets a list of requirement descriptors.
        /// </summary>
        /// <returns>A list of requirement descriptors</returns>
        public List<RequirementDescriptor> GetRequirementDescriptors()
        {
            List<RequirementDescriptor> descriptors = new List<RequirementDescriptor>();
            if (m_semaphore.WaitOne(m_iSemaphoreTimeout))
            {
                foreach (Tuple<int, IRequirement> requirement in m_requirements)
                {
                    descriptors.Add(requirement.Item2.GetRequirementDescriptor());
                }
                m_semaphore.Release();
            }

            return descriptors;
        }

        /// <summary>
        /// Queries whether all requirements added to the requirements manager are currently met. Any
        /// requirements that are unable to evaluate their success are considered to have failed. Uncaught
        /// exceptions will propagate.
        /// </summary>
        /// <param name="bAbortOnFirstFail">True to abort requirements evaluation at the first unmet
        /// requirement</param>
        /// <returns>An evaluation detailing the successfulness of the query</returns>
        public RequirementEvaluation AreRequirementsMet(bool bAbortOnFirstFail)
        {
            List<IRequirement> requirements = new List<IRequirement>();
            if (m_semaphore.WaitOne(m_iSemaphoreTimeout))
            {
                foreach (Tuple<int, IRequirement> requirement in m_requirements)
                {
                    requirements.Add(requirement.Item2);
                }
                m_semaphore.Release();
            }

            List<string> details = new List<string>();
            int iNumRequirementsEvaluated = 0;
            if (bAbortOnFirstFail)
            {
                foreach (IRequirement requirement in requirements)
                {
                    ++iNumRequirementsEvaluated;
                    RequirementEvaluation evaluation = requirement.IsRequirementMet();
                    if (!evaluation.HasPassed())
                    {
                        details.AddRange(evaluation.GetDetails());
                        return new RequirementEvaluation(
                            requirements.Count,
                            iNumRequirementsEvaluated,
                            iNumRequirementsEvaluated - 1,
                            details);
                    }

                    details.AddRange(evaluation.GetDetails());
                }

                return new RequirementEvaluation(
                    requirements.Count,
                    iNumRequirementsEvaluated,
                    iNumRequirementsEvaluated,
                    details);
            }
            else
            {
                int iNumRequirementsMet = 0;
                foreach (IRequirement requirement in requirements)
                {
                    ++iNumRequirementsEvaluated;
                    RequirementEvaluation evaluation = requirement.IsRequirementMet();
                    if (evaluation.HasPassed())
                    {
                        ++iNumRequirementsMet;
                    }

                    details.AddRange(evaluation.GetDetails());
                }

                return new RequirementEvaluation(
                    requirements.Count,
                    iNumRequirementsEvaluated,
                    iNumRequirementsMet,
                    details);
            }
        }
    }
}