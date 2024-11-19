using Alit.Marker.DAL;
using Alit.Marker.DAL.Account.Account;
using Alit.Marker.DAL.Customer;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Customer;
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.Model.Template;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Account
{
    public partial class frmAccountCRUD : Template.frmCRUDTemplate
    {
        AccountDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new AccountDAL();
                }
                return DALObject;
            }
        }
        eAccountFormType eAccountFormType;
        long OpBalAccountID = 0;

        ////public frmAccountCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }, eAccountFormType.Account) { }

        ////public frmAccountCRUD(Model.Template.CRUDMTemplateParas paras, eAccountFormType eAccFormType) : base(paras)
        ////{
        ////    InitializeComponent();
        ////    FirstControl = txtAccountName;

        ////    DALObject = new AccountDAL();
        ////    eAccountFormType = eAccFormType;
        ////    if (eAccountFormType.Account == eAccountFormType)
        ////    {
        ////        Text = "Account";
        ////    }
        ////    else if (eAccountFormType.Customer == eAccountFormType)
        ////    {
        ////        Text = "Customer";
        ////    }
        ////    else if (eAccountFormType.Supplier == eAccountFormType)
        ////    {
        ////        Text = "Supplier";
        ////    }
        ////}
        public frmAccountCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        //public frmAccountCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }, eAccountFormType.Account) { }

        public frmAccountCRUD(Model.Template.CRUDMTemplateParas paras) : this(paras, eAccountFormType.Account) { }

        public frmAccountCRUD(Model.Template.CRUDMTemplateParas paras, eAccountFormType eAccFormType) : base(paras)
        {
            InitializeComponent();
            FirstControl = txtAccountName;

            DALObject = new AccountDAL();
            eAccountFormType = eAccFormType;
            if (eAccountFormType.Account == eAccountFormType)
            {
                Text = "Account";
            }
            else if (eAccountFormType.Customer == eAccountFormType)
            {
                Text = "Customer";
            }
            else if (eAccountFormType.Supplier == eAccountFormType)
            {
                Text = "Supplier";
            }
        }

        #region Template Methods     

        protected override void OnInitializeDefaultValues()
        {
            txtAccountNo.Text = DALObject.GenerateNewAccountNo().ToString();

            if (FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                lookUpCity.EditValue = Model.CommonProperties.LoginInfo.LoggedInCompany.CityID;
                if (lookUpPriceList.Properties.DataSource != null)
                {
                    lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).FirstOrDefault().PriceListID;
                }
            }
            tswitchAllowSendSMS.EditValue = false;

            var res = ((List<AccountGroupLookupListModel>)lookupEditAccountGroup1.Properties.DataSource).ToList();

            if (res != null && res.Count > 0 && eAccountFormType != eAccountFormType.Account)
            {
                if (eAccountFormType.Customer == eAccountFormType)
                {
                    lookupEditAccountGroup1.Properties.DataSource = res.Where(r => r.GroupTypeID == eAccountGroupType.SundryDebtors).ToList();
                }
                else if (eAccountFormType.Supplier == eAccountFormType)
                {
                    lookupEditAccountGroup1.Properties.DataSource = res.Where(r => r.GroupTypeID == eAccountGroupType.SundryCreditors).ToList();
                }
            }

            cmbCrDr.SelectedIndex = 1;

            base.OnInitializeDefaultValues();
        }            

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            int AccountNo = 0;
            int.TryParse(txtAccountNo.Text, out AccountNo);

            return new AccountViewModel()
            {
                AccountID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                AccountName = txtAccountName.Text,
                AccountNo = AccountNo,
                AccountGroupID = (long)lookupEditAccountGroup1.EditValue,
                ContactPerson = txtContactPerson.Text,
                Address = txtAddress.Text,
                CityID = (long?)lookUpCity.EditValue,
                PostCode = textPostCode.Text,
                MobileNo = txtMobileNo.Text,
                PhoneNo = txtPhoneNo.Text,
                EMailID = txtEMailID.Text,
                Website = txtWebsite.Text,
                PAN = txtPAN.Text,
                GSTNo = txtGSTNo.Text,
                ServiceTaxNo = txtServiceTaxNo.Text,
                CreditLimit = (decimal?)txtCreditLimit.EditValue,
                CreditDays = (int?)txtCreditDays.EditValue,
                PriceListID = (long?)lookUpPriceList.EditValue,
                AllowSendSMS = (bool?)tswitchAllowSendSMS.EditValue,
                CrDrType = (eCrDrType)cmbCrDr.SelectedIndex,
                OpBalAmount = (decimal)txtOpBalAmount.EditValue,
                AccountOpeningBalanceID = OpBalAccountID,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            AccountViewModel EditingRecord = (AccountViewModel)RecordToFill;

            txtAccountName.Text = EditingRecord.AccountName;
            //txtAccountNo.Text = EditingRecord.AccountNo.ToString();
            txtAccountNo.EditValue = EditingRecord.AccountNo;
            lookupEditAccountGroup1.EditValue = EditingRecord.AccountGroupID;
            txtContactPerson.Text = EditingRecord.ContactPerson ?? null;
            txtAddress.Text = EditingRecord.Address;
            lookUpCity.EditValue = EditingRecord.CityID;
            textPostCode.EditValue = EditingRecord.PostCode;
            txtMobileNo.EditValue = EditingRecord.MobileNo;
            txtPhoneNo.EditValue = EditingRecord.PhoneNo;
            txtEMailID.EditValue = EditingRecord.EMailID;
            txtWebsite.EditValue = EditingRecord.Website;
            txtPAN.EditValue = EditingRecord.PAN;
            txtGSTNo.EditValue = EditingRecord.GSTNo;
            txtServiceTaxNo.EditValue = EditingRecord.ServiceTaxNo;

            txtCreditLimit.EditValue = EditingRecord.CreditLimit;
            txtCreditDays.EditValue = EditingRecord.CreditDays;

            lookUpPriceList.EditValue = EditingRecord.PriceListID;

            tswitchAllowSendSMS.EditValue = EditingRecord.AllowSendSMS;

            txtOpBalAmount.EditValue = EditingRecord.OpBalAmount;
            cmbCrDr.SelectedIndex = (int)EditingRecord.CrDrType;
            OpBalAccountID = EditingRecord.AccountOpeningBalanceID;

            if (EditingRecord.DefaultAccount != null && EditingRecord.DefaultAccount == true)
            {
                EnableDisableControl((bool)EditingRecord.DefaultAccount);
            }

                return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        void EnableDisableControl(bool DefaultAccount)
        {
            if (DefaultAccount)
            {
                lcgAccountInformation.Enabled = false;
                layoutControlItem1.Enabled = false;
                lcgOpeningBalance.Enabled = false;
            }
        }
        #endregion

        private void lookupEditAccountGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue != null)
            {
                if (DALObject.IsExpenseORLiablitiesAccountGroup((long)lookupEditAccountGroup1.EditValue))
                {                    
                    lcgAccountInformation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    SetValueOnAccountGroupChange(true);
                }
                else
                {
                    lcgAccountInformation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    SetValueOnAccountGroupChange(false);
                }
            }
        }

        void SetValueOnAccountGroupChange(bool IsExpenseOrLiablities)
        {
            if (IsExpenseOrLiablities)
            {
                lookUpCity.EditValue = Model.CommonProperties.LoginInfo.LoggedInCompany.CityID;
                if (lookUpPriceList.Properties.DataSource != null)
                {
                    lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).FirstOrDefault().PriceListID;
                }
                txtCreditLimit.EditValue = 0M;
                txtCreditDays.EditValue = 0;
            }
            else
            {
                txtContactPerson.Text = null;
                txtAddress.Text = null;
                lookUpCity.EditValue = null;
                textPostCode.EditValue = null;
                txtMobileNo.EditValue = null;
                txtPhoneNo.EditValue = null;
                txtEMailID.EditValue = null;
                txtWebsite.EditValue = null;
                txtPAN.EditValue = null;
                txtGSTNo.EditValue = null;
                txtServiceTaxNo.EditValue = null;
                txtCreditLimit.EditValue = null;
                txtCreditDays.EditValue = null;
                lookUpPriceList.EditValue = null;
                tswitchAllowSendSMS.EditValue = null;
            }
        }

        private void lookUpPriceList_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lookUpPriceList.EditValue = null;
            }
        }

        #region Validation

        private void txtAccountName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                ErrorProvider.SetError(txtAccountName, "Please enter Account Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtAccountName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtAccountName, "Can not accept duplicate Account Name.");
            }
            else
            {
                ErrorProvider.SetError(txtAccountName, null);
            }
        }

        private void lookupEditAccountGroup1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEditAccountGroup1.EditValue == null)
            {
                ErrorProvider.SetError(lookupEditAccountGroup1, "Please select Account Group.");
            }
            else
            {
                ErrorProvider.SetError(lookupEditAccountGroup1, null);
            }
        }

        private void txtEMailID_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtEMailID.Text) && Model.CommonFunctions.ValidateEmail(txtEMailID.Text))
            {
                ErrorProvider.SetError(txtEMailID, "Please enter valid Email-ID.");
            }
            else
            {
                ErrorProvider.SetError(txtEMailID, null);
            }
        }

        private void txtWebsite_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtWebsite.Text) && Model.CommonFunctions.ValidateWebSiteURL(txtWebsite.Text))
            {
                ErrorProvider.SetError(txtWebsite, "Please enter valid Website URL.");
            }
            else
            {
                ErrorProvider.SetError(txtWebsite, null);
            }
        }

        private void lookUpCity_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpCity.EditValue == null)
            {
                ErrorProvider.SetError(lookUpCity, "Please select City.");
            }
            else
            {
                ErrorProvider.SetError(lookUpCity, null);
            }
        }

        private void txtCreditLimit_Validating(object sender, CancelEventArgs e)
        {
            if (txtCreditLimit.EditValue == null)
            {
                ErrorProvider.SetError(txtCreditLimit, "Please enter Credit Limit.");
            }
            else
            {
                ErrorProvider.SetError(txtCreditLimit, null);
            }
        }

        private void txtCreditDays_Validating(object sender, CancelEventArgs e)
        {
            if (txtCreditDays.EditValue == null)
            {
                ErrorProvider.SetError(txtCreditDays, "Please enter Credit Days.");
            }
            else
            {
                ErrorProvider.SetError(txtCreditDays, null);
            }
        }

        private void txtOpBalAmount_Validating(object sender, CancelEventArgs e)
        {
            if ((decimal)txtOpBalAmount.EditValue < 0)
            {
                ErrorProvider.SetError(txtOpBalAmount, "Opening Balance Amount should be greater than or equal to 0.");
            }
            else
            {
                ErrorProvider.SetError(txtOpBalAmount, null);
            }
        }

        #endregion

    }
}
