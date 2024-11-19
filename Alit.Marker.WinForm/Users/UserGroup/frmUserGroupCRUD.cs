using Alit.Marker.DAL.Users;
using Alit.Marker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.Users.UserGroup;
using Alit.Marker.Model.Users.UserGroup;

namespace Alit.Marker.WinForm.Users.UserGroup
{
    public partial class frmUserGroupCRUD : Template.frmCRUDTemplate
    {
        UserGroupDAL DALObj;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObj == null)
                {
                    DALObj = new UserGroupDAL();
                }

                return DALObj;
            }
        }

        public frmUserGroupCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmUserGroupCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObj = new DAL.Users.UserGroup.UserGroupDAL();            
        }

        #region Override Methods
        
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new UserGroupViewModel()
            {
                UserGroupID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                UserGroupName = txtUserGroupName.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            UserGroupViewModel EditingRecord = (UserGroupViewModel)RecordToFill;
            txtUserGroupName.Text = EditingRecord.UserGroupName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtUseGroupName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUserGroupName.Text))
            {
                ErrorProvider.SetError(txtUserGroupName, "Please enter User Group Name.");
            }
            else if (DALObj.IsDuplicateRecord(txtUserGroupName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtUserGroupName, "Can not accept duplicate User Group Name.");
            }
            else
            {
                ErrorProvider.SetError(txtUserGroupName, null);
            }
        }

        #endregion

    }
}
