using Alit.Marker.DAL.Customer;
using Alit.Marker.DAL.CashBank;
using Alit.Marker.Model;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.CashBank;
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

namespace Alit.Marker.WinForm.CashBank
{
    public partial class frmPayment : Template.frmCRUDTemplate
    {
        PaymentDAL DALObject;
        CustomerDAL CustomerDAL;
        List<ReceiptPaymentTypeViewModel> lookupPaymentTypeDS;
        object dsCustomer;

        public frmPayment()
        {
            InitializeComponent();
            FirstControl = lookupCustomer;
            DALObject = new PaymentDAL();
            CustomerDAL = new CustomerDAL();


            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPayment)
            {
                chkbSendSMS.Checked = false;
                lcgSMS.DataBindings.Add("Enabled", chkbSendSMS, "Checked");
            }
            else
            {
                chkbSendSMS.Checked = false;
                chkbSendSMS.Visible = false;
                lcgSMSParent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        public override void LoadLookupDataSource()
        {
            lookupPaymentTypeDS = new List<ReceiptPaymentTypeViewModel>();
            lookupPaymentTypeDS.Add(new ReceiptPaymentTypeViewModel() { PaymentTypeID = 1, PaymentTypeName = "Cash" });
            lookupPaymentTypeDS.Add(new ReceiptPaymentTypeViewModel() { PaymentTypeID = 2, PaymentTypeName = "Bank" });

            LoadCustomerLookupDataSource();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupPaymentType.Properties.ValueMember = "PaymentTypeID";
            lookupPaymentType.Properties.DisplayMember = "PaymentTypeName";
            lookupPaymentType.Properties.DataSource = lookupPaymentTypeDS;

            AssignCustomerLookupDataSource();

            base.AssignLookupDataSource();
        }

        void LoadCustomerLookupDataSource()
        {
            dsCustomer = CustomerDAL.GetLookUpList();
        }
        void AssignCustomerLookupDataSource()
        {
            lookupCustomer.Properties.ValueMember = "CustomerID";
            lookupCustomer.Properties.DisplayMember = "CustomerName";
            lookupCustomer.Properties.DataSource = dsCustomer;
        }

        public override void AssignFormValues()
        {

            if (DateTime.Now.Date < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
            {
                dtpPaymentDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.Date;
            }
            else if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue && DateTime.Now.Date > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value)
            {
                dtpPaymentDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            else
            {
                dtpPaymentDate.EditValue = DateTime.Now.Date;
            }
            //--

            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPayment)
            {
                txtSMSSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentSenderID;
                memoSMS.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentTemplate;
            }

            base.AssignFormValues();
        }

        public override void InitializeDefaultValues()
        {
            txtPaymentNo.Text = DALObject.GetNextPaymentNo().ToString();
            lookupPaymentType.EditValue = 1;

            base.InitializeDefaultValues();
        }


        public override void ClearValues()
        {
            chkbSendSMS.Checked = false;

            string SMSSenderID = txtSMSSenderID.Text;
            string SMSTemplate = memoSMS.Text;

            base.ClearValues();

            txtSMSSenderID.Text = SMSSenderID;
            memoSMS.Text = SMSTemplate;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblPayment SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblPayment();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((PaymentEditListModel)EditRecordDataSource).PaymentID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            long RecNo = 0;
            long.TryParse(txtPaymentNo.Text, out RecNo);
            SaveModel.PaymentNo = RecNo;

            SaveModel.PaymentDate = (DateTime)dtpPaymentDate.EditValue;
            SaveModel.CustomerID = (long)lookupCustomer.EditValue;
            SaveModel.PaymentType = (int)lookupPaymentType.EditValue;
            SaveModel.BankName = txtBankName.Text;
            SaveModel.BankBranchName = txtBranchName.Text;
            SaveModel.ChequeNo = txtChequeNo.Text;

            decimal Amt = 0;
            decimal.TryParse(txtAmount.Text, out Amt);
            SaveModel.Amount = Amt;

            SaveModel.Remarks = txtRemarks.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);



            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice && chkbSendSMS.Checked)
            {
                Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(SaveModel.CustomerID);
                string Msg = "";
                Msg = memoSMS.Text.
                    Replace("«PaymentNo»", SaveModel.PaymentNo.ToString()).
                    Replace("«PaymentDate»", SaveModel.PaymentDate.ToShortDateString()).
                    Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
                    Replace("«CustomerName»", Customer.CustomerNameWithTitle).
                    Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
                    Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
                    Replace("«CustomerCity»", Customer.CustomerCityName).
                    Replace("«CustomerAdd»", Customer.CustomerAddress).
                    Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
                    Replace("«PaymentType»", (((Model.CashBank.eModeOfPayment)SaveModel.PaymentType) == eModeOfPayment.Cash ? "Cash" : "Bank")).
                    Replace("«PaymentAmt»", SaveModel.Amount.ToString());

                SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Payment", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
            }
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                LoadCustomerLookupDataSource();
                AssignCustomerLookupDataSource();
            }
            base.AfterSaving(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FormatEditListGridView(GridView EditListGrid)
        {
            EditListGrid.Columns["PaymentDate"].MaxWidth = 100;
            EditListGrid.Columns["PaymentNo"].MaxWidth = 100;
            EditListGrid.Columns["PaymentMode"].MaxWidth = 100;

            EditListGrid.Columns["Amount"].MaxWidth = 150;
            EditListGrid.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EditListGrid.Columns["Amount"].DisplayFormat.FormatString = "{0:n2}";

            base.FormatEditListGridView(EditListGrid);
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblPayment EditingRecord = DALObject.FindSaveModelByPrimeKey(((PaymentEditListModel)RecordToFill).PaymentID);

            txtPaymentNo.Text = EditingRecord.PaymentNo.ToString();
            dtpPaymentDate.EditValue = EditingRecord.PaymentDate;
            lookupCustomer.EditValue = EditingRecord.CustomerID;
            lookupPaymentType.EditValue = EditingRecord.PaymentType;

            txtBankName.Text = EditingRecord.BankName;
            txtBranchName.Text = EditingRecord.BankBranchName;
            txtChequeNo.Text = EditingRecord.ChequeNo;

            txtAmount.EditValue = null;
            txtAmount.EditValue = EditingRecord.Amount.ToString();
            txtRemarks.EditValue = EditingRecord.Remarks;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((PaymentEditListModel)EditRecordDataSource).PaymentID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((PaymentEditListModel)EditRecordDataSource).PaymentID);
            base.DeleteRecord(Paras);
        }

