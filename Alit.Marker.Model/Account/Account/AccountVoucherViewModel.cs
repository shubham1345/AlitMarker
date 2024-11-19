using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Account
{
    public class AccountVoucherViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AccountVoucherID; } set { value = AccountVoucherID; } }

        [Browsable(false)]
        public long AccountVoucherID { get; set; }
                
        public DateTime VoucherDate { get; set; }
               
        public string VoucherNo { get; set; }

        public long VoucherTypeID { get; set; }

        public decimal Amount { get; set; }

        public long? CustomerAccountID { get; set; }

        public long? BookAccountID { get; set; }

        public string Narration { get; set; }

        public List<AccountVoucherDetaillViewModel> AccountVoucherDetails { get; set; }

    }

    public class AccountVoucherDetaillViewModel
    {
        [Browsable(false)]
        public long VoucherDetailID { get; set; }

        public long AccountVoucherID { get; set; }

        public long AccountID { get; set; }

        public decimal Amount { get; set; }

        public string Narration { get; set; }
    }
}
