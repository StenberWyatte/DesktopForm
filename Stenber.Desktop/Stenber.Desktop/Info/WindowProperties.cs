using Stenber.Desktop.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stenber.Desktop.Info
{
    public sealed class WindowProperties
    {
        public IntPtr Handle { get; private set; }

        public string Title { get; private set; }

        public bool IsVisible { get; private set; }

        public bool IsIconic { get; private set; }

        public bool HasExtendedWindowsStyles { get; private set; }

        public uint WindowThreadProcessId { get; private set; }

        public Rectangle RestoredPosition { get; private set; }

        public Rectangle CurrentPosition { get; private set; }

        public WindowState WindowState { get; private set; }

        public bool IsDisplayed
        {
            get
            {
                return this.IsVisible &&
                       this.CurrentPosition.Width != 0 &&
                       this.CurrentPosition.Height != 0;
            }
        }

        public WindowProperties(Form form) : this(form != null ? form.Handle : throw new ArgumentNullException("form")) { }

        internal WindowProperties(IntPtr handle)
        {
            this.Handle = handle;
            this.Refresh();
        }

        public void Refresh()
        {
            this.Title = WindowInfo.WindowTitle(this.Handle);
            this.IsVisible = WindowInfo.IsVisible(this.Handle);
            this.IsIconic = WindowInfo.IsIconic(this.Handle);
            this.HasExtendedWindowsStyles = WindowInfo.HasExtendedWindowsStyles(this.Handle);
            this.WindowThreadProcessId = WindowInfo.WindowThreadProcessId(this.Handle);

            this.CurrentPosition = WindowInfo.WindowRectangle(this.Handle);

            var placement = WindowInfo.WindowPlacement(this.Handle);

            this.RestoredPosition = placement.rcNormalPosition.ToBoundingRectangle();
            this.WindowState = placement.showCmd;
        }
    }
}
