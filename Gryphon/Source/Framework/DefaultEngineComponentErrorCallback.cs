using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework
{
    public class DefaultEngineComponentErrorCallback : IEngineComponentErrorCallback
    {
        public void OnEngineComponentError(string sErrorMessage)
        {
            // Just throw the error away by default.
        }
    }
}
