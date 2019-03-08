using Stenber.Desktop.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenber.Desktop
{
    internal static class InternalExtensions
    {
        internal static Rectangle ToBoundingRectangle(this ExternRect rect)
        {
            var result = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

            return result;
        }

        internal static Rectangle ToBoundingRectangle(this Rectangle rect)
        {
            var result = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

            return result;
        }
    }
}
