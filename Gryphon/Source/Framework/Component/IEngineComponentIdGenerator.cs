using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public interface IEngineComponentIdGenerator
    {
        EngineComponentId GenerateId();
    }
}
