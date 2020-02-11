using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    internal interface ILocaleModuleConfigProvider
    {
        ITextDefinitionDetailsValidator GetTextDefinitionDetailsValidator();
        ITextValidator GetTextValidator();
    }
}
