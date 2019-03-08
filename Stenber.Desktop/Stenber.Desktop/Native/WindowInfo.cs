using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Stenber.Desktop;

namespace Stenber.Desktop.Native
{
    internal static class WindowInfo
    {
        internal static bool IsCloaked(IntPtr hwnd)
        {
            Methods.DwmGetWindowAttribute(hwnd, DwmWindowAttribute.Cloaked, out bool isCloaked, Marshal.SizeOf(typeof(bool)));

            return isCloaked;
        }

        internal static bool IsVisible(IntPtr hwnd)
        {
            return Methods.IsWindowVisible(hwnd);
        }

        internal static bool IsIconic(IntPtr hwnd)
        {
            return Methods.IsIconic(hwnd);
        }

        internal static bool HasExtendedWindowsStyles(IntPtr hwnd)
        {
            uint result = Methods.GetWindowLong(hwnd, Constants.GwlExStyle);

            return (result & Constants.WsExToolWindow) != 0;
        }

        internal static string WindowTitle(IntPtr hwnd)
        {
            var windowTextSize = Methods.GetWindowTextLength(hwnd);

            var sb = new StringBuilder(windowTextSize + 1);

            Methods.GetWindowText(hwnd, sb, sb.Capacity);

            return sb.ToString();
        }

        internal static uint WindowThreadProcessId(IntPtr hwnd)
        {
            Methods.GetWindowThreadProcessId(hwnd, out uint result);

            return result;
        }

        internal static IntPtr[] WindowHandles()
        {
            var result = new List<IntPtr>();

            var filter = new EnumWindowsProc((IntPtr hwnd, int lParam) =>
            {
                var title = WindowTitle(hwnd);

                if (!string.IsNullOrWhiteSpace(title)) result.Add(hwnd);

                return true;
            });

            Methods.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);

            return result.ToArray();
        }

        internal static WindowPlacement WindowPlacement(IntPtr hwnd)
        {
            var placement = new WindowPlacement();
            placement.length = Marshal.SizeOf(placement);

            Methods.GetWindowPlacement(hwnd, ref placement);

            return placement;
        }

        internal static Rectangle WindowRectangle(IntPtr hwnd)
        {
            Methods.GetWindowRect(hwnd, out ExternRect rect);

            return rect.ToBoundingRectangle();
        }

        internal static IntPtr GetWorkerWHandle()
        {
            var progman = Methods.FindWindow("progman", null);

            var workHandle = IntPtr.Zero;

            Methods.SendMessageTimeout(progman, 0x052C, new IntPtr(0), IntPtr.Zero, SendMessageTimeoutFlags.Normal, 1000, out workHandle);

            var filter = new EnumWindowsProc((tophandle, topparamhandle) =>
            {
                var p = Methods.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", string.Empty);

                if (p != IntPtr.Zero) workHandle = Methods.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", string.Empty);

                return true;
            });

            Methods.EnumWindows(filter, IntPtr.Zero);

            return workHandle;
        }

        // TODO: Research WH_KEYBOARD_LL and WH_MOUSE_LL (hooks)
        internal static IntPtr SetFormParent(IntPtr formHandle, IntPtr parentHandle)
        {
            // Returns the old parent
            var result = Methods.GetParent(formHandle);

            Methods.SetParent(formHandle, parentHandle);

            return result;
        }

        // TODO: Find home for RefreshDesktop
    }
}
