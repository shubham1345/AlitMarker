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
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;
using Alit.Marker.WinForm.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder
{
    public partial class frmSaleOrderDashboard : Template.frmDashboardTemplate
    {

        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleOrderCRUD);
            }
        }

        public frmSaleOrderDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new SaleOrderDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleOrderNoPrefixGridCRUD frm = new frmSaleOrderNoPrefixGridCRUD())
            {
                frm.ShowDialog();
            }
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return GenerateSaleOrderPrintDocument(PrimeKeyID);
        }

        public static XtraReport GenerateSaleOrderPrintDocument(long SaleOrderID)
        {
            var report = new ERP.Transaction.Sales.SaleOrder.rptSaleOrderA4();
            report.DataSource = new DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderPrintDAL().GenerateReportData(SaleOrderID);
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
