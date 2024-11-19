using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.WinformControls
{
    [Browsable(true)]
    [ToolboxItem(true)]
    public class myLayoutControl : DevExpress.XtraLayout.LayoutControl
    {
        public myLayoutControl()
        {
            this.OptionsView.HighlightFocusedItem = true;
        }
    }
}
