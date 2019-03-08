using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenber.Desktop.Native
{
    [Flags]
    internal enum SendMessageTimeoutFlags : uint
    {
        Normal = 0x0,
        Block = 0x1,
        AbortIfHung = 0x2,
        NoTimeOutIfNotHung = 0x8,
        ErrorOnExit = 0x20
    }

    internal enum WindowStateCommands
    {
    }
}
