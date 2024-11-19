using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseBill;
using Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo;
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

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill
{
    public partial class frmPurchaseBillDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPurchaseBillCRUD);
            }
        }

        public frmPurchaseBillDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new PurchaseBillDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnPurchaseReceiptNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmPurchaseReceiptNoPrefixGridCRUD frm = new frmPurchaseReceiptNoPrefixGridCRUD())
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
