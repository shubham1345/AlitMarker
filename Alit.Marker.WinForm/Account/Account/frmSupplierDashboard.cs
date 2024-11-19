using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.WinForm.Account.Account
{
    public class frmSupplierDashboard : frmAccountBaseDashboard
    {
        public frmSupplierDashboard() : base(Model.Account.Account.eAccountFormType.Supplier)
        {
        }
    }
}
