using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Component
{
    public interface IEngineComponentDescriptorValidator
    {
        Tools.ValidationResult Validate(EngineComponentDescriptor descriptor);
    }
}
