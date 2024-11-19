using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory
{
    public class StockItemTaxCategoryViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductTaxCategoryID; } set { ProductTaxCategoryID = value; } }

        [Browsable(false)]
        public long ProductTaxCategoryID { get; set; }

        [DisplayName("Stock Item Tax Category Name")]
        public string ProductTaxCategoryName { get; set; }

        [DisplayName("Interstate Tax")]
        public bool IsInterstateTax { get; set; }

        [DisplayName("Tax Index")]
        public int TaxIndex { get; set; }

        [DisplayName("Applicable")]
        public bool Applicable { get; set; }
    }

    public class StockItemTaxCategoryLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductTaxCategoryID; } set { ProductTaxCategoryID = value; } }

        [Browsable(false)]
        public long ProductTaxCategoryID { get; set; }

        [DisplayName("Name")]
        public string ProductTaxCategoryName { get; set; }

        [DisplayName("Interstate Tax")]
        public bool IsInterstateTax { get; set; }


        [Browsable(false)]
        public int TaxIndex { get; set; }

        [Browsable(false)]
        public bool Applicable { get; set; }
    }
}
