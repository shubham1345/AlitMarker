using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public class myTokenEdit : DevExpress.XtraEditors.TokenEdit
    {
        public myTokenEdit()
        {
            EnterMoveNextControl = true;
        }
        protected override void OnEnter(EventArgs e)
        {
            SendKeys.SendWait("{End}");
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            TabStop = true;
        }
    }
}
