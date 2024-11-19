using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo
{
    public class PurchaseReceiptNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseReceiptNoPrefixID; } set { PurchaseReceiptNoPrefixID = value; } }

        [Browsable(false)]
        public long PurchaseReceiptNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

    public class PurchaseReceiptNoPrefixLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseReceiptNoPrefixID; } set { PurchaseReceiptNoPrefixID = value; } }

        [Browsable(false)]
        public long PurchaseReceiptNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }
}
