using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Group
{
    public partial class frmAccountGroupDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAccountGroupCRUD);
            }
        }

        public frmAccountGroupDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.Account.Group.AccountGroupDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }

        
    }
}
