using Alit.Marker.DAL.Customer;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Customer;
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
using Alit.Marker.Model;
using Alit.Marker.Model.CashBank;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Account.Transactions.Payment;
using Alit.Marker.DAL.Account.Transactions.Payment;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.VoucherType;

namespace Alit.Marker.WinForm.Account.Transactions.Payment
{
    public partial class frmPaymentCRUD : Template.frmCRUDTemplate
    {
        PaymentDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new PaymentDAL();
                }

                return DALObject;
            }
        }
        
        AccountDAL AccountDAL;
        long AccountVoucherID;

        List<VoucherTypeLookUpListModel> dsVoucherType;

        public frmPaymentCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmPaymentCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            FirstControl = lookupEditCustomerAccount;
            DALObject = new PaymentDAL();
            AccountDAL = new AccountDAL();

            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPayment)
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

        #region Overriden Methods
        
        protected override void OnAssignFormValues()
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
            
            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPayment)
            {
                txtSMSSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentSenderID;
                memoSMS.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentTemplate;
            }

            AssignVoucherType();

            base.OnAssignFormValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            txtPaymentNo.EditValue = DALObject.GetNextPaymentNo();
            cmbModeOfPayment.SelectedIndex = 0;

            base.OnInitializeDefaultValues();
        }
        
        protected override void OnClearValues()
        {
            chkbSendSMS.Checked = false;

            string SMSSenderID = txtSMSSenderID.Text;
            string SMSTemplate = memoSMS.Text;

            base.OnClearValues();

            txtSMSSenderID.Text = SMSSenderID;
            memoSMS.Text = SMSTemplate;
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new PaymentViewModel()
            {
                PaymentID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PaymentNo = (long)txtPaymentNo.EditValue,

                PaymentDate = (DateTime)dtpPaymentDate.EditValue,
                CustomerAccountID = (long)lookupEditCustomerAccount.EditValue,
                PaymentMode = (Model.CashBank.eModeOfPayment)cmbModeOfPayment.SelectedIndex,
                BankName = txtBankName.Text,
                BankBranchName = txtBranchName.Text,
                ChequeNo = txtChequeNo.Text,
                Amount = (decimal)txtAmount.EditValue,
                Remarks = txtRemarks.Text,
                CashBankAccountID = (long)lookupEditCashBankAccount.EditValue,
                VoucherTypeID = (long)lookupEditVoucherType1.EditValue,
                AccountVoucherID = AccountVoucherID,
            };
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            //if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            //{
            //    LoadCustomerLookupDataSource();
            //    AssignCustomerLookupDataSource();
            //}

            //if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly &&
            //    CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice && chkbSendSMS.Checked)
            //{
            //    Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(SaveModel.CustomerID);
            //    string Msg = "";
            //    Msg = memoSMS.Text.
            //        Replace("«PaymentNo»", SaveModel.PaymentNo.ToString()).
            //        Replace("«PaymentDate»", SaveModel.PaymentDate.ToShortDateString()).
            //        Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
            //        Replace("«CustomerName»", Customer.CustomerNameWithTitle).
            //        Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
            //        Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
            //        Replace("«CustomerCity»", Customer.CustomerCityName).
            //        Replace("«CustomerAdd»", Customer.CustomerAddress).
            //        Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
            //        Replace("«PaymentType»", (((Model.CashBank.eModeOfPayment)SaveModel.PaymentType) == eModeOfPayment.Cash ? "Cash" : "Bank")).
            //        Replace("«PaymentAmt»", SaveModel.Amount.ToString());

            //    SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Payment", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
            //}
            base.OnAfterSaving(Paras);
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            PaymentViewModel EditingRecord = (PaymentViewModel)RecordToFill;

            txtPaymentNo.EditValue = EditingRecord.PaymentNo;
            dtpPaymentDate.EditValue = EditingRecord.PaymentDate;
            lookupEditCustomerAccount.EditValue = EditingRecord.CustomerAccountID;
            cmbModeOfPayment.SelectedIndex = (int)EditingRecord.PaymentMode;
            txtAmount.EditValue = EditingRecord.Amount;
            lookupEditCashBankAccount.EditValue = EditingRecord.CashBankAccountID;

            txtBankName.Text = EditingRecord.BankName;
            txtBranchName.Text = EditingRecord.BankBranchName;
            txtChequeNo.Text = EditingRecord.ChequeNo;
            txtRemarks.EditValue = EditingRecord.Remarks;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Methods

        void AssignVoucherType()
        {
            dsVoucherType = ((List<VoucherTypeLookUpListModel>)lookupEditVoucherType1.Properties.DataSource).ToList();
            if (dsVoucherType != null)
            {
                if (dsVoucherType.Count == 1)
                {
                    lcgVoucherType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lookupEditVoucherType1.EditValue = dsVoucherType.FirstOrDefault().VoucherTypeID;
                }
                else if (dsVoucherType.Count > 0)
                {
                    lookupEditVoucherType1.EditValue = dsVoucherType.FirstOrDefault().VoucherTypeID;
                }
            }
        }

        #endregion

        #region Events

        private void lookupEditAccount1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditCustomerAccount.EditValue != null && (long)lookupEditCustomerAccount.EditValue != -1)
            {
                AccountLookUpListModel SelectedCustomer = (AccountLookUpListModel)lookupEditCustomerAccount.GetSelectedDataRow();
                if (SelectedCustomer != null)
                {
                    txtCustomerBalance.EditValue = DAL.Customer.CustomerBalanceDAL.GetBalance(SelectedCustomer.AccountID);
                    txtSMSMobileNos.Text = SelectedCustomer.MobileNo;
                    chkbSendSMS.EditValue = SelectedCustomer.AllowSendSMS;
                }
                else
                {
                    chkbSendSMS.EditValue = false;
                }
            }
        }

        private void cmbModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModeOfPayment.SelectedIndex >= 0 && ((eModeOfPayment)cmbModeOfPayment.SelectedIndex) == eModeOfPayment.Bank)
            {
                lookupEditCashBankAccount.AccountGroupType = new eAccountGroupType[] { eAccountGroupType.BankAccounts };
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                lookupEditCashBankAccount.EditValue = null;
                lciCashBankAccount.Text = "Bank Account";

            }
            else
            {
                lookupEditCashBankAccount.AccountGroupType = new eAccountGroupType[] { eAccountGroupType.CashInHand };
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lookupEditCashBankAccount.EditValue = null;
                lciCashBankAccount.Text = "Cash Account";
            }
            lookupEditCashBankAccount.ReloadDataSource();
        }
        #endregion

        #region Validation
        private void txtPaymentNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPaymentNo.EditValue == null || (long)txtPaymentNo.EditValue == 0)
            {
                ErrorProvider.SetError(txtPaymentNo, "Please enter Payment No.");
            }
            else if (DALObject.IsDuplicateRecord((long)txtPaymentNo.EditValue, 
                (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPaymentNo, "Can not accept duplicate Payment No.");
            }
            else
            {
                ErrorProvider.SetError(txtPaymentNo, null);
            }
        }

        private void dtpPaymentDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpPaymentDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpPaymentDate, "Payment Date is required.");
            }
            else
            {
                DateTime dt = (DateTime)dtpPaymentDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(dtpPaymentDate, "Date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? " upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : ""));
                }
                else
                {
                    ErrorProvider.SetError(dtpPaymentDate, null);
                }
            }
        }
        
        private void lookupEditAccount1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditCustomerAccount.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditCustomerAccount, "Please select Customer.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditCustomerAccount, null);
            }
        }

        private void cmbModeOfPayment_Validating(object sender, CancelEventArgs e)
        {
            if (cmbModeOfPayment.SelectedIndex < 0)
            {
                ErrorProvider.SetError(cmbModeOfPayment, "Please select Payment Mode.");
            }
            else
            {
                ErrorProvider.SetError(cmbModeOfPayment, null);
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (txtAmount.EditValue == null || (decimal)txtAmount.EditValue == 0)
            {
                ErrorProvider.SetError(txtAmount, "Please enter Amount.");
            }
            else
            {
                ErrorProvider.SetError(txtAmount, null);
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
                ErrorProvider.SetError(txtSMSSenderID, null);
            }
        }

        private void txtSMSMobileNos_Validating(object sender, CancelEventArgs e)
        {
            if (chkbSendSMS.Checked && txtSMSMobileNos.Text.Length == 0)
            {
                ErrorProvider.SetError(txtSMSMobileNos, "Please enter Mobile Number.");
            }
            else
            {
                ErrorProvider.SetError(txtSMSMobileNos, null);
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

        private void lookupEditVoucherType1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditVoucherType1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditVoucherType1, "Please select Voucher Type.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditVoucherType1, null);
            }
        }

        private void lookupEditCashBankAccount_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditCashBankAccount.EditValue == null)
            {
                if (((eModeOfPayment)cmbModeOfPayment.SelectedIndex) == eModeOfPayment.Bank)
                {
                    ErrorProvider.SetError(lookupEditCashBankAccount, "Please select Bank Account.");
                }
                else
                {
                    ErrorProvider.SetError(lookupEditCashBankAccount, "Please select Cash Account.");
                }
            }
            else
            {
                ErrorProvider.SetError(lookupEditCashBankAccount, null);
            }
        }
        #endregion
    }
}
