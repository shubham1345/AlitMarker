using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Users.UserGroup
{
    public class LookupEditUserGroup : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmUserGroupCRUD);
            }
        }

        private DAL.Users.UserGroup.UserGroupDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Users.UserGroup.UserGroupDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "UserGroupName";
            Properties.ValueMember = "UserGroupID";
            base.AssignFormatProperties();
        }
    }
}
