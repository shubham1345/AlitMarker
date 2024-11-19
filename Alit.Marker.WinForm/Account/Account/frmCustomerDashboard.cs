using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.WinForm.Account.Account
{
    public class frmCustomerDashboard : frmAccountBaseDashboard
    {
        public frmCustomerDashboard() : base(Model.Account.Account.eAccountFormType.Customer)
        {

        }
    }
}
