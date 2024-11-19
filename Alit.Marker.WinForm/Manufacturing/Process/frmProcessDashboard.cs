using Alit.Marker.DAL.Manufacturing.Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Manufacturing.Process
{
    public partial class frmProcessDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmProcessCRUD);
            }
        }
        public frmProcessDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new ProcessDAL();

            DashboardGridControl = gridControlProcess;
            DashboardGridView = gridViewProcess;

            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode)
            {
                colPCode.Visible = false;
            }
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode)
            {
                colBarcode.Visible = false;
            }
        }

        private void btnProductFormula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Formula.frmProductFormulaCRUD frm = new Formula.frmProductFormulaCRUD())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
