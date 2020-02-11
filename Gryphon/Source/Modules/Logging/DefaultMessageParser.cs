using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Logging
{
    public class DefaultMessageParser : IMessageParser
    {
        public IMessage Parse(MessageData data)
        {
            return new GenericMessage(
                data.MessageTypeId, 
                data.MessageText, 
                data.AssociationId);
        }
    }
}
