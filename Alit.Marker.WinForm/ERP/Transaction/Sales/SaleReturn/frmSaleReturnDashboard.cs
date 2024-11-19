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
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
using Alit.Marker.WinForm.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn
{
    public partial class frmSaleReturnDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleReturnCRUD);
            }
        }

        public frmSaleReturnDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new SaleReturnDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnSRNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleReturnNoPrefixGridCRUD frm = new frmSaleReturnNoPrefixGridCRUD())
            {
                frm.ShowDialog();
            }
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return GenerateSaleReturnPrintDocument(PrimeKeyID);
        }

        public static XtraReport GenerateSaleReturnPrintDocument(long SaleReturnID)
        {
            var reprot = new WinForm.ERP.Transaction.Sales.SaleReturn.rptSaleReturnA4();
            reprot.DataSource = new DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnPrintDAL().GenerateReportData(SaleReturnID);
            return reprot;
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var res = base.GenerateDashboardPrintParas();
            res.Landscape = true;
            return res;
        }
    }
}
