using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix
{
    public class PurchaseReturnNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseReturnNoPrefixID; } set { PurchaseReturnNoPrefixID = value; } }

        [Browsable(false)]
        public long PurchaseReturnNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

    public class PurchaseReturnNoPrefixLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseReturnNoPrefixID; } set { PurchaseReturnNoPrefixID = value; } }

        [Browsable(false)]
        public long PurchaseReturnNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }
}
