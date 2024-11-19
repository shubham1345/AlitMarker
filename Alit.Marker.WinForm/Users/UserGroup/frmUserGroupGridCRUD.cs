using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.Users.UserGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Users.UserGroup
{
    public partial class frmUserGroupGridCRUD : Template.frmGridCRUDTemplate
    {
        UserGroupDAL DALObj;

        public frmUserGroupGridCRUD()
        {
            InitializeComponent();

            DALObj = new UserGroupDAL();

            CrudGridControl = gcUserGroup;
            CrudGridView = gvUserGroup;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObj;
        }
    }
}
