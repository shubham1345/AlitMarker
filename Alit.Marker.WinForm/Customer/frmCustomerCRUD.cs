using Alit.Marker.DAL;
using Alit.Marker.DAL.City.City;
using Alit.Marker.DAL.Customer;
using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
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

namespace Alit.Marker.WinForm.Customer
{
    public partial class frmCustomerCRUD : Template.frmCRUDTemplate
    {
        CustomerDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new CustomerDAL();
                }

                return DALObject;
            }
        }

        //CityDAL CityDAL;
        //PriceListDAL PriceListDAL;

        //object dsCity;
        //IEnumerable<PriceListLookupListModel> PriceListSource;

        public frmCustomerCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmCustomerCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            FirstControl = cmbCustomerTitle;
            //CommonFunctions.SetCurrencyMask(txtCreditLimit);

            DALObject = new CustomerDAL();
            //CityDAL = new DAL.City.City.CityDAL();
            //PriceListDAL = new PriceListDAL();
        }

        #region Template Methods

        //protected override void OnLoadLookupDataSource()
        //{
        //    dsCity = CityDAL.GetLookupList();
        //    PriceListSource = PriceListDAL.GetLookupList();

        //    base.OnLoadLookupDataSource();
        //}

        //protected override void OnAssignLookupDataSource()
        //{
        //    lookUpCity.Properties.ValueMember = "CityID";
        //    lookUpCity.Properties.DisplayMember = "CityName";
        //    lookUpCity.Properties.DataSource = dsCity;
        //    lookUpCity.EditValue = Model.CommonProperties.LoginInfo.LoggedInCompany.CityID;

        //    lookUpPriceList.Properties.ValueMember = "PriceListID";
        //    lookUpPriceList.Properties.DisplayMember = "PriceListName";
        //    lookUpPriceList.Properties.DataSource = PriceListSource;
        //    if (PriceListSource.Count() > 0)
        //    {
        //        lookUpPriceList.EditValue = PriceListSource.OrderBy(r => r.PriceListID).First().PriceListID;
        //    }
        //    base.OnAssignLookupDataSource();
        //}

        protected override void OnInitializeDefaultValues()
        {
            cmbCustomerTitle.SelectedIndex = 0;
            txtCustomerNo.Text = DALObject.GenerateNewCustomerNo().ToString();

            if (FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                lookUpCity.EditValue = Model.CommonProperties.LoginInfo.LoggedInCompany.CityID;
                if (lookUpPriceList.Properties.DataSource != null)
                {
                    lookUpPriceList.EditValue = ((List<PriceListLookupListModel>)lookUpPriceList.Properties.DataSource).FirstOrDefault().PriceListID;
                }
            }
            tswitchAllowSendSMS.EditValue = false;
            base.OnInitializeDefaultValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            if (DALObject.IsDuplicateRecord(txtCustomerName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID: 0)))
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Entered customer name already exists, do you still want to add duplicate customer ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    //SavingResult SavingResult = new SavingResult();
                    //SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    //SavingResult.ValidationError = "Can not save. duplicate customer name is not accepted.";
                    txtCustomerName.Focus();
                    return false;
                }
            }

            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            int CustomerNo = 0;
            int.TryParse(txtCustomerNo.Text, out CustomerNo);

            return new CustomerViewModel()
            {
                CustomerID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                CustomerName = txtCustomerName.Text,
                CustomerNo = CustomerNo,
                NameTitle = cmbCustomerTitle.Text,
                CompanyName = txtCompanyName.Text,
                ContactPerson = txtContactPerson.Text,
                Address = txtAddress.Text,
                CityID = (long)lookUpCity.EditValue,
                PostCode = textPostCode.Text,
                MobileNo = txtMobileNo.Text,
                PhoneNo = txtPhoneNo.Text,
                EMailID = txtEMailID.Text,
                Website = txtWebsite.Text,
                PAN = txtPAN.Text,
                GSTNo = txtGSTNo.Text,
                ServiceTaxNo = txtServiceTaxNo.Text,
                //CreditLimit = CreditLimit,
                CreditLimit = (decimal)txtCreditLimit.EditValue,
                //CreditDays = CreditDays,
                CreditDays = (int)txtCreditDays.EditValue,
                PriceListID = (long?)lookUpPriceList.EditValue,
                AllowSendSMS = (bool)tswitchAllowSendSMS.EditValue,
            };
        }

        //protected override void FormatEditListGridView(GridView EditListGrid)
        //{
        //    EditListGrid.Columns["CustomerNo"].Width = 35;
        //    EditListGrid.Columns["CustomerNameTitle"].Width = 30;
        //    EditListGrid.Columns["CustomerName"].MinWidth = 100;
        //    EditListGrid.Columns["City"].Width = 60;
        //    //Grid.Columns["State"].Width = 50;
        //    //Grid.Columns["Country"].Width = 50;
        //    EditListGrid.Columns["MobileNo"].Width = 50;
        //    EditListGrid.Columns["PhoneNo"].Width = 50;
        //    EditListGrid.Columns["EMailID"].Width = 50;
        //    EditListGrid.Columns["PAN"].Width = 40;
        //    EditListGrid.Columns["GSTNo"].Width = 40;

        //    EditListGrid.Columns["BalanceAmt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //    EditListGrid.Columns["BalanceAmt"].DisplayFormat.FormatString = "{0:n2}";

        //    base.FormatEditListGridView(EditListGrid);
        //}

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            CustomerViewModel EditingRecord = (CustomerViewModel)RecordToFill;


            txtCustomerName.Text = EditingRecord.CustomerName;

            txtCustomerNo.Text = EditingRecord.CustomerNo.ToString();
            cmbCustomerTitle.Text = EditingRecord.NameTitle;
            txtCustomerName.Text = EditingRecord.CustomerName;
            txtCompanyName.EditValue = EditingRecord.CompanyName;
            txtContactPerson.Text = EditingRecord.ContactPerson ?? "";
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

            ////txtCreditLimit.EditValue = null;
            ////txtCreditLimit.EditValue = EditingRecord.CreditLimit.ToString();
            txtCreditLimit.EditValue = EditingRecord.CreditLimit;
            //txtCreditDays.EditValue = null;
            //txtCreditDays.EditValue = EditingRecord.CreditDays.ToString();
            txtCreditDays.EditValue = EditingRecord.CreditDays;

            lookUpPriceList.EditValue = EditingRecord.PriceListID;

            tswitchAllowSendSMS.EditValue = EditingRecord.AllowSendSMS;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                ErrorProvider.SetError(txtCustomerName, "Please enter Customer Name.");
            }
            //else if (DALObject.IsDuplicateRecord(txtCustomerName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((CustomerEditListModel)EditRecordDataSource).CustomerID : 0)))
            //{
            //    ErrorProvider.SetError(txtCustomerName, "Can not accept duplicate customer name.");
            //}
            else
            {
                ErrorProvider.SetError(txtCustomerName, null);
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
        #endregion

    }
}
