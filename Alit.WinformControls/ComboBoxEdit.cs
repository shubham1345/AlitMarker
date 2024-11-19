using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public class ComboBoxEdit : DevExpress.XtraEditors.ComboBoxEdit
    {
        public ComboBoxEdit()
        {
            EnterMoveNextControl = true;
        }
    }
}
