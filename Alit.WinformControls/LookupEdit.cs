using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Drawing;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public class LookUpEdit : DevExpress.XtraEditors.LookUpEdit
    {
        public LookUpEdit()
        {
            EnterMoveNextControl = true;
            Properties.NullText = "Select";
        }

        protected override void OnPopupShown()
        {
            //if(!this.Focused)
            //{
            //    ClosePopup();
            //}
            base.OnPopupShown();
        }

        
    }
}
