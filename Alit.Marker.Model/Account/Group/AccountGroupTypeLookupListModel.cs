using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Group
{
    public enum eAccountGroupType
    {
        None = 0,
        CapitalAccount = 1,
        FixedAssets = 2,
        CurrentAssets = 3,
        CurrentLiabilities = 4,
        BankAccounts = 5,
        CashInHand = 6,
        DirectExpenses = 7,
        DirectIncome = 8,
        IndirectExpenses = 9,
        IndirectIncomes = 10,
        SalesAccounts = 11,
        PurchaseAccounts = 12,
        SundryCreditors = 13,
        SundryDebtors = 14,
        DutiesAndTaxes = 15
    }

    public class AccountGroupTypeLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return (int)AccounGroupTypeID; } set { AccounGroupTypeID = (eAccountGroupType)value; } }

        [Browsable(false)]
        public eAccountGroupType AccounGroupTypeID { get; set; }

        [DisplayName("Group Type Name")]
        public string AccountGroupTypeName { get; set; }

        [Browsable(false)]
        public eAccountGroupNature AccountGroupNature { get; set; }
    }
}
