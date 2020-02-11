using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public interface IEngineComponentErrorCallback
    {
        void OnEngineComponentError(string sErrorMessage);
    }
}
