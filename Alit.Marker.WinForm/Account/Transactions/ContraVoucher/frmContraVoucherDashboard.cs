using Alit.Marker.DAL.Account.Transactions.ContraVoucher;
using Alit.Marker.DAL.Account.Transactions.JournalVoucher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Transactions.ContraVoucher
{
    public partial class frmContraVoucherDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmContraVoucherCRUD);
            }
        }

        public frmContraVoucherDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new ContraVoucherDAL();
            DashboardGridControl = gcContraVoucher;
            DashboardGridView = gvContraVoucher;
        }
    }
}
