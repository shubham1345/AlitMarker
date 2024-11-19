using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.VoucherType
{
    public partial class frmVoucherTypeDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmVoucherTypeCRUD);
            }
        }

        public frmVoucherTypeDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new DAL.Account.VoucherType.VoucherTypeDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }
    }
}
