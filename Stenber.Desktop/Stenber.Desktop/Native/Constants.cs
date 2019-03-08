using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenber.Desktop.Native
{
    internal static class Constants
    {
        internal const uint SetDesktopWallpaper = 0x14;

        internal const uint SendWindowsIniChange = 0x02;

        internal const uint GetDesktopWallpaper = 0x73;

        internal const int MaxPath = 260;

        internal const int GwlExStyle = -20;

        internal const uint WsExToolWindow = 0x80U;

        internal const int SchneAssocChanged = 0x8000000;

        internal const int SchnfFlush = 0x1000;
    }
}
