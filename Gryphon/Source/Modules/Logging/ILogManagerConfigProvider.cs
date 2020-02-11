﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public interface ILogManagerConfigProvider
    {
        IMessageValidator GetMessageValidator();
        IMessageParser GetMessageParser();
    }
}