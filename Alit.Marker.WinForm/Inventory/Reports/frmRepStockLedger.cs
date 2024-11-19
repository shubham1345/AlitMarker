using Alit.Marker.DAL.Reports.Inventory;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.WinForm.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Inventory.Reports
{
    public partial class frmRepStockLedger : Template.Report.frmGridReportTemplate
    {
        long ProductID;
        StockItemDetailViewModel SelectedProduct;
        DateTime? SelectedDateFrom { get; set; }
        DateTime? SelectedDateTo { get; set; }

        DAL.Inventory.Masters.StockItem.StockItemDAL StockItemDALObj;

        public frmRepStockLedger() : this(0, null, null)
        {
        }

        public frmRepStockLedger(long productID, DateTime? DateFrom, DateTime? DateTo)
        {
            InitializeComponent();

            ReportDALObj = new StockLedgerDAL();
            StockItemDALObj = new DAL.Inventory.Masters.StockItem.StockItemDAL();

            ProductID = productID;
            SelectedDateFrom = DateFrom;
            SelectedDateTo = DateTo;

            ReportGridControl = gridControl1;
            ReportGridView = gridView1;
        }

        #region Overriden Methods

        protected override void LoadFormValues()
        {
            SelectedProduct = StockItemDALObj.GetDetailViewModelByPrimeKey(ProductID);

            base.LoadFormValues();
        }

        protected override void AssignFormValues()
        {
            if (SelectedDateFrom == null)
            {
                deDateFrom.DateTime = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
            }
            else
            {
                deDateFrom.DateTime = SelectedDateFrom.Value;
            }

            if (SelectedDateTo == null)
            {
                deDateTo.DateTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            }
            else
            {
                deDateTo.DateTime = SelectedDateTo.Value;
            }

            base.AssignFormValues();
        }

        protected override GeneralizeReportGeneratorParameters GenerateReportPrintParas()
        {
            var paras = base.GenerateReportPrintParas();
            //paras.Landscape = false;
            DateTime? DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTime? DateTo = (DateTime?)deDateTo.EditValue;

            string Line2 = "";
            if (DateFrom != null || DateTo != null)
            {
                if (DateFrom != null)
                {
                    Line2 += "From " + DateFrom.Value.ToShortDateString();
                }
                if (DateTo != null)
                {
                    Line2 += (DateFrom != null ? " to " : "Up to ") + DateTo.Value.ToShortDateString();
                }
            }
            if(SelectedProduct != null)
            {
                Line2 += (!string.IsNullOrWhiteSpace(Line2) ? "\r\n" : "") + "Product : " 
                    + (Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode ? SelectedProduct.PCode.ToString() + ", " : "")
                    + SelectedProduct.ProductName
                    + (!String.IsNullOrWhiteSpace(SelectedProduct.UnitName) ? SelectedProduct.UnitName : "");
            }

            paras.PageHeaderLine2 = Line2;

            return paras;
        }

        protected override object[] GetReportDataSourceFilterParas()
        {
            return new object[]
            {
                ProductID,
                (DateTime?)deDateFrom.EditValue,
                (DateTime?)deDateTo.EditValue,
            };
        }

        #endregion

        #region Validation

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please enter Date From");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, null);
            }
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime > deDateTo.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date To must be equal or greater than Date From.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, null);
            }
        }

        #endregion

    }
}
