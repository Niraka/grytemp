using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    public interface IApiBuilder
    {
        Api Build(int iApiId, int iApiContextId);
    }
}
