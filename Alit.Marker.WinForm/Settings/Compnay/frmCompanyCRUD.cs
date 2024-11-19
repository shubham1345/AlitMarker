using Alit.Marker.DAL;
using Alit.Marker.DAL.City.City;
using Alit.Marker.DAL.Settings.Compnay;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
//using Alit.Marker.Model.Settings;
using Alit.Marker.Model.Settings.Compnay;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Settings.Compnay
{
    public partial class frmCompanyCRUD : Template.frmCRUDTemplate
    {
        CompanyDAL DALObj;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObj == null)
                {
                    DALObj = new CompanyDAL();
                }

                return DALObj;
            }
        }


        public frmCompanyCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmCompanyCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObj = new CompanyDAL();           
        }

        #region Overriden Methods
        protected override void OnInitializeDefaultValues()
        {
            if (FormCurrentUI != eFormCurrentUI.NewEntry 
                    || (lookupCopySettingFromCompany.Properties.DataSource == null 
                            || ((List<CompanyLookupListModel>)lookupCopySettingFromCompany.Properties.DataSource).Count == 0))
            {
                lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (FormCurrentUI == eFormCurrentUI.NewEntry && (lookupCopySettingFromCompany.Properties.DataSource != null && ((List<CompanyLookupListModel>)lookupCopySettingFromCompany.Properties.DataSource).Count > 0))
            {
                lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            if (FormCurrentUI == eFormCurrentUI.Edit)
            {
                deBusinessStartedFrom.Enabled = false;
            }

            base.OnInitializeDefaultValues();
        }

        protected override void OnAssignFormValues()
        {
            if (FormCurrentUI == eFormCurrentUI.NewEntry && (CompanyDAL.CompanyCount() > 0 ))
            {
                lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            base.OnAssignFormValues();
        }

        protected override void OnClearValues()
        {
            deBusinessStartedFrom.Enabled = (FormCurrentUI != eFormCurrentUI.Edit);
            base.OnClearValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new CompanyViewModel()
            {
                CompanyID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),

                CompanyName = txtCompanyName.Text,
                Address = memoAddress.Text,
                CityID = (long)lueCity.EditValue,
                PIN = txtPin.Text,
                Phone1 = txtPhone1.Text,
                MobileNo1 = txtMobileNo.Text,
                EMailID = txtEMailID.Text,
                Website = txtWebsite.Text,
                DirectorName = txtDirectorName.Text,
                PAN = txtPAN.Text,
                GSTIN = txtGSTIN.Text,
                ServiceTaxNo = txtServiceTaxNo.Text,
                LicenseName = txtLicenseName.Text,
                LicenseNo = txtLicenseNo.Text,
                Jurisdiction = txtJurisdiction.Text,
                BankName = txtBankName.Text,
                BankCity = txtBankCity.Text,
                BankBranch = txtBankBranch.Text,
                BankIFSC = txtBankIFSCCode.Text,
                BankAccountNo = txtBankAccountNo.Text,
                BankAccountName = txtBankAccountName.Text,
                BusinessStartedFrom = (DateTime)deBusinessStartedFrom.EditValue,
                CopySettingsFromCompanyID = (lcgSettings.Visibility != DevExpress.XtraLayout.Utils.LayoutVisibility.Never ? (long?)lookupCopySettingFromCompany.EditValue : null)
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            CompanyViewModel EditingRecord = (CompanyViewModel)RecordToFill;

            txtCompanyName.Text = EditingRecord.CompanyName;
            
            memoAddress.Text = EditingRecord.Address;
            lueCity.EditValue = EditingRecord.CityID;
            txtPin.Text = EditingRecord.PIN;
            txtPhone1.Text = EditingRecord.Phone1;
            txtMobileNo.Text = EditingRecord.MobileNo1;
            txtEMailID.Text = EditingRecord.EMailID;
            txtWebsite.Text = EditingRecord.Website;
            txtDirectorName.Text = EditingRecord.DirectorName;
            txtPAN.Text = EditingRecord.PAN;
            txtGSTIN.Text = EditingRecord.GSTIN;
            txtServiceTaxNo.Text = EditingRecord.ServiceTaxNo;
            txtLicenseName.Text = EditingRecord.LicenseName;
            txtLicenseNo.Text = EditingRecord.LicenseNo;
            txtJurisdiction.Text = EditingRecord.Jurisdiction;
            txtBankName.Text = EditingRecord.BankName;
            txtBankCity.Text = EditingRecord.BankCity;
            txtBankBranch.Text = EditingRecord.BankBranch;
            txtBankIFSCCode.Text = EditingRecord.BankIFSC;
            txtBankAccountNo.Text = EditingRecord.BankAccountNo;
            txtBankAccountName.Text = EditingRecord.BankAccountName;

            deBusinessStartedFrom.EditValue = null;
            deBusinessStartedFrom.EditValue = EditingRecord.BusinessStartedFrom;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                ErrorProvider.SetError(txtCompanyName, "Please enter Company Name.");
            }
            else if (DALObj.IsDuplicateRecord(txtCompanyName.Text,
                (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtCompanyName, "Can not accept duplicate Company Name.");
            }
            else
            {
                ErrorProvider.SetError(txtCompanyName, null);
            }
        }

        private void lueCity_Validating(object sender, CancelEventArgs e)
        {
            if (lueCity.EditValue == null)
            {
                ErrorProvider.SetError(lueCity, "Please select City.");
            }
            else
            {
                ErrorProvider.SetError(lueCity, null);
            }
        }

        private void deBusinessStartedFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deBusinessStartedFrom.EditValue == null)
            {
                ErrorProvider.SetError(deBusinessStartedFrom, "Please select date when your Business Started From.");
            }
            else
            {
                ErrorProvider.SetError(deBusinessStartedFrom, null);
            }
        }
        
        private void txtEMailID_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtEMailID.Text) && Model.CommonFunctions.ValidateEmail(txtEMailID.Text))
            {
                ErrorProvider.SetError(txtEMailID, "Please enter valid Email ID.");
            }
            else
            {
                ErrorProvider.SetError(txtEMailID, null);
            }
        }
        #endregion

    }
}
