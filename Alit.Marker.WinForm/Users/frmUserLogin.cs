using System;
using System.ComponentModel;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Users.User;
using Alit.Marker.Model.Users.User;
using Alit.Marker.DAL.Users.UserGroup;


namespace Alit.Marker.WinForm.Users
{
    public partial class frmUserLogin : Template.frmNormalTemplate
    {
        UserDAL DALObj;
        UserGroupDAL UserGroupDALObj;

        #region Constructor

        public frmUserLogin()
        {
            InitializeComponent();
            AllowRefresh = false;
            SaveButtonCaption = "Login";
            ExitButtonCaption = "Cancel";

            DALObj = new DAL.Users.User.UserDAL();
            UserGroupDALObj = new DAL.Users.UserGroup.UserGroupDAL();
            FirstControl = txtUserName;
        }
        #endregion

        #region Overidden Methods
        protected override void OnSaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = new SavingResult();

            UserDetailModel loginUser = DALObj.GetUserDetailModel(txtUserName.Text, txtPassword.Text);
            if (loginUser == null)
            {
                Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                Paras.SavingResult.ValidationError = "Please check, User Name or Password not matched.";
                return;
                //Alit.WinformControls.MessageBox.Show(this, "Please check, user name or password not matched.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //txtUserName.Focus();
                //return;
            }
            else
            {
                Model.CommonProperties.LoginInfo.LoggedinUser = loginUser;
                if (chkeRememberMe.Checked)
                {
                    Properties.Settings.Default.UserLoginRememberMe = true;
                    Properties.Settings.Default.UserLoginRememberMeUserID = loginUser.UserID;
                }
                else
                {
                    Properties.Settings.Default.UserLoginRememberMe = false;
                    Properties.Settings.Default.UserLoginRememberMeUserID = 0;
                }
                Properties.Settings.Default.Save();
            }


            Model.CommonProperties.LoginInfo.UserPermission = UserGroupDALObj.GetPermission(Model.CommonProperties.LoginInfo.LoggedinUser.UserGroupID);

            Paras.SavingResult.ExecutionResult = eExecutionResult.NotExecutedYet;

            base.OnSaveRecord(Paras);
        }
        protected override void OnAssignFormValues()
        {
            if (Properties.Settings.Default.UserLoginRememberMe)
            {
                chkeRememberMe.Checked = true;
            }
            base.OnAssignFormValues();
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult != null && (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly ||
                Paras.SavingResult.ExecutionResult == eExecutionResult.NotExecutedYet))
            {
                this.DialogResult = DialogResult.OK;
            }
            base.OnAfterSaving(Paras);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            if (!backgroundWorker1.IsBusy && !FormActivatedLater)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        #endregion

        #region Events

        bool FormActivatedLater;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dt = DateTime.Now.AddMilliseconds(100);
            while (dt > DateTime.Now) { }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { this.Activate(); });
                FormActivatedLater = true;
            }
            catch { }
        }

        #endregion


    }
}