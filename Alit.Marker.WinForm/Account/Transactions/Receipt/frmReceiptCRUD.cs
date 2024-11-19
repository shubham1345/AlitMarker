using Alit.Marker.DAL.Customer;
using Alit.Marker.Model;
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
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.CashBank;
using DevExpress.XtraReports.UI;
using Alit.Marker.Model.Account.Transactions.Receipt;
using Alit.Marker.DAL.Account.Transactions.Receipt;
using Alit.Marker.Model.Account.Transactions.Receipt.ReceiptNoPrefix;
using Alit.Marker.DAL.Account.Transactions.Receipt.ReceiptNoPrefix;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Account.VoucherType;

namespace Alit.Marker.WinForm.Account.Transactions.Receipt
{
    public partial class frmReceiptCRUD : Template.frmCRUDTemplate
    {
        ReceiptDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new ReceiptDAL();
                }

                return DALObject;
            }
        }

        DateTime? OldInvalidDate;
        long? OldReceiptNoPrefixID;
        List<ReceiptNoPrefixLookupModel> PrefixListDS;
        ReceiptNoPrefixDAL ReceiptNoPrefixDAL;

        AccountDAL AccountDAL;
        long AccountVoucherID;

        List<VoucherTypeLookUpListModel> dsVoucherType;

        public frmReceiptCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmReceiptCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            FirstControl = lookupEditCustomer;
            DALObject = new ReceiptDAL();
            ReceiptNoPrefixDAL = new ReceiptNoPrefixDAL();
            AccountDAL = new AccountDAL();

            // Apply settings for Invoice Number and prefix
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNo)
            {
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix)
                {
                    lciReceiptNoPrefix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAllowEdit)
                {
                    txtReceiptNo.Enabled = false;
                }
            }
            else
            {
                lciReceiptNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciReceiptNoPrefix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInReceipt)
            {
                chkbSendSMS.Checked = false;
                lcgSMS.DataBindings.Add("Enabled", chkbSendSMS, "Checked");
            }
            else
            {
                chkbSendSMS.Checked = false;
                lcgSMSParent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        #region Overriden Methods
        protected override void OnLoadLookupDataSource()
        {
            LoadPrefixDS();
            //LoadCustomerLookupDataSource();
            
            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            AssignPrefixDS();
            lookUpReceiptNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultReceiptNoPrefixID;

            base.OnAssignLookupDataSource();
        }

        protected override void OnAssignFormValues()
        {

            if (DateTime.Now.Date < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
            {
                dtpReceiptDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.Date;
            }
            else if (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue && DateTime.Now.Date > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value)
            {
                dtpReceiptDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            else
            {
                dtpReceiptDate.EditValue = DateTime.Now.Date;
            }
            //--

            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInReceipt)
            {
                txtSMSSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSReceiptSenderID;
                memoSMS.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSReceiptTemplate;
            }

            AssignVoucherType();

            base.OnAssignFormValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            cmbModeOfPayment.SelectedIndex = (int)eModeOfPayment.Cash;

            OldInvalidDate = null;
            OldReceiptNoPrefixID = null;

            base.OnInitializeDefaultValues();

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAutoGenerate && FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                GenerateNewInvoiceNumber();
            }
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
            return new ReceiptViewModel()
            {
                ReceiptID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                ReceiptNo = (long)txtReceiptNo.EditValue,
                ReceiptNoPrefixID = (long?)lookUpReceiptNoPrefix.EditValue,
                ReceiptDate = (DateTime)dtpReceiptDate.EditValue,
                ///////CustomerID = (long)lookupEditAccount1.EditValue,
                CustomerAccountID = (long)lookupEditCustomer.EditValue,
                ModeOfPayment = (eModeOfPayment)cmbModeOfPayment.SelectedIndex,
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
            //if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly &&
            //    CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice && chkbSendSMS.Checked)
            //{
            //    Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(SaveModel.CustomerID);
            //    string Msg = "";
            //    Msg = memoSMS.Text.
            //        Replace("«ReceiptNoPrefix»", lookUpReceiptNoPrefix.Text ?? "").
            //        Replace("«RecieptNo»", SaveModel.ReceiptNo.ToString()).
            //        Replace("«RecieptDate»", SaveModel.ReceiptDate.ToShortDateString()).
            //        Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
            //        Replace("«CustomerName»", Customer.CustomerNameWithTitle).
            //        Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
            //        Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
            //        Replace("«CustomerCity»", Customer.CustomerCityName).
            //        Replace("«CustomerAdd»", Customer.CustomerAddress).
            //        Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
            //        Replace("«RecieptType»", (((Model.CashBank.eModeOfPayment)SaveModel.PaymentType) == eModeOfPayment.Cash ? "Cash" : "Bank")).
            //        Replace("«RecieptAmt»", SaveModel.Amount.ToString());

            //    SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Receipt", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
            //}

            base.OnAfterSaving(Paras);
        }

        protected override XtraReport GeneratePrintDocument(long PrimeKeyID)
        {
            return WinForm.Account.Transactions.Receipt.frmReceiptDashboard.GenerateReceiptPrintDocument(PrimeKeyID);
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            ReceiptViewModel EditingRecord = (ReceiptViewModel)RecordToFill;

            txtReceiptNo.EditValue = EditingRecord.ReceiptNo;

            OldReceiptNoPrefixID = EditingRecord.ReceiptNoPrefixID;
            lookUpReceiptNoPrefix.EditValue = EditingRecord.ReceiptNoPrefixID;

            dtpReceiptDate.EditValue = EditingRecord.ReceiptDate;
            //lookupEditAccount1.EditValue = EditingRecord.CustomerID;
            lookupEditCustomer.EditValue = EditingRecord.CustomerAccountID;
            cmbModeOfPayment.SelectedIndex = (int)EditingRecord.ModeOfPayment;

            txtBankName.Text = EditingRecord.BankName;
            txtBranchName.Text = EditingRecord.BankBranchName;
            txtChequeNo.Text = EditingRecord.ChequeNo;

            txtAmount.EditValue = EditingRecord.Amount;
            txtRemarks.EditValue = EditingRecord.Remarks;
            lookupEditCashBankAccount.EditValue = EditingRecord.CashBankAccountID;
            lookupEditVoucherType1.EditValue = EditingRecord.VoucherTypeID;
            AccountVoucherID = EditingRecord.AccountVoucherID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Methods
        //void LoadCustomerLookupDataSource()
        //{
        //    dsCustomer = CustomerDAL.GetLookupList();
        //}

        //void AssignCustomerLookupDataSource()
        //{
        //    lookupCustomer.Properties.ValueMember = "CustomerID";
        //    lookupCustomer.Properties.DisplayMember = "CustomerName";
        //    lookupCustomer.Properties.DataSource = dsCustomer;
        //}

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

        void LoadPrefixDS(bool ImmediateAssign = false)
        {
            PrefixListDS = ReceiptNoPrefixDAL.GetLookupList();

            if (ImmediateAssign)
            {
                AssignPrefixDS();
            }
        }

        void AssignPrefixDS()
        {
            lookUpReceiptNoPrefix.Properties.DisplayMember = "PrefixName";
            lookUpReceiptNoPrefix.Properties.ValueMember = "ReceiptNoPrefixID";
            lookUpReceiptNoPrefix.Properties.DataSource = PrefixListDS;
        }

        void GenerateNewInvoiceNumber()
        {
            txtReceiptNo.EditValue = DALObject.GenerateReceiptNo((long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix ? lookUpReceiptNoPrefix.EditValue : null),
                (DateTime?)dtpReceiptDate.EditValue);
        }
        #endregion

        #region Events
        private void dtpReceiptDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAutoGenerate)
            {
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries != null &&
                    (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries.Contains("Date") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries.Contains("MonthYear") ||
                    Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries.Contains("Year")))
                {
                    if (OldInvalidDate != (DateTime?)dtpReceiptDate.EditValue)
                    {
                        GenerateNewInvoiceNumber();
                    }
                    OldInvalidDate = (DateTime?)dtpReceiptDate.EditValue;
                }
            }
        }

        private void lookUpReceiptNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAutoGenerate &&
                (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries ?? "").Contains("Prefix"))
            {
                if (OldReceiptNoPrefixID != (long?)lookUpReceiptNoPrefix.EditValue)
                {
                    GenerateNewInvoiceNumber();
                }
                OldReceiptNoPrefixID = (long?)lookUpReceiptNoPrefix.EditValue;
            }
        }

        private void cmbModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((eModeOfPayment)cmbModeOfPayment.SelectedIndex) == eModeOfPayment.Bank)
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

        private void lookupEditAccount1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditCustomer.EditValue != null && (long)lookupEditCustomer.EditValue != -1)
            {
                AccountLookUpListModel SelectedCustomer = (AccountLookUpListModel)lookupEditCustomer.GetSelectedDataRow();
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

        #endregion

        #region Validation
        private void txtReceiptNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtReceiptNo.EditValue == null || (long)txtReceiptNo.EditValue == 0)
            {
                ErrorProvider.SetError(txtReceiptNo, "Can not accept blank or zero as Receipt No.");
            }
            else if (DALObject.IsDuplicateRecord((long)txtReceiptNo.EditValue,
                    (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                    (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix ? lookUpReceiptNoPrefix.EditValue : null),
                    (DateTime?)dtpReceiptDate.EditValue))
            {
                ErrorProvider.SetError(txtReceiptNo, "Can not accept duplicate Receipt No.");
            }
            else
            {
                ErrorProvider.SetError(txtReceiptNo, null);
            }
        }

        private void dtpReceiptDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpReceiptDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpReceiptDate, "Receipt date is required.");
            }
            else
            {
                DateTime dt = (DateTime)dtpReceiptDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(dtpReceiptDate, "date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? " upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : ""));
                }
                else
                {
                    ErrorProvider.SetError(dtpReceiptDate, null);
                }
            }
        }

        private void cmbModeOfPayment_Validating(object sender, CancelEventArgs e)
        {
            if (cmbModeOfPayment.SelectedIndex == -1)
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
                ErrorProvider.SetError(txtAmount, "Amount is required");
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

        private void lookupEditAccount1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditCustomer.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditCustomer, "Please select Customer.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditCustomer, null);
            }
        }

        private void lookupEditAccount2_Validating(object sender, CancelEventArgs e)
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

        #endregion
    }
}
