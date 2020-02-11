using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public interface ILogReader
    {
        List<MessageData> Read(LogFilter filter);
    }
}
