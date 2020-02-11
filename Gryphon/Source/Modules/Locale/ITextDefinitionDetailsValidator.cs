using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    internal interface ITextDefinitionDetailsValidator
    {
        Tools.ValidationResult IsValid(TextDefinitionDetails details);
    }
}
