using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.UpdateMaster
{
    public partial class frmdbScriptEditor : DevExpress.XtraEditors.XtraForm
    {
        public string dbScript { get; set; }

        public frmdbScriptEditor(string dbScript_) : this()
        {
            memoEdit1.Text = dbScript_;
        }
        public frmdbScriptEditor()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if(e.Button.Properties.Caption == "Save")
            {
                dbScript = memoEdit1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
