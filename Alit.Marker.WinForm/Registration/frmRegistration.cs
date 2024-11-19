using Alit.Marker.DAL.City;
using Alit.Marker.DAL.Registration;
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
using Alit.Marker.Model;

namespace Alit.Marker.WinForm.Registration
{
    public partial class frmRegistration : Template.frmNormalTemplate
    {
        RegistrationDAL DALObj;
        CityDAL CityDAL;
        List<Model.City.CityEditListModel> dsCity;
        public frmRegistration()
        {
            InitializeComponent();
            DALObj = new RegistrationDAL();
            CityDAL = new DAL.City.CityDAL();
        }

        public override void AssignFormValues()
        {
            if (Model.CommonProperties.CurrentRegistration != null)
            {
                txtEMailID.Text = Model.CommonProperties.CurrentRegistration.EMailID;
                txtFullName.Text = Model.CommonProperties.CurrentRegistration.FullName;
                txtCompanyName.Text = Model.CommonProperties.CurrentRegistration.CompanyName;
                //txtPassword.Text = Model.CommonProperties.CurrentRegistration.Password;
                txtBusinessType.Text = Model.CommonProperties.CurrentRegistration.BusinessType;
                txtMobileNo.Text = Model.CommonProperties.CurrentRegistration.MobileNo;
                txtPhoneNo.Text = Model.CommonProperties.CurrentRegistration.PhoneNo;

                Model.City.CityEditListModel CityRecrod = ((List<Model.City.CityEditListModel>)lookUpCity.Properties.DataSource).FirstOrDefault(r => r.CityName == Model.CommonProperties.CurrentRegistration.CityName && r.StateName == Model.CommonProperties.CurrentRegistration.StateName && r.CountryName == Model.CommonProperties.CurrentRegistration
                .CountryName);

                if (CityRecrod != null)
                {
                    lookUpCity.EditValue = CityRecrod.CityID;
                }
                memoAddress.Text = Model.CommonProperties.CurrentRegistration.Address;
            }
            else
            {
                lcgLoginButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            base.AssignFormValues();
        }

        public override void LoadLookupDataSource()
        {
            dsCity = CityDAL.GetEditList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookUpCity.Properties.ValueMember = "CityID";
            lookUpCity.Properties.DisplayMember = "CityName";
            lookUpCity.Properties.DataSource = dsCity;
            lookUpCity.EditValue = Model.CommonProperties.LoginInfo.LoggedInCompany.CityID;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            Service.Update.Model.SoftwareRegistrationViewModel ViewModel = null;
            ViewModel = Model.CommonProperties.CurrentRegistration;

            if(ViewModel == null)
            {
                ViewModel = new Service.Update.Model.SoftwareRegistrationViewModel();
            }
            //else // Uncomment if you want to check password before updating details.
            //{
            //    var APIResult = DALObj.GetRegistrationFromAdmin(txtEMailID.Text, txtPassword.Text);
            //    Paras.SavingResult = new SavingResult();
            //    if (!String.IsNullOrWhiteSpace(APIResult.ErrorMessage))
            //    {
            //        Paras.SavingResult.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
            //        Paras.SavingResult.Exception = new InvalidOperationException("Internet connection is not available or server unreachable.\r\nFollowing error occured while saving registration information. Please contact to vender and provide following details.\r\n" + APIResult.ErrorMessage);
            //        return;
            //    }
            //    else if (!String.IsNullOrWhiteSpace(APIResult.ValidationMessage))
            //    {
            //        Paras.SavingResult.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
            //        Paras.SavingResult.Exception = new InvalidOperationException("Please fix following errors before registrations. " + APIResult.ValidationMessage);
            //    }
            //    else
            //    {
            //        Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
            //        Paras.SavingResult.ValidationError = "Email id or password did not matched.";
            //    }
            //}

            ViewModel.EMailID = txtEMailID.Text;
            ViewModel.Password = txtPassword.Text;
            ViewModel.FullName = txtFullName.Text;
            ViewModel.CompanyName = txtCompanyName.Text;
            ViewModel.BusinessType = txtBusinessType.Text;
            ViewModel.MobileNo = txtMobileNo.Text;
            ViewModel.PhoneNo = txtPhoneNo.Text;
            
            Model.City.CityEditListModel SelectedCity = (Model.City.CityEditListModel)lookUpCity.GetSelectedDataRow();
            ViewModel.CityName = SelectedCity.CityName;
            ViewModel.StateName = SelectedCity.StateName;
            ViewModel.CountryName = SelectedCity.CountryName;

            ViewModel.Address = memoAddress.Text;

            Paras.SavingResult = DALObj.SaveRegistration(ViewModel);
            

            base.SaveRecord(Paras);
        }
        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == Model.eExecutionResult.CommitedSucessfuly)
            {
                Navigation.frmDashBoard.DashBoard.CheckForRegistrationDetail();
                this.Close();
            }
            else
            {
                txtEMailID.Focus();
            }
            base.AfterSaving(Paras);
        }
        private async void txtEMailID_Validating(object sender, CancelEventArgs e)
        {
            if (txtEMailID.Text == "")
            {
                ErrorProvider.SetError(txtEMailID, "Please enter a valid Email-ID.");
            }
            else
            {
                Control ctrl = (Control)sender;

                if (!Regex.IsMatch(ctrl.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase) || ctrl.Text == "")
                {
                    ErrorProvider.SetError(ctrl, "This is not a valid email address. Enter the valid Email-ID.");
                }
                else if (await DALObj.IsDuplicateRecord(txtEMailID.Text, (Model.CommonProperties.CurrentRegistration == null ? 0 : Model.CommonProperties.CurrentRegistration.SoftwareRegistrationID)))
                {
                    ErrorProvider.SetError(ctrl, "Enterd email id is already in use.");
                }
                else
                {
                    ErrorProvider.SetError(ctrl, "");
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtPassword.Text.Length < 6 || txtPassword.Text.Length > 15)
            {
                ErrorProvider.SetError(txtPassword, "A password required of 6 to 15 characters long.");
            }
            else
            {
                ErrorProvider.SetError(txtPassword, "");
            }
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if(txtFullName.Text == "")
            {
                ErrorProvider.SetError(txtFullName, "Full name is required.");
            }
            else
            {
                ErrorProvider.SetError(txtFullName, "");
            }
        }

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if(txtCompanyName.Text == "")
            {
                ErrorProvider.SetError(txtCompanyName, "Company name is required.");
            }
            else
            {
                ErrorProvider.SetError(txtCompanyName, "");
            }
        }

