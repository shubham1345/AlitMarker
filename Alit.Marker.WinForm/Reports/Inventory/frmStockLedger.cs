using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model;
using DevExpress.XtraReports.UI;
using Alit.Marker.DAL.Reports.Inventory;
using Alit.Marker.Model.Reports.Inventory;

namespace Alit.Marker.WinForm.Reports.Inventory
{
    public partial class frmStockLedger : Template.frmReportTemplate
    {
        StockLedgerDAL DALObject;
        DAL.Product.ProductDAL ProductDALObj;
        object dsProduct;

        public frmStockLedger()
        {
            InitializeComponent();
            FirstControl = lookupProduct;
            DALObject = new StockLedgerDAL();
            ProductDALObj = new DAL.Product.ProductDAL();
        }

        public override void AssignFormValues()
        {
            dtpDateFrom.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
            if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo != null && DateTime.Now.Date > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
            {
                dtpDateTo.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            else
            {
                dtpDateTo.EditValue = DateTime.Now.Date;
            }

            base.AssignFormValues();
        }

        public override void LoadLookupDataSource()
        {
            dsProduct = ProductDALObj.GetLookupList_WithoutStock(); 
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupProduct.Properties.ValueMember = "ProductID";
            lookupProduct.Properties.DisplayMember = "ProductName";
            lookupProduct.Properties.DataSource = dsProduct;

            base.AssignLookupDataSource();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetFocusOnFirstControl();
        }

        public override void GenerateReport(GenerateReportParameter Paras, ref XtraReport ReportSource)
        {
            Paras.GenerateReportResult = new Model.GenerateReportResult();

            this.ReportTitle = "Stock Ledger ";
            if (dtpDateFrom.EditValue != null)
            {
                this.ReportTitle += " From " + ((DateTime)dtpDateFrom.EditValue).ToString("dd'-'MM'-'yyyy");
            }
            if (dtpDateTo.EditValue != null)
            {
                this.ReportTitle += " To " + ((DateTime)dtpDateTo.EditValue).ToString("dd'-'MM'-'yyyy");
            }

            IEnumerable<long> SelectedProductIDs = null;
            if (lookupProduct.EditValue != null)
            {
                SelectedProductIDs = new List<long>() { (long)lookupProduct.EditValue };

                IEnumerable<StockLedgerReportModel> ReportDS = DALObject.GetReportData(SelectedProductIDs,
                    (DateTime?)dtpDateFrom.EditValue, (DateTime?)dtpDateTo.EditValue);
                if (ReportDS.Count() > 0)
                {
                    ReportSource = new Reports.Inventory.rptStockLedger();
                    ReportSource.DataSource = ReportDS;
                    Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.CommitedSucessfuly;
                }
                else
                {
                    Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
                    Paras.GenerateReportResult.ValidationError = "No record found to print";
                }
            }
            else
            {
                Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
                Paras.GenerateReportResult.ValidationError = "No Product selected";
            }
            //if (lookupProductView.SelectedRowsCount > 0)
            //{
            //    SelectedProductIDs = lookupProductView.GetSelectedRows().Select(r => ((Model.Product.ProductLookupListModel_WithoutSizeAndStock)lookupProductView.GetRow(r)).ProductID);

            //    IEnumerable<StockLedgerReportModel> ReportDS = DALObject.GetReportData(SelectedProductIDs,
            //        (DateTime?)dtpDateFrom.EditValue, (DateTime?)dtpDateTo.EditValue, txtlblSizeFilter.Text);
            //    if (ReportDS.Count() > 0)
            //    {
            //        ReportSource = new Reports.Inventory.rptStockLedger();
            //        ReportSource.DataSource = ReportDS;
            //        Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.CommitedSucessfuly;
            //    }
            //    else
            //    {
            //        Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
            //        Paras.GenerateReportResult.ValidationError = "No record found to print";
            //    }
            //}
            //else
            //{
            //    Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
            //    Paras.GenerateReportResult.ValidationError = "No Product selected";
            //}

            base.GenerateReport(Paras, ref ReportSource);
        }
    }
}
