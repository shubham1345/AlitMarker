using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory.Masters.Unit
{   
    public class UnitViewModel : Template.GridCRUDViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UnitID; } set { UnitID = value; } }

        [Browsable(false)]
        public long UnitID { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }
    }

    public class UnitLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return UnitID; } set { UnitID = value; } }

        [Browsable(false)]
        public long UnitID { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }
    }
}
