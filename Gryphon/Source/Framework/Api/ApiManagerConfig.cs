using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    public class ApiManagerConfig
    {
        private readonly IApiContextBuilder m_apiContextBuilder;
        private readonly IApiBuilder m_apiBuilder;

        public ApiManagerConfig(IApiBuilder apiBuilder, IApiContextBuilder apiContextBuilder)
        {
            m_apiBuilder = apiBuilder;
            m_apiContextBuilder = apiContextBuilder;
        }

        public IApiBuilder GetApiBuilder()
        {
            return m_apiBuilder;
        }
        
        public IApiContextBuilder GetApiContextBuilder()
        {
            return m_apiContextBuilder;
        }
    }
}
