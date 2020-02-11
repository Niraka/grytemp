using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class AssociationManager
    {
        private readonly IAssociationValidator m_associationValidator;

        public AssociationManager(IAssociationManagerConfigProvider configProvider)
        {
            if (configProvider != null)
            {
                m_associationValidator = configProvider.GetAssociationValidator();
            }
            else
            {
                m_associationValidator = null;
            }
        }

        public List<int> CreateAssociations(IAssociationDataPipe pipe, List<AssociationDetails> associationDetails)
        {
            List<AssociationData> associationDatas = new List<AssociationData>(associationDetails.Count);
            foreach (AssociationDetails detail in associationDetails)
            {
                if (m_associationValidator != null)
                {
                    bool bResult = m_associationValidator.IsValid(detail);
                    if (!bResult)
                    {
                        associationDatas.Add(null);
                        continue;
                    }
                }

                AssociationData data = new AssociationData();
                data.Id = -1;
                data.Name = detail.GetName();
                associationDatas.Add(data);
            }

            List<int> ids = pipe.CreateAssociations(associationDatas);
            if (ids.Count != associationDetails.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public void DestroyAssociations(IAssociationDataPipe pipe, List<int> associationIds)
        {
            pipe.DestroyAssociations(associationIds);
        }
        
        public List<int> GetAssociationIds(IAssociationDataPipe pipe, List<string> associationNames)
        {
            if (associationNames == null)
            {
                return pipe.GetAssociationIds();
            }
            else
            {
                return pipe.GetAssociationIds(associationNames);
            }
        }
        
        public List<Association> GetAssociations(IAssociationDataPipe pipe, List<int> associationIds)
        {
            List<AssociationData> associationDatas = null;
            if (associationIds == null)
            {
                associationDatas = pipe.GetAssociations();
            }
            else
            {
                associationDatas = pipe.GetAssociations(associationIds);
                if (associationDatas.Count != associationIds.Count)
                {
                    throw new Exception();
                }
            }

            List<Association> associations = new List<Association>(associationDatas.Count);
            foreach (AssociationData data in associationDatas)
            {
                associations.Add(new Association(data.Id, data.Name));
            }

            return associations;
        }
    }
}
