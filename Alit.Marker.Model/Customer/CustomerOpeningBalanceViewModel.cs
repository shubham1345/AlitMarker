using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Customer
{

    public class CustomerOpeningBalanceViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {

        [Browsable(false)]
        public override long PrimeKeyID { get { return OpBalID; } set { OpBalID = value; } }

        [Browsable(false)]
        public long OpBalID { get; set; }

        [DisplayName("Opb.Date")]
        public DateTime OpBalanceDate { get; set; }

        [DisplayName("Opb. Amt"), DisplayFormat(DataFormatString = "#")]
        public decimal OpBalanceAmt { get; set; }

        [Browsable(false)]
        public long CustomerID { get; set; }

        public string Narration { get; set; }
    }

}