        private void txtBusinessType_Validated(object sender, EventArgs e)
        {
            if(txtBusinessType.Text == "")
            {
                ErrorProvider.SetError(txtBusinessType, "Business type is required.");
            }
            else
            {
                ErrorProvider.SetError(txtBusinessType, "");
            }
        }
        private void txtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtMobileNo.Text == "")
            {
                ErrorProvider.SetError(txtMobileNo, "Mobile number is required.");
            }
            else
            {
                ErrorProvider.SetError(txtMobileNo, "");
            }
        }
        private void lookUpCity_Validating(object sender, CancelEventArgs e)
        {
            if(lookUpCity.EditValue == null)
            {
                ErrorProvider.SetError(lookUpCity, "Please select a City.");
            }
            else
            {
                ErrorProvider.SetError(lookUpCity, "");
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtEMailID.Text == "")
            {
                ErrorProvider.SetError(txtEMailID, "Please enter a valid Email-ID.");
                MessageBox.Show("Please enter a valid Email-ID.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEMailID.Focus();
                return;
            }
            else
            {
                Control ctrl = (Control)txtEMailID;

                if (!Regex.IsMatch(ctrl.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase) || ctrl.Text == "")
                {
                    MessageBox.Show("This is not a valid email address. Enter the valid Email-ID.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMailID.Focus();
                    return;
                }
            }

            base.ShowWaitForm();
            var APIResult = DALObj.GetRegistrationFromAdmin(txtEMailID.Text, txtPassword.Text);
            base.CloseWaitForm();
            if (APIResult.Success && APIResult.ResultObject != null)
            {
                var SavingResult = DALObj.SaveRegistrationLocal(new DAL.tblSoftwareRegistration()
                {
                    SoftwareRegistrationID = APIResult.ResultObject.SoftwareRegistrationID,
                    EMailID = APIResult.ResultObject.EMailID,
                    Password = APIResult.ResultObject.Password ?? "",
                    CompanyName = APIResult.ResultObject.CompanyName,
                    FullName = APIResult.ResultObject.FullName,
                    BusinessType = APIResult.ResultObject.BusinessType,
                    Address = APIResult.ResultObject.Address,
                    CityName = APIResult.ResultObject.CityName,
                    StateName = APIResult.ResultObject.StateName,
                    CountryName = APIResult.ResultObject.CountryName,
                    MobileNo = APIResult.ResultObject.PhoneNo,
                    PhoneNo = APIResult.ResultObject.MobileNo,
                }, Model.CommonProperties.CurrentRegistration == null);

                if (SavingResult.ExecutionResult != Model.eExecutionResult.CommitedSucessfuly)
                {
                    MessageBox.Show("Following error occured while saving registration information. Please contact to vender and provide following details.\r\n" + SavingResult.Exception.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    Navigation.frmDashBoard.DashBoard.CheckForRegistrationDetail();
                    this.Close();
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(APIResult.ErrorMessage))
                {
                    MessageBox.Show("Internet connection is not available or server unreachable.\r\nFollowing error occured while saving registration information. Please contact to vender and provide following details.\r\n" + APIResult.ErrorMessage, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!String.IsNullOrWhiteSpace(APIResult.ValidationMessage))
                {
                    MessageBox.Show("Please fix following errors before registrations. " + APIResult.ValidationMessage, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Email id or password did not matched." + APIResult.ValidationMessage, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtEMailID.Focus();
                return;
            }
        }


    }
}
