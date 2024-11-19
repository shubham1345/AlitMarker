using Alit.Marker.DAL.Reports.TransationReports;
using Alit.Marker.Model.Reports.TransationReports;
using Alit.Marker.WinForm.Template;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Reports.TransactionReports
{
    public partial class frmRepCustomerBalanceReport : Template.Report.frmGridReportTemplate
    {
        DateTime? SelectedDateFrom { get; set; }
        DateTime? SelectedDateTo { get; set; }

        public frmRepCustomerBalanceReport() : this(null, null)
        {
        }

        public frmRepCustomerBalanceReport(DateTime? DateFrom, DateTime? DateTo)
        {
            InitializeComponent();

            ReportDALObj = new CustomerBalanceReportDAL();
            SelectedDateFrom = DateFrom;
            SelectedDateTo = DateTo;

            ReportGridControl = gridControl1;
            ReportGridView = gridView1;

            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
            {
                txtSMSTemplate.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SMSCustomerBalanceReportTemplate;
            }
            else
            {
                // i want to keep showing sms feature to motivate users to buy sms packages
                txtSMSTemplate.Enabled = false;
                btnSendSMS.Enabled = false;
            }

            base.AssignFormValues();
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize
                && e.IsTotalSummary
                && ((GridColumnSummaryItem)e.Item).FieldName == colClosingBalance.FieldName)
            {
                e.TotalValue = (decimal)colOpeningBalance.SummaryItem.SummaryValue
                    + (decimal)colSaleAmt.SummaryItem.SummaryValue
                    - (decimal)colSaleReturnAmt.SummaryItem.SummaryValue
                    - (decimal)colPurchaseAmt.SummaryItem.SummaryValue
                    + (decimal)colPurchaseReturnAmt.SummaryItem.SummaryValue
                    - (decimal)colRecieptAmt.SummaryItem.SummaryValue
                    + (decimal)colPaymentAmt.SummaryItem.SummaryValue;
            }
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

        protected override object[] GetReportDataSourceFilterParas()
        {
            return new object[]
            {
                (DateTime?)deDateFrom.EditValue,
                (DateTime?)deDateTo.EditValue,
            };
        }


        private void btnSendSMS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ReportDataSource == null)
            {
                MessageBox.Show("No record found", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var dsReport = ((List<CustomerBalanceReportModel>)ReportDataSource).Where(r => r.Select);
            if (dsReport.Count() == 0)
            {
                MessageBox.Show("Please select records to send sms", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtSMSTemplate.Text))
            {
                MessageBox.Show("Please enter sms template content.", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure\r\nDo you want to send SMS ?", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            ShowWaitForm();

            DateTime CurrentDateTime = DateTime.Now.Date;
            bool? KeepContinueToSensSMSAfterError = null;
            foreach (var repModel in dsReport)
            {
                if (repModel == null || String.IsNullOrWhiteSpace(repModel.CustomerMobileNo) || !repModel.Select)
                {
                    continue;
                }

                string Msg = "";
                Msg = txtSMSTemplate.Text.
                    Replace("«CustomerNameTitle»", repModel.CustomerNameTitle).
                    Replace("«CustomerName»", repModel.CustomerName).
                    Replace("«CustomerNameWithCity»", repModel.CustomerCityStateShortName).
                    Replace("«CustomerNameWithCityAdd»", repModel.CustomerNameWithTitle + " " + repModel.CustomerAddressDetail).
                    Replace("«CustomerCity»", repModel.CustomerCityName).
                    Replace("«CustomerAdd»", repModel.CustomerAddress).

                    Replace("«OpeningBalance»", repModel.OpeningBalance.ToString("#0")).
                    Replace("«SaleAmt»", repModel.SaleAmt.ToString("#0")).
                    Replace("«SaleReturnAmt»", repModel.SaleReturnAmt.ToString("#0")).
                    Replace("«PurchaseAmt»", repModel.PurchaseAmt.ToString("#0")).
                    Replace("«PurchaseReturnAmt»", repModel.PurchaseReturnAmt.ToString("#0")).
                    Replace("«ReceiptAmt»", repModel.RecieptAmt.ToString("#0")).
                    Replace("«PaymentAmt»", repModel.PaymentAmt.ToString("#0")).
                    Replace("«ClosingBalance»", repModel.ClosingBalance.ToString("#0")).
                    Replace("«TodayDate»", CurrentDateTime.ToShortDateString()).
                    Replace("«CurrentTime»", CurrentDateTime.ToShortTimeString()).
                    Replace("«DateFrom»", (deDateFrom.EditValue != null ? ((DateTime)deDateFrom.EditValue).ToShortDateString() : "")).
                    Replace("«UpToDate»", (deDateTo.EditValue != null ? ((DateTime)deDateTo.EditValue).ToShortDateString() : ""));


                if (!SMS.SMSHandler.SendSMS(repModel.CustomerMobileNo
                    , Model.CommonProperties.LoginInfo.SoftwareSettings.SMSCustomerBalanceReportSenderID
                    , Msg
                    , "Balance Report"
                    , Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID) && KeepContinueToSensSMSAfterError == null)
                {
                    CloseWaitForm();
                    if (Alit.WinformControls.MessageBox.Show("There was some problem occurred while sending SMS. Do you want to continue to sending SMS ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        // to prevent to show message box next time if sms sending fails.
                        KeepContinueToSensSMSAfterError = true;
                        ShowWaitForm();
                    }
                }
            }

            CloseWaitForm();
            MessageBox.Show("SMS sent successfully.", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTransactionRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerBalanceReportModel Row = (CustomerBalanceReportModel)ReportGridView.GetFocusedRow();

            if (Row != null)
            {
                using (Reports.TransactionReports.frmRepTransactionRegister frm =
                    new Reports.TransactionReports.frmRepTransactionRegister(Row.CustomerID, deDateFrom.DateTime, deDateTo.DateTime))
                {
                    frm.ShowDialog();
                }
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please enter date from");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, null);
            }
        }
    }
}
