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
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice
{
    public partial class frmSaleInvoiceDashboard : WinForm.ERP.Transaction.Sales.frmSaleDefaultDashboard
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleInvoiceCRUD);
            }
        }

        public frmSaleInvoiceDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new SaleInvoiceDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnSaleInvoiceNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleInvoiceNoPrefixGridCRUD frm = new frmSaleInvoiceNoPrefixGridCRUD())
            {
                frm.ShowDialog(this);
            }
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return GenerateSaleInvoiceReport(PrimeKeyID);
        }

        public static XtraReport GenerateSaleInvoiceReport(long SaleInvoieID)
        {
            var report = InvoiceFormats.InvoiceFormatController.GetSelectedInvoiceFormat();
            report.DataSource = new DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoicePrintDAL().GenerateReportData(SaleInvoieID);
            return report;
        }
    }
}
