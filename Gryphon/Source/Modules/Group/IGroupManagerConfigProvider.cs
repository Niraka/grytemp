using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Group
{
    public interface IGroupManagerConfigProvider
    {
        IGroupDescriptorValidator GetGroupDescriptorValidator();
    }
}
