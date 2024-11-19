using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.WinformControls
{
    [Browsable(true)]
    [ToolboxItem(true)]
    public class TextEdit : DevExpress.XtraEditors.TextEdit
    {
        public TextEdit()
        {
            EnterMoveNextControl = true;
        }
    }
}
