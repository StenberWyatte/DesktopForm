using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stenber.Desktop.Extensions
{
    public static class PublicExtensions
    {
        public static bool IsFormCovered(this Form form, bool countHiddenOrAbsentAsCovered = true)
        {
            return true;
        }
    }
}
