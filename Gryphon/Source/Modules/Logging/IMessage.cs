using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public interface IMessage
    {
        string GetMessageText();
        DateTime? GetOccurredOn();
        int GetMessageTypeId();
        int GetAssociationId();
    }
}
