using Alit.Marker.WinForm.Users.UserGroup;
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
    public partial class frmUserDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmUserCRUD);
            }
        }

        public frmUserDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.Users.User.UserDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        private void btnUserGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Navigation.frmNavigationDashboard.ShowForm<frmUserGroupGridCRUD>();
        }

    }
}
