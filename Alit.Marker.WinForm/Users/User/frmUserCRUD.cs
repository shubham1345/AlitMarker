using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Users;
using Alit.Marker.Model.Users.User;
using Alit.Marker.Model.Users.UserGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Users.User
{
    public partial class frmUserCRUD : Template.frmCRUDTemplate
    {
        DAL.Users.User.UserDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new DAL.Users.User.UserDAL();
                }

                return DALObject;
            }
        }

        public frmUserCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmUserCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new DAL.Users.User.UserDAL();
        }

        #region Override Methods

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new UserViewModel()
            {
                UserID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                UserGroupID = (long)lueUserGroup.EditValue,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            UserViewModel ViewModel = (UserViewModel)RecordToFill;
            txtUserName.Text = ViewModel.UserName;
            txtPassword.Text = ViewModel.Password;
            lueUserGroup.EditValue = ViewModel.UserGroupID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                ErrorProvider.SetError(txtUserName, "Please enter User Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtUserName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtUserName, "Can not accept duplicate User Name.");
            }
            else
            {
                ErrorProvider.SetError(txtUserName, null);
            }
        }

        private void lueUserGroup_Validating(object sender, CancelEventArgs e)
        {
            if (lueUserGroup.EditValue == null)
            {
                ErrorProvider.SetError(lueUserGroup, "Please select User Group.");
            }
            else
            {
                ErrorProvider.SetError(lueUserGroup, null);
            }
        }
        #endregion

    }
}