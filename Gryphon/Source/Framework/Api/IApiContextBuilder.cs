using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    public interface IApiContextBuilder
    {
        ApiContext Build(ApiConfig config);
    }
}
