using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix
{
    public class SaleReturnNoPrefixViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleReturnNoPrefixID; } set { SaleReturnNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleReturnNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

    public class SaleReturnNoPrefixLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleReturnNoPrefixID; } set { SaleReturnNoPrefixID = value; } }

        [Browsable(false)]
        public long SaleReturnNoPrefixID { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }
    }

}

