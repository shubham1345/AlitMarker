using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix
{
    public class SaleOrderNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleOrderNoPrefixID; } set { SaleOrderNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleOrderNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

    public class SaleOrderNoPrefixLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleOrderNoPrefixID; } set { SaleOrderNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleOrderNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }
}
