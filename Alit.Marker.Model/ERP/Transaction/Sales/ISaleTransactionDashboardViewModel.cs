using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales
{
    public interface ISaleTransactionDashboardViewModel
    {
        long PrimeKeyID { get; set; }


        long CustomerID { get; set; }


        DateTime TransactionDate { get; set; }
    }
}
