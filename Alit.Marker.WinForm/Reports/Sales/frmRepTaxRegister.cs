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
using Alit.Marker.DAL.Reports.Sales;
using Alit.Marker.Model.Reports.Sales;

namespace Alit.Marker.WinForm.Reports.Sales
{
    public partial class frmRepTaxRegister : Reports.Template.frmReportTemplate
    {
        public frmRepTaxRegister()
        {
            InitializeComponent();

            deDateFrom.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;

            if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo != null)
            {
                deDateTo.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo;
            }
            else
            {
                deDateTo.EditValue = (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom < DateTime.Now.Date ? DateTime.Now.Date :
                    CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom);
            }
        }

        public override void GenerateReport(GenerateReportParameter Paras, ref XtraReport ReportSource)
        {
            Paras.GenerateReportResult = new Model.GenerateReportResult();

            TaxRegisterReportDAL SInvDAL = new DAL.Reports.Sales.TaxRegisterReportDAL();

            List<TaxRegisterReportModel> ReportDS = null;

            ReportDS = SInvDAL.GenerateReportData(deDateFrom.DateTime, deDateTo.DateTime);

            ReportSource = new Reports.Sales.rptTaxRegister();
            if (ReportDS.Count > 0)
            {
                ReportSource.DataSource = ReportDS;

                Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.CommitedSucessfuly;
            }
            else
            {
                Paras.GenerateReportResult.ExecutionResult = Model.eExecutionResult.ValidationError;
                Paras.GenerateReportResult.ValidationError = "No record found to print";
            }

            DateTime? DateFrom = (DateTime?)deDateFrom.EditValue;
            DateTime? DateTo = (DateTime?)deDateTo.EditValue;

            this.ReportTitle = "";
            if (DateFrom != null && DateTo != null)
            {
                this.ReportTitle = "From " + DateFrom.Value.ToShortDateString() + " To " + DateTo.Value.ToShortDateString();
            }
            else if (DateFrom != null)
            {
                this.ReportTitle = "From " + DateFrom.Value.ToShortDateString();
            }
            else if (DateTo != null)
            {
                this.ReportTitle = "Up to " + DateTo.Value.ToShortDateString();
            }
            else
            {
                this.ReportTitle = "";
            }
            this.ReportTitle = "Tax Register " + this.ReportTitle;


            base.GenerateReport(Paras, ref ReportSource);
        }

        private void dtDateTo_Validating(object sender, CancelEventArgs e)
        {
            if(deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date To must by greater than or equal to date from.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }
    }
}
