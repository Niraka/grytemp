using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Group
{
    public interface IGroupDescriptorValidator
    {
        bool IsValid(GroupDescriptorDetails details);
    }
}
