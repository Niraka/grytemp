using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Api
{
    class ApiBuilder : IApiBuilder
    {
        private Modules.Logging.Module m_loggingModule;

        public ApiBuilder()
        {
            m_loggingModule = null;
        }

        public void LinkApiSource(Modules.Logging.Module module)
        {
            m_loggingModule = module;
        }

        public Api Build(int iApiId, int iApiContextId)
        {
            Logging.Api loggingApi = new Logging.Api();
            Database.Api databaseApi = new Database.Api(string.Empty, iApiContextId);
            return new Api(iApiId, loggingApi, databaseApi);
        }
    }
}
