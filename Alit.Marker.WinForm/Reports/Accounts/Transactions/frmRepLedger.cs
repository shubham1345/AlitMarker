using Alit.Marker.DAL.Reports.Accounts.Transactions;
using Alit.Marker.Model.Reports.Accounts.Transactions;
using Alit.Marker.WinForm.Template.Report;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Alit.Marker.WinForm.Reports.Accounts.Transactions
{
    public partial class frmRepLedger : frmGridReportTemplate
    {
        List<LedgerReportViewModel> dsLedger;

        public frmRepLedger(long AccountID)
        {
            InitializeComponent();

            ReportDALObj = new LedgerReportDAL();
            ReportGridControl = gridControl1;
            ReportGridView = gridView1;

            lookupEditAccount1.EditValue = AccountID;
        }

        #region Methods
        protected override void AssignFormValues()
        {
            deDateTo.DateTime = DateTime.Now.Date;
            deDateFrom.DateTime = deDateTo.DateTime.AddDays(-30);
            base.AssignFormValues();
        }

        protected override void AssignLookupDataSource()
        {
            lookupEditAccount1.AssignDataSource();
            base.AssignLookupDataSource();
        }

        protected override void LoadLookupDataSource()
        {
            lookupEditAccount1.LoadDataSource();
            base.LoadLookupDataSource();
        }

        DateTime? DateFrom;
        DateTime? DateTo;
        string AccountName;

        protected override object[] GetReportDataSourceFilterParas()
        {
            DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTo = (DateTime?)deDateTo.EditValue;
            AccountName = lookupEditAccount1.Text;

            //if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            //{
            //    return null;
            //}

            return new object[]
            {
                lookupEditAccount1.EditValue,
                deDateFrom.EditValue,
                deDateTo.EditValue,
            };
        }

        protected override GeneralizeReportGeneratorParameters GenerateReportPrintParas()
        {
            var paras = base.GenerateReportPrintParas();
            paras.PageHeaderLine2 = null;

            if (!string.IsNullOrWhiteSpace(AccountName))
            {
                paras.PageHeaderLine2 += (!string.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "\r\n" : "")
                    + "Account : " + AccountName;
            }
            if (DateFrom != null)
            {
                paras.PageHeaderLine2 += (!string.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? "\r\n" : "")
                    + "From " + DateFrom.Value.ToShortDateString();
            }
            if (DateTo != null)
            {
                paras.PageHeaderLine2 += (!string.IsNullOrWhiteSpace(paras.PageHeaderLine2) ? (DateFrom == null ? "\r\n" : "") : "")
                    + (DateFrom != null ? " To " : "Up to ") + DateTo.Value.ToShortDateString();
            }

            return paras;
        }

        #endregion

        #region Events

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsGroupSummary && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                GridGroupSummaryItem item = e.Item as GridGroupSummaryItem;
                if (item != null && gridControl1.DataSource != null && item.FieldName == "Balance")
                {
                    e.TotalValue = e.FieldValue;
                }
            }
        }

        private void lookupEditAccount1_EditValueChanged(object sender, EventArgs e)
        {
            ExecuteReloadReportData();
        }

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
            else
            {
                ExecuteReloadReportData();
            }
        }

        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                string ErrorTitle = "Invalid date to entered";
                string ErrorDescr = "Date to should be greater than date from";

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
            else
            {
                ExecuteReloadReportData();
            }
        }

        #endregion

        #region Validation

        private void lookupEditAccount1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccount1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditAccount1, "Please select Account.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditAccount1, null);
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                ErrorProvider.SetError(deDateFrom, "Date From should be less than Date To.");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, null);
            }
        }    
        #endregion
    }
}
