using Alit.Marker.DAL.Account.Transactions.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Transactions.Payment
{
    public partial class frmPaymentDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPaymentCRUD);
            }
        }

        public frmPaymentDashboard()
        {
            InitializeComponent();
            DashboardDALObj = new PaymentDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }
    }
}
