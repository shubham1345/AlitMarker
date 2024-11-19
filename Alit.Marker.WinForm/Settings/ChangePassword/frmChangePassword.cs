using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Users.User;
using DevExpress.XtraEditors;

namespace Alit.Marker.WinForm.Settings.ChangePassword
{
    public partial class frmChangePassword : Template.frmNormalTemplate
    {
        UserDAL UserDAL;
        bool ISPasswordMatch = false;

        #region Constructor
        public frmChangePassword()
        {
            InitializeComponent();
            UserDAL = new UserDAL();
        }
        #endregion

        #region Overridden Methods

        protected override void OnSaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = new SavingResult();
            if (Model.CommonProperties.LoginInfo.LoggedinUser.UserID == 0)
            {
                Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                Paras.SavingResult.ValidationError = "Please check, User not found.";
                return;
            }
            else
            { 
                Paras.SavingResult = UserDAL.UpdatePassword(Model.CommonProperties.LoginInfo.LoggedinUser.UserID, txtCurrentPassword.Text,txtNewPassword.Text,txtConfirmPassword.Text);              
            }         
            base.OnSaveRecord(Paras);           
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            base.OnAfterSaving(Paras);
            if (Paras.SavingResult != null)
            {
                if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }            
        }
#endregion

        #region Validation
        private void txtCurrentPassword_Validating_1(object sender, CancelEventArgs e)
        {
            ISPasswordMatch = UserDAL.IsPasswordMatch(Model.CommonProperties.LoginInfo.LoggedinUser.UserID, txtCurrentPassword.Text);
            if (ISPasswordMatch == false)
            {
                ErrorProvider.SetError(txtCurrentPassword, "Current Password did not match. Please enter valid Password.");
            }
            else
            {
                ErrorProvider.SetError(txtCurrentPassword, null);
            }
        }

        private void txtConfirmPassword_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ErrorProvider.SetError(txtConfirmPassword, "New Password and Confirm Password should be same.");
            }
            else
            {
                ErrorProvider.SetError(txtConfirmPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text == txtCurrentPassword.Text && ISPasswordMatch == true)
            {
                ErrorProvider.SetError(txtNewPassword, "New Password and Current Password can not be same.");
            }
            else
            {
                ErrorProvider.SetError(txtNewPassword, null);
            }
        }
        #endregion


    }
}
