using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenber.Desktop.Native
{
    internal delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

    internal delegate bool EnumWindowsProcIntPtr(IntPtr hWnd, IntPtr lParam);
}
