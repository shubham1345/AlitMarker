using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Masters.Product
{
    public class PriceListViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PriceListID; } set { PriceListID = value; } }

        [Browsable(false)]
        public long PriceListID { get; set; }

        [DisplayName("Name")]
        public string PriceListName { get; set; }

        [DisplayName("Short Name")]
        public string PriceListShortName { get; set; }
    }

    public class PriceListLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PriceListID; } set { PriceListID = value; } }

        [Browsable(false)]
        public long PriceListID { get; set; }

        [DisplayName("Name")]
        public string PriceListName { get; set; }

        [DisplayName("Short Name")]
        public string PriceListShortName { get; set; }
    }
}
