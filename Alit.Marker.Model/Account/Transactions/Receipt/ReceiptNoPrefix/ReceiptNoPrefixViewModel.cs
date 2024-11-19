using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.Receipt.ReceiptNoPrefix
{
    public class ReceiptNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ReceiptNoPrefixID; } set { ReceiptNoPrefixID = value; } }

        [Browsable(false)]
        public long ReceiptNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

    public class ReceiptNoPrefixLookupModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ReceiptNoPrefixID; } set { ReceiptNoPrefixID = value; } }

        [Browsable(false)]
        public long ReceiptNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }
}
