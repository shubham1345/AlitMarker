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
    public partial class frmReceipt : Template.frmCRUDTemplate
    {
        ReceiptDAL DALObject;
        CustomerDAL CustomerDAL;
        List<ReceiptPaymentTypeViewModel> lookupPaymentTypeDS;
        object dsCustomer;


        DateTime? OldInvalidDate;
        long? OldReceiptNoPrefixID;
        List<ReceiptNoPrefixEditListModel> PrefixListDS;
        ReceiptNoPrefixEditListModel NewPrefix;
        ReceiptNoPrefixDAL ReceiptNoPrefixDAL;

        public frmReceipt()
        {
            InitializeComponent();
            FirstControl = lookupCustomer;
            DALObject = new ReceiptDAL();
            CustomerDAL = new CustomerDAL();
            ReceiptNoPrefixDAL = new ReceiptNoPrefixDAL();

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

            if (CommonProperties.LoginInfo.SoftwareSettings.SMSActivated &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSSendInReceipt)
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

        public override void LoadLookupDataSource()
        {
            lookupPaymentTypeDS = new List<ReceiptPaymentTypeViewModel>();
            lookupPaymentTypeDS.Add(new ReceiptPaymentTypeViewModel() { PaymentTypeID = 1, PaymentTypeName = "Cash" });
            lookupPaymentTypeDS.Add(new ReceiptPaymentTypeViewModel() { PaymentTypeID = 2, PaymentTypeName = "Bank" });

            LoadPrefixDS();
            LoadCustomerLookupDataSource();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupPaymentType.Properties.ValueMember = "PaymentTypeID";
            lookupPaymentType.Properties.DisplayMember = "PaymentTypeName";
            lookupPaymentType.Properties.DataSource = lookupPaymentTypeDS;

            lookUpReceiptNoPrefix.EditValueChanged -= lookUpReceiptNoPrefix_EditValueChanged;
            AssignPrefixDS();
            lookUpReceiptNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultReceiptNoPrefixID;
            lookUpReceiptNoPrefix.EditValueChanged += lookUpReceiptNoPrefix_EditValueChanged;

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

        void LoadPrefixDS(bool ImmediateAssign = false)
        {
            PrefixListDS = (List<ReceiptNoPrefixEditListModel>)ReceiptNoPrefixDAL.GetEditList();
            NewPrefix = new ReceiptNoPrefixEditListModel()
            {
                ReceiptNoPrefixID = -1,
                PrefixName = ""
            };

            PrefixListDS.Insert(0, NewPrefix);

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

        public override void AssignFormValues()
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

            base.AssignFormValues();
        }

        public override void InitializeDefaultValues()
        {
            lookupPaymentType.EditValue = 1;

            OldInvalidDate = null;
            OldReceiptNoPrefixID = null;

            base.InitializeDefaultValues();

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAutoGenerate && FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                GenerateNewInvoiceNumber();
            }
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
            DAL.tblReceipt SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblReceipt();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((ReceiptEditListModel)EditRecordDataSource).ReceiptID);

                if(SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            long RecNo = 0;
            long.TryParse(txtReceiptNo.Text, out RecNo);
            SaveModel.ReceiptNo = RecNo;

            SaveModel.ReceiptNoPrefixID = (long?)lookUpReceiptNoPrefix.EditValue;

            SaveModel.ReceiptDate = (DateTime)dtpReceiptDate.EditValue;
            SaveModel.CustomerID = (long)lookupCustomer.EditValue;
            SaveModel.PaymentType = (int)lookupPaymentType.EditValue;
            SaveModel.BankName = txtBankName.Text;
            SaveModel.BankBranchName = txtBranchName.Text;
            SaveModel.ChequeNo = txtChequeNo.Text;

            decimal Amt = 0;
            decimal.TryParse(txtAmount.Text, out Amt);
            SaveModel.Amount = Amt;

            SaveModel.Remarks = txtRemarks.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel, lookUpReceiptNoPrefix.Text);
            base.SaveRecord(Paras);


            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly &&
                CommonProperties.LoginInfo.SoftwareSettings.SMSActivated && CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice && chkbSendSMS.Checked)
            {
                Model.Reports.CustomerPrintDetailModel Customer = CustomerDAL.GetCustomerPrintModel(SaveModel.CustomerID);
                string Msg = "";
                Msg = memoSMS.Text.
                    Replace("«ReceiptNoPrefix»", lookUpReceiptNoPrefix.Text ?? "").
                    Replace("«RecieptNo»", SaveModel.ReceiptNo.ToString()).
                    Replace("«RecieptDate»", SaveModel.ReceiptDate.ToShortDateString()).
                    Replace("«CustomerNameTitle»", Customer.CustomerNameTitle).
                    Replace("«CustomerName»", Customer.CustomerNameWithTitle).
                    Replace("«CustomerNameWithCity»", Customer.CustomerCityStateShortName).
                    Replace("«CustomerNameWithCityAdd»", Customer.CustomerNameWithTitle + " " + Customer.CustomerAddressDetail).
                    Replace("«CustomerCity»", Customer.CustomerCityName).
                    Replace("«CustomerAdd»", Customer.CustomerAddress).
                    Replace("«CustomerBalance»", Customer.CustomerBalance.ToString("#0")).
                    Replace("«RecieptType»", (((Model.CashBank.eModeOfPayment)SaveModel.PaymentType) == eModeOfPayment.Cash ? "Cash" : "Bank")).
                    Replace("«RecieptAmt»", SaveModel.Amount.ToString());

                SMS.SMSHandler.SendSMS(txtSMSMobileNos.Text, txtSMSSenderID.Text, Msg, "Receipt", Alit.Marker.Model.CommonProperties.LoginInfo.LoggedinUser.UserID);
            }
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (lookUpReceiptNoPrefix.EditValue != null && (long)lookUpReceiptNoPrefix.EditValue == -1)
                {
                    LoadPrefixDS(true);
                }

                //if (lcgCustomer.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                //{
                //    if (lookupCustomer.EditValue != null && (long)lookupCustomer.EditValue == -1)
                //    {
                LoadCustomerLookupDataSource();
                AssignCustomerLookupDataSource();
                //    }
                //}
            }

            base.AfterSaving(Paras);
        }


        public override void DirectPrint(object PrintParaValue)
        {
            if (PrintParaValue.GetType() == typeof(long))
            {
                Reports.Receipt.frmReceiptPrint.DirectPrint((long)PrintParaValue);
            }
            else
            {
                Reports.Receipt.frmReceiptPrint.DirectPrint(((ReceiptEditListModel)PrintParaValue).ReceiptID);
            }
            base.DirectPrint(PrintParaValue);
        }

        public override void DirectPrintPreview(object PrintParaValue)
        {
            long SaleInvoiceID = 0;
            if (PrintParaValue.GetType() == typeof(long))
            {
                SaleInvoiceID = (long)PrintParaValue;
            }
            else
            {
                SaleInvoiceID = ((ReceiptEditListModel)PrintParaValue).ReceiptID;
            }

            Reports.Receipt.frmReceiptPrint frmPrintPrev = new Reports.Receipt.frmReceiptPrint(SaleInvoiceID);
            frmPrintPrev.ShowDialog(Navigation.frmDashBoard.DashBoard);

            base.DirectPrintPreview(PrintParaValue);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FormatEditListGridView(GridView EditListGrid)
        {
            EditListGrid.Columns["ReceiptDate"].MaxWidth = 100;

            if (!CommonProperties.LoginInfo.SoftwareSettings.ReceiptNo)
            {
                EditListGrid.Columns["ReceiptNo"].Visible = false;
                EditListGrid.Columns["ReceiptNoPrefixName"].Visible = false;
            }
            else
            {
                EditListGrid.Columns["ReceiptNo"].Width = 70;
                EditListGrid.Columns["ReceiptNo"].MaxWidth = 100;

                if (!CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix)
                {
                    EditListGrid.Columns["ReceiptNoPrefixName"].Visible = false;
                }
                else
                {
                    EditListGrid.Columns["ReceiptNoPrefixName"].Width = 70;
                    EditListGrid.Columns["ReceiptNoPrefixName"].MaxWidth = 100;
                }
            }

            EditListGrid.Columns["ReceiptPaymentType"].MaxWidth = 100;

            EditListGrid.Columns["Amount"].MaxWidth = 150;
            EditListGrid.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EditListGrid.Columns["Amount"].DisplayFormat.FormatString = "{0:n2}";

            //EditListGrid.Columns["CustomerName"].Width = EditListGrid.Columns.Where(r=> r.Visible).Sum(r=> r.Width)
            

            base.FormatEditListGridView(EditListGrid);
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblReceipt EditingRecord = DALObject.FindSaveModelByPrimeKey(((ReceiptEditListModel)RecordToFill).ReceiptID);

            txtReceiptNo.Text = EditingRecord.ReceiptNo.ToString();

            OldReceiptNoPrefixID = EditingRecord.ReceiptNoPrefixID;
            lookUpReceiptNoPrefix.EditValue = EditingRecord.ReceiptNoPrefixID;

            dtpReceiptDate.EditValue = EditingRecord.ReceiptDate;
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
            return DALObject.ValidateBeforeDelete(((ReceiptEditListModel)EditRecordDataSource).ReceiptID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((ReceiptEditListModel)EditRecordDataSource).ReceiptID);
            base.DeleteRecord(Paras);
        }

        public override void AfterDeleteRecord(DeletingParameter Paras)
        {
            if (Paras.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (CommonProperties.LoginInfo.SoftwareSettings.ReceiptPrintIsDirectPrint)
                {
                    Reports.Receipt.frmReceiptPrint.DirectPrint(Paras.DeletingResult.PrimeKeyValue);
                }

                LoadCustomerLookupDataSource();
                AssignCustomerLookupDataSource();
            }

            base.AfterDeleteRecord(Paras);
        }

        void GenerateNewInvoiceNumber()
        {
            txtReceiptNo.EditValue = DALObject.GenerateReceiptNo((Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries ?? ""),
                (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix ? lookUpReceiptNoPrefix.EditValue : null),
                (DateTime?)dtpReceiptDate.EditValue).ToString();
            //txtReceiptNo.Text = txtReceiptNo.EditValue.ToString();
            txtReceiptNo.Refresh();
        }


        private void txtReceiptNo_Validating(object sender, CancelEventArgs e)
        {
            long RecNo = 0;
            long.TryParse(txtReceiptNo.Text ?? "0", out RecNo);

            if (RecNo == 0)
            {
                ErrorProvider.SetError(txtReceiptNo, "Can not accept blank or zero as Receipt No.");
            }
            else if (DALObject.IsDuplicateRecord(RecNo,
                (EditRecordDataSource != null ? ((ReceiptEditListModel)EditRecordDataSource).ReceiptID : 0),
                    Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries ?? "",
                    (long?)(Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix ? lookUpReceiptNoPrefix.EditValue : null),
                    (DateTime?)dtpReceiptDate.EditValue))
            {
                ErrorProvider.SetError(txtReceiptNo, "Can not accept duplicate Receipt No.");
            }
            else
            {
                ErrorProvider.SetError(txtReceiptNo, "");
            }
        }

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

        private void dtpReceiptDate_Validating(object sender, CancelEventArgs e)
        {
            if(dtpReceiptDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpReceiptDate, "Receipt date is required.");
            }
            else
            {
                DateTime dt = (DateTime)dtpReceiptDate.EditValue;

                if (dt < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom || dt > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo)
                {
                    ErrorProvider.SetError(dtpReceiptDate, "date should be with in current financial period that started from " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + (CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue? " upto " + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : "" ));
                }
                else
                {
                    ErrorProvider.SetError(dtpReceiptDate, "");
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

        private void lookupCustomer_Validating(object sender, CancelEventArgs e)
        {
            if(lookupCustomer.EditValue == null)
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
            if(!decimal.TryParse(txtAmount.Text, out Amt))
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
            if(lookupPaymentType.EditValue != null && ((eModeOfPayment)lookupPaymentType.EditValue) == eModeOfPayment.Bank)
            {
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgBankDetails.Visibility = esiBankDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void lookUpReceiptNoPrefix_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            NewPrefix.PrefixName = (e.DisplayValue != null ? e.DisplayValue.ToString() : "");
            e.Handled = true;
        }
    }
}
