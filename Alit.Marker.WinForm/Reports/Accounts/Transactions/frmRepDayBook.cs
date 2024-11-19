using Alit.Marker.DAL.Reports.Accounts.Transactions;
using Alit.Marker.WinForm.Template;
using Alit.Marker.WinForm.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Reports.Accounts.Transactions
{
    public partial class frmRepDayBook : frmGridReportTemplate
    {
        public frmRepDayBook()
        {
            InitializeComponent();

            ReportDALObj = new DayBookReportDAL();
            ReportGridControl = gridControl1;
            ReportGridView = gridView1;
        }

        #region Methods
        protected override void AssignFormValues()
        {
            deDateFrom.DateTime = DateTime.Now.Date;
            deDateTo.DateTime = DateTime.Now.Date;
            base.AssignFormValues();
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

        protected override GeneralizeReportGeneratorParameters GenerateReportPrintParas()
        {
            var paras = base.GenerateReportPrintParas();
            paras.PageHeaderLine2 = null;

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
            else if (deDateFrom.EditValue != null && deDateTo.EditValue != null)
            {
                ExecuteReloadReportData(true);
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
            else if (deDateFrom.EditValue != null && deDateTo.EditValue != null)
            {
                ExecuteReloadReportData(true);
            }
        }

        #region Validation
        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please select Date From.");
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
                ErrorProvider.SetError(deDateTo, "Please select Date To.");
            }
            else if (deDateFrom.EditValue != null && deDateTo.EditValue != null && deDateFrom.DateTime.Date > deDateTo.DateTime.Date)
            {
                ErrorProvider.SetError(deDateTo, "Date To must be greater than Date From.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, null);
            }
        }
        #endregion
    }
}
