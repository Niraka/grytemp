using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    internal interface ITextValidator
    {
        Tools.ValidationResult IsValid(Text text);
    }
}