        private void txtPaymentNo_Validating(object sender, CancelEventArgs e)
        {
            long RecNo = 0;
            long.TryParse(txtPaymentNo.Text ?? "0", out RecNo);

            if (RecNo == 0)
            {
                ErrorProvider.SetError(txtPaymentNo, "Can not accept blank or zero as Payment No.");
            }
            //else if (DALObject.IsDuplicateRecord(RecNo, (FormCurrentUI == eFormCurrentUI.Edit ? ((PaymentEditListModel)EditRecordDataSource).PaymentID : 0)))
            //{
            //    ErrorProvider.SetError(txtPaymentNo, "Can not accept duplicate Payment No.");
            //}
            else
            {
                ErrorProvider.SetError(txtPaymentNo, "");
            }
        }

        private void dtpPaymentDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpPaymentDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpPaymentDate, "Payment date is required.");
            }
            else
            {
                DateTime dt = (DateTime)dtpPaymentDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(dtpPaymentDate, "date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? " upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : ""));
                }
                else
                {
                    ErrorProvider.SetError(dtpPaymentDate, "");
                }
            }
        }

        private void lookupCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (lookupCustomer.EditValue == null)
            {
                ErrorProvider.SetError(lookupCustomer, "Please select customer.");
            }
            else
            {
                ErrorProvider.SetError(lookupCustomer, "");
            }
        }

        private void lookupPaymentType_Validating(object sender, CancelEventArgs e)
        {
            if (lookupPaymentType.EditValue == null)
            {
                ErrorProvider.SetError(lookupPaymentType, "Please select payment Mode.");
            }
            else
            {
                ErrorProvider.SetError(lookupPaymentType, "");
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            decimal Amt = 0;
            if (!decimal.TryParse(txtAmount.Text, out Amt))
            {
                ErrorProvider.SetError(txtAmount, "Invalid value not accepted as amount. Please enter numeric value.");
            }
            else if (Amt == 0)
            {
                ErrorProvider.SetError(txtAmount, "Amount is required");
            }
            else
            {
                ErrorProvider.SetError(txtAmount, "");
            }
        }

        private void lookupCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupCustomer.EditValue != null && (long)lookupCustomer.EditValue != -1)
            {
                CustomerLookUpListModel SelectedCustomer = (CustomerLookUpListModel)lookupCustomer.GetSelectedDataRow();
                if (SelectedCustomer != null)
                {
                    txtCustomerBalance.EditValue = DAL.Customer.CustomerBalanceDAL.GetBalance(SelectedCustomer.CustomerID);
                    txtSMSMobileNos.Text = SelectedCustomer.MobileNo;
                    chkbSendSMS.EditValue = SelectedCustomer.AllowSendSMS;
                }
                else
                {
                    chkbSendSMS.EditValue = false;
                }
            }
        }

        private void txtSMS_SenderID_Validating(object sender, CancelEventArgs e)
        {
            if (chkbSendSMS.Checked && txtSMSSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMSSenderID, "SMS sender id must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMSSenderID, "");
            }
        }

        private void txtSMSMobileNos_Validating(object sender, CancelEventArgs e)
        {
            if (chkbSendSMS.Checked && txtSMSMobileNos.Text.Length == 0)
            {
                ErrorProvider.SetError(txtSMSMobileNos, "Please enter mobile number.");
            }
            else
            {
                ErrorProvider.SetError(txtSMSMobileNos, "");
                //--
                string[] Nos = txtSMSMobileNos.Text.Split(',');
                foreach (string No in Nos)
                {
                    if (No.Trim().Length != 10)
                    {
                        ErrorProvider.SetError(txtSMSMobileNos, "Mobile No(s) should entered in 10 digits. Invalid mobile numbers are not accepted.");
                    }
                }
            }
        }

        private void lookupPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupPaymentType.EditValue != null && ((eModeOfPayment)lookupPaymentType.EditValue) == eModeOfPayment.Bank)
            {
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}
