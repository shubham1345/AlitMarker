using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix
{
    public class SaleInvoiceNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleInvoiceNoPrefixID; } set { SaleInvoiceNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleInvoiceNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string PrefixName { get; set; }
    }

    public class SaleInvoiceNoPrefixLookupListModel : Template.LookupListViewModel 
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleInvoiceNoPrefixID; } set { SaleInvoiceNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleInvoiceNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }
}
