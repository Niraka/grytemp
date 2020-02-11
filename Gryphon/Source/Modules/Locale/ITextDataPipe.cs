using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Locale
{
    public interface ITextDataPipe
    {
        Task<List<int>> MergeTexts(List<TextData> texts);
        Task<List<int>> MergeTextDefinitions(List<TextDefinitionData> textDefinitions);
        Task<List<int>> GetTextIds(int iContextId);
        Task<List<int>> GetTextIds(int iContextId, List<string> textNames);
        Task<List<TextDefinitionData>> GetTextDefinitions(List<int> textIds);
        Task<List<TextData>> GetTexts(List<int> textIds, List<int> localeIds);
        Task DestroyTexts(List<int> textIds);
        Task DestroyTexts(List<int> textIds, List<int> localeIds);
        Task DestroyTextDefinitions(List<int> textIds);
    }
}
