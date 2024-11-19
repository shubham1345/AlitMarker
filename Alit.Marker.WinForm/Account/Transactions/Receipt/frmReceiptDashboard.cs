using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using Alit.Marker.DAL.Account.Transactions.Receipt;
using Alit.Marker.WinForm.Template;
using Alit.Marker.WinForm.Account.Transactions.Receipt.ReceiptNoPrefix;

namespace Alit.Marker.WinForm.Account.Transactions.Receipt
{
    public partial class frmReceiptDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmReceiptCRUD);
            }
        }

        public frmReceiptDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new ReceiptDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnReceiptNoPrefix_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmReceiptNoPrefixGridCRUD frm = new frmReceiptNoPrefixGridCRUD())
            {
                frm.ShowDialog(this);
            }
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return GenerateReceiptPrintDocument(PrimeKeyID);
        }

        public static XtraReport GenerateReceiptPrintDocument(long ReceiptID)
        {           
            var report = new Receipt.rptReceiptPrint();
            report.DataSource = new ReceiptPrintDAL().GetReceiptByID(ReceiptID);           
            return report;
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var res = base.GenerateDashboardPrintParas();
            res.Landscape = true;
            return res;
        }
    }
}
