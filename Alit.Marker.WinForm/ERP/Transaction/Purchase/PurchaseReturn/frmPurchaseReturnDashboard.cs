using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseReturn;
using Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.WinForm.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn
{
    public partial class frmPurchaseReturnDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPurchaseReturnCRUD);
            }
        }

        public frmPurchaseReturnDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new PurchaseReturnDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnPurchaseReturnNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmPurchaseReturnNoPrefixGridCRUD frm = new frmPurchaseReturnNoPrefixGridCRUD())
            {
                frm.ShowDialog(this);
            }
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var res = base.GenerateDashboardPrintParas();
            res.Landscape = true;
            return res;
        }
    }
}
