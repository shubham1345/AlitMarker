using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Masters.StockItemTax
{
    public class StockItemTaxViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AdditionalItemID; } set { AdditionalItemID = value; } }

        [Browsable(false)]
        public long AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string ItemName { get; set; }

        [DisplayName("%")]
        public decimal Perc { get; set; }

        [DisplayName("Inclusive Tax")]
        public bool InclusiveTax { get; set; }

        [DisplayName("Category")]
        public long ProductTaxCategoryID { get; set; }
    }

    public class StockItemTaxLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AdditionalItemID; } set { AdditionalItemID = value; } }
                
        [Browsable(false)]
        public long AdditionalItemID { get; set; }

        [DisplayName("Name")]
        public string ItemName { get; set; }

        [DisplayName("%")]
        public decimal Perc { get; set; }

        [Browsable(false)]
        public bool InclusiveTax { get; set; }

        [Browsable(false)]
        public long ProductTaxCategoryID { get; set; }
    }
}
