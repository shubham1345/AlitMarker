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
using Alit.Marker.WinForm.ERP.Masters.AdditionalItems;
using Alit.Marker.WinForm.ERP.Masters.Transport;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales
{
    public partial class frmSaleDefaultDashboard : Template.frmDashboardTemplate
    {
        public frmSaleDefaultDashboard()
        {
            InitializeComponent();
        }

        protected override GeneralizeReportGeneratorParameters GenerateDashboardPrintParas()
        {
            var paras = base.GenerateDashboardPrintParas();
            paras.Landscape = true;
            return paras;
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Customer.frmCustomerCRUD frm = new Customer.frmCustomerCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnStockItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Inventory.Masters.StockItem.frmStockItemCRUD frm = new Inventory.Masters.StockItem.frmStockItemCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnTransport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ERP.Masters.Transport.frmTransportGridGRUD frm = new frmTransportGridGRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnNewAdditionalDiscountTax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmAdditionalItemCRUD frm = new frmAdditionalItemCRUD())
            {
                frm.ShowDialog();
            }
        }
        private void btnTransactionRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DashboardGridView != null)
            {
                Model.ERP.Transaction.Sales.ISaleTransactionDashboardViewModel Row = (Model.ERP.Transaction.Sales.ISaleTransactionDashboardViewModel)DashboardGridView.GetFocusedRow();
                using (Reports.TransactionReports.frmRepTransactionRegister frm =
                    new Reports.TransactionReports.frmRepTransactionRegister(Row?.CustomerID
                        , (Row != null ? Row.TransactionDate : Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
                        , null))
                {
                    frm.ShowDialog();
                }
            }
        }

        private void btnCustomerBalanceReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Reports.TransactionReports.frmRepCustomerBalanceReport frm =
                new Reports.TransactionReports.frmRepCustomerBalanceReport(Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom, null))
            {
                frm.ShowDialog();
            }
        }       
    }
}
