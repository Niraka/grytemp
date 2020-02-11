using System;
using System.Collections.Generic;
using System.Text;
using Gryphon.Tools;

namespace Gryphon.Framework.Component
{
    public class EngineComponentDescriptorValidator : IEngineComponentDescriptorValidator
    {
        public ValidationResult Validate(EngineComponentDescriptor descriptor)
        {
            return new ValidationResult(true);
        }
    }
}
