using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public interface IAssociationDataPipe
    {
        List<int> CreateAssociations(List<AssociationData> data);
        void DestroyAssociations(List<int> associationIds);
        List<int> GetAssociationIds();
        List<int> GetAssociationIds(List<string> names);
        List<AssociationData> GetAssociations();
        List<AssociationData> GetAssociations(List<int> associationIds);
    }
}
