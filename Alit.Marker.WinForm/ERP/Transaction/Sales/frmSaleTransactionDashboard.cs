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
using Alit.Marker.WinForm.ERP.Masters.Transport;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn;
using Alit.Marker.Model.ERP.Transaction.Sales;
using Alit.Marker.DAL.ERP.Transaction.Sales;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales
{
    public partial class frmSaleTransactionDashboard : frmSaleDefaultDashboard
    {

        public override Type CrudFormType
        {
            get
            {
                if (DashboardGridView == null)
                {
                    return typeof(frmSaleInvoiceCRUD);
                }
                else
                {
                    SaleTransactionDashboardViewModel Row = (SaleTransactionDashboardViewModel)DashboardGridView.GetFocusedRow();
                    if (Row == null)
                    {
                        return typeof(frmSaleInvoiceCRUD);
                    }
                    else
                    {
                        switch (Row.RecordType)
                        {
                            case eSaleTransactionDashboardRecordType.SaleInvoice:
                                return typeof(frmSaleInvoiceCRUD);

                            case eSaleTransactionDashboardRecordType.SaleReturn:
                                return typeof(frmSaleReturnCRUD);

                            case eSaleTransactionDashboardRecordType.SaleOrder:
                                return typeof(frmSaleOrderCRUD);

                            default:
                                return typeof(frmSaleInvoiceCRUD);
                        }
                    }
                }
            }
        }


        public frmSaleTransactionDashboard()
        {
            InitializeComponent();


            DashboardDALObj = new SaleTransactionDashboardDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnCountry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (City.Country.frmCountryGridCRUD frmCountry = new City.Country.frmCountryGridCRUD())
            {
                frmCountry.ShowDialog(this);
            }
        }
        private void btnState_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (City.State.frmStateGridCRUD frmState = new City.State.frmStateGridCRUD())
            {
                frmState.ShowDialog(this);
            }
        }

        private void btnCity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (City.City.frmCityGridCrud form = new City.City.frmCityGridCrud())
            {
                form.ShowDialog(this);
            }
        }

        private void btnTransport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ERP.Masters.Transport.frmTransportGridGRUD form = new frmTransportGridGRUD())
            {
                form.ShowDialog(this);
            }
        }

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNewSaleInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleInvoiceCRUD frm = new frmSaleInvoiceCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnNewSaleOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleOrderCRUD frm = new frmSaleOrderCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnNewSaleReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSaleReturnCRUD frm = new frmSaleReturnCRUD())
            {
                frm.ShowDialog();
            }
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            if (DashboardGridView != null)
            {
                SaleTransactionDashboardViewModel Row = (SaleTransactionDashboardViewModel)DashboardGridView.GetFocusedRow();
                if (Row != null)
                {
                    switch(Row.RecordType)
                    {
                        case eSaleTransactionDashboardRecordType.SaleInvoice:
                            return frmSaleInvoiceDashboard.GenerateSaleInvoiceReport(PrimeKeyID);
                        case eSaleTransactionDashboardRecordType.SaleReturn:
                            return frmSaleReturnDashboard.GenerateSaleReturnPrintDocument(PrimeKeyID);
                        case eSaleTransactionDashboardRecordType.SaleOrder:
                            return frmSaleOrderDashboard.GenerateSaleOrderPrintDocument(PrimeKeyID);
                    }
                }
            }

            return base.GeneratePrintDocument(PrimeKeyID);
        }
    }
}
