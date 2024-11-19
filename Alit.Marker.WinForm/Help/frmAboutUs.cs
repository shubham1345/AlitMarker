using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Help
{
    public partial class frmAboutUs : Template.frmNormalTemplate
    {
        public frmAboutUs()
        {
            InitializeComponent();
            barFormFooter.Visible = false;
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
