using Alit.Marker.DAL.Inventory.Reports;
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
    public partial class frmRepStockInHand : Template.Report.frmGridReportTemplate
    {
        public frmRepStockInHand()
        {
            InitializeComponent();

            ReportDALObj = new StockInHandDAL();

            ReportGridControl = gridControl1;
            ReportGridView = gridView1;
        }

        #region Overriden Methods

        protected override void AssignFormValues()
        {
            deDateFrom.DateTime = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
            deDateTo.DateTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode == false)
            {
                colPCode.Visible = false;
            }
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode == false)
            {
                colBarCode.Visible = false;
            }
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.HSNCode ==false)
            {
                colHSN.Visible = false;
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

            paras.PageHeaderLine2 = Line2;

            return paras;
        }

        DateTime? DateFrom;
        DateTime? DateTo;

        protected override object[] GetReportDataSourceFilterParas()
        {
            DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTo = (DateTime?)deDateTo.EditValue;


            return new object[]
            {
                deDateFrom.EditValue,
                deDateTo.EditValue,
            };
        }

        #endregion

        #region Validation

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
           
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please enter Date From.");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, null);
            }

        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
             if (deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please enter Date To.");
            }
            else if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                ErrorProvider.SetError(deDateTo, "Date To must be greater than Date From.");
            }
            else if (deDateFrom.EditValue != null && DAL.Settings.FinancialPeriod.FinPeriodDAL.IsDateRangeInMultipleFinancialPeriod((DateTime)deDateFrom.EditValue, (DateTime)deDateTo.EditValue))
            {
                ErrorProvider.SetError(deDateTo, "Date range can't cover more than one Financial Period.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, null);
            }
           

        }

        #endregion

        #region Edit Value Changed 
        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                string ErrorTitle = "Invalid date from entered";
                string ErrorDescr = "Date from should be less than date to";

                toolTipController1.ShowHint(new DevExpress.Utils.ToolTipControllerShowEventArgs()
                {
                    IconType = DevExpress.Utils.ToolTipIconType.Information,
                    ToolTipLocation = DevExpress.Utils.ToolTipLocation.BottomCenter,
                    ToolTipType = DevExpress.Utils.ToolTipType.Standard,
                    ToolTip = ErrorDescr,
                    Title = ErrorTitle,
                    ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Object,
                    IconSize = DevExpress.Utils.ToolTipIconSize.Large,
                    Rounded = true,
                    RoundRadius = 12,
                    ShowBeak = true,
                }, deDateFrom);
            }
            else if (deDateTo.EditValue != null)
            {
                ExecuteReloadReportData(true);
            }

        }

        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.EditValue != null && deDateFrom.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                string ErrorTitle = "Invalid Date To entered";
                string ErrorDescr = "Date to should be greater than Date From";

                toolTipController1.ShowHint(new DevExpress.Utils.ToolTipControllerShowEventArgs()
                {
                    IconType = DevExpress.Utils.ToolTipIconType.Information,
                    ToolTipLocation = DevExpress.Utils.ToolTipLocation.BottomCenter,
                    ToolTipType = DevExpress.Utils.ToolTipType.Standard,
                    ToolTip = ErrorDescr,
                    Title = ErrorTitle,
                    ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Object,
                    IconSize = DevExpress.Utils.ToolTipIconSize.Large,
                    Rounded = true,
                    RoundRadius = 12,
                    ShowBeak = true,
                }, deDateTo);
            }
            else if (deDateTo.EditValue != null)
            {
                ExecuteReloadReportData(true);
            }

        }
        #endregion

    }
}
