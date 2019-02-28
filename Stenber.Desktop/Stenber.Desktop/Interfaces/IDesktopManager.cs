using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenber.Desktop.Interfaces
{
    public interface IDesktopManager
    {
        bool IsDesktopFormCovered { get; }

        void Reset();

        void RefreshDesktop();
    }
}
