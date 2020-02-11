using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gryphon.Modules.Locale
{
    internal class LocaleModule
    {
        private readonly ITextDefinitionDetailsValidator m_textDefinitionDetailsValidator;
        private readonly ITextValidator m_textValidator;
        private readonly List<int> m_localeIds;
        private readonly Dictionary<string, int> m_localeIdsByName;
        private readonly Dictionary<int, LocaleDefinition> m_localesById;

        public LocaleModule(ILocaleModuleConfigProvider configProvider)
        {
            TextDefinition a = new TextDefinition(1, "title", "title for thing");
            TextDefinitionDetails b = new TextDefinitionDetails("title", "title for thing");
            a.GetId();

            if (configProvider == null)
            {
                throw new Exception();
            }

            m_textDefinitionDetailsValidator = configProvider.GetTextDefinitionDetailsValidator();
            m_textValidator = configProvider.GetTextValidator();

            if (m_textDefinitionDetailsValidator == null)
            {
                throw new Exception();
            }
            if (m_textValidator == null)
            {
                throw new Exception();
            }

            m_localeIds = new List<int>();
            m_localeIdsByName = new Dictionary<string, int>();
            m_localesById = new Dictionary<int, LocaleDefinition>();

            List<LocaleDefinition> localeDefinitions = new List<LocaleDefinition>()
            {
                new LocaleDefinition(0, "english", "en-GB", "english", "English (United Kingdom)"),
                new LocaleDefinition(1, "american", "en-US", "english", "English (United States)"),
                new LocaleDefinition(2, "canadian", "en-CA", "english", "English (Canada)"),
                new LocaleDefinition(3, "indian", "en-IN", "english", "English (India)"),
                new LocaleDefinition(4, "australian", "en-AU", "english", "English (Australia)"),
                new LocaleDefinition(5, "new-zealand", "en-NZ", "english", "English (New Zealand)"),
                new LocaleDefinition(6, "south-african", "en-ZA", "english", "English (South Africa)"),
                new LocaleDefinition(7, "french", "fr-FR", "french", "Français (France)"),
                new LocaleDefinition(8, "french-canadian", "fr-CA", "french", "Français (Canada)"),
                new LocaleDefinition(9, "french-luxembourgish", "fr-LU", "french", "Français (Luxembourg)"),
                new LocaleDefinition(10, "chinese", "zh-CN", "chinese", "中文 (中国)"),
                new LocaleDefinition(11, "chinese-taiwan", "zh-TW", "chinese", "中文 (台湾)"),
                new LocaleDefinition(12, "chinese-hong-kong", "zh-HK", "chinese", "中文 (中国香港特别行政区)"),
                new LocaleDefinition(13, "dutch-belgian", "nl-BE", "dutch", "Nederlands (België)"),
                new LocaleDefinition(14, "dutch", "nl-NL", "dutch", "Nederlands (Nederland)"),
                new LocaleDefinition(15, "german-austrian", "de-AT", "german", "Deutsch (Österreich)"),
                new LocaleDefinition(15, "german", "de-DE", "german", "Deutsch (Deutschland)"),
                new LocaleDefinition(16, "italian", "it-IT", "italian", "Italiano (Italia)"),
                new LocaleDefinition(17, "portuguese", "pt-PT", "portuguese", "Português (Portugal)"),
                new LocaleDefinition(18, "portuguese-brazillian", "pt-BR", "portuguese", "Português (Brasil)"),
                new LocaleDefinition(19, "spanish", "es-ES", "spanish", "Español (España)"),
                new LocaleDefinition(20, "spanish-mexican", "es-MX", "spanish", "Español (México)"),
                new LocaleDefinition(21, "spanish-argentine", "es-AR", "spanish", "Español (Argentina)"),
                new LocaleDefinition(22, "spanish-colombian", "es-CO", "spanish", "Español (Colombia)"),
                new LocaleDefinition(23, "spanish-chilean", "es-CL", "spanish", "Español (Chile)"),
                new LocaleDefinition(24, "spanish-peruvian", "es-PE", "spanish", "Español (Perú)"),
                new LocaleDefinition(25, "spanish-venezuelan", "es-VE", "spanish", "Español (Venezuela)"),
                new LocaleDefinition(26, "spanish-dominican", "es-DO", "spanish", "Español (República Dominicana)"),
                new LocaleDefinition(27, "swedish-finland", "sv-FI", "swedish", "Svenska (Finland)"),
                new LocaleDefinition(28, "swedish", "sv-SE", "swedish", "Svenska (Sverige)"),
            };

            foreach (LocaleDefinition definition in localeDefinitions)
            {
                m_localeIds.Add(definition.GetId());
                m_localeIdsByName.Add(definition.GetName(), definition.GetId());
                m_localesById.Add(definition.GetId(), definition);
            }
        }

        public Task<List<int>> GetLocaleIds(List<string> localeNames)
        {
            List<int> ids = new List<int>();
            foreach (string sName in localeNames)
            {
                int iTempId;
                if (m_localeIdsByName.TryGetValue(sName, out iTempId))
                {
                    ids.Add(iTempId);
                }
                else
                {
                    ids.Add(-1);
                }
            }
            return Task.FromResult<List<int>>(ids);
        }

        public Task<List<int>> GetLocaleIds()
        {
            List<int> ids = new List<int>();
            ids.AddRange(m_localeIds);
            return Task.FromResult<List<int>>(ids);
        }

        public Task<List<LocaleDefinition>> GetLocales(List<int> localeIds)
        {
            List<LocaleDefinition> definitions = new List<LocaleDefinition>();
            foreach (int iLocaleId in localeIds)
            {
                LocaleDefinition definition;
                if (m_localesById.TryGetValue(iLocaleId, out definition))
                {
                    definitions.Add(definition);
                }
                else
                {
                    definitions.Add(null);
                }
            }
            return Task.FromResult<List<LocaleDefinition>>(definitions);
        }

        public async Task<List<int>> MergeTexts(ITextDataPipe pipe, List<Text> texts)
        {
            List<TextData> textDatas = new List<TextData>();
            foreach (Text text in texts)
            {
                Tools.ValidationResult result = m_textValidator.IsValid(text);
                if (result.WasValid())
                {
                    TextData data = new TextData();
                    data.TextId = text.GetTextId();
                    data.LocaleId = text.GetLocaleId();
                    data.Value = text.GetValue();
                    textDatas.Add(data);
                }
                else
                {
                    textDatas.Add(null);
                }
            }

            List<int> ids = await pipe.MergeTexts(textDatas);
            if (ids.Count != texts.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public async Task<List<int>> MergeTextDefinitions(int iContextId, ITextDataPipe pipe, List<TextDefinitionDetails> textDefinitions)
        {
            List<TextDefinitionData> textDefinitionDetails = new List<TextDefinitionData>();
            foreach (TextDefinitionDetails definitionDetails in textDefinitions)
            {
                Tools.ValidationResult result = m_textDefinitionDetailsValidator.IsValid(definitionDetails);
                if (result.WasValid())
                {
                    TextDefinitionData data = new TextDefinitionData();
                    data.Id = -1;
                    data.ContextId = iContextId;
                    data.Name = definitionDetails.GetName();
                    data.Description = definitionDetails.GetDescription();
                    textDefinitionDetails.Add(data);
                }
                else
                {
                    textDefinitionDetails.Add(null);
                }
            }

            List<int> ids = await pipe.MergeTextDefinitions(textDefinitionDetails);
            if (ids.Count != textDefinitions.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public Task<List<int>> GetTextIds(int iContextId, ITextDataPipe pipe)
        {
            return pipe.GetTextIds(iContextId);
        }

        public async Task<List<int>> GetTextIds(int iContextId, ITextDataPipe pipe, List<string> textNames)
        {
            List<int> ids = await pipe.GetTextIds(iContextId, textNames);
            if (ids.Count != textNames.Count)
            {
                throw new Exception();
            }

            return ids;
        }

        public async Task<List<TextDefinition>> GetTextDefinitions(ITextDataPipe pipe, List<int> textIds)
        {
            List<TextDefinitionData> textDefinitionDatas = await pipe.GetTextDefinitions(textIds);
            if (textDefinitionDatas.Count != textIds.Count)
            {
                throw new Exception();
            }

            List<TextDefinition> textDefinitions = new List<TextDefinition>();
            foreach (TextDefinitionData definitionData in textDefinitionDatas)
            {
                if (definitionData == null)
                {
                    textDefinitions.Add(
                        new TextDefinition(
                            definitionData.Id,
                            definitionData.Name,
                            definitionData.Description));
                }
                else
                {
                    textDefinitions.Add(null);
                }
            }

            return textDefinitions;
        }

        public async Task<List<Text>> GetTexts(ITextDataPipe pipe, List<int> textIds, List<int> localeIds)
        {
            List<TextData> textDatas = await pipe.GetTexts(textIds, localeIds);
            if (textDatas.Count != (textIds.Count * localeIds.Count))
            {
                throw new Exception();
            }
            
            List<Text> texts = new List<Text>();
            foreach (TextData data in textDatas)
            {
                if (data == null)
                {
                    texts.Add(new Text(data.TextId, data.LocaleId, data.Value));
                }
                else
                {
                    texts.Add(null);
                }
            }

            return texts;
        }

        public Task DestroyTexts(ITextDataPipe pipe, List<int> textIds)
        {
            return pipe.DestroyTexts(textIds);
        }

        public Task DestroyTexts(ITextDataPipe pipe, List<int> textIds, List<int> localeIds)
        {
            return pipe.DestroyTexts(textIds, localeIds);
        }

        public Task DestroyTextDefinitions(ITextDataPipe pipe, List<int> textIds)
        {
            return pipe.DestroyTextDefinitions(textIds);
        }
    }
}
