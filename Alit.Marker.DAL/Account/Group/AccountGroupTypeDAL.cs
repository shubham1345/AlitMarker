using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Group;

namespace Alit.Marker.DAL.Account.Group
{
    public class AccountGroupTypeDAL : ILookupListDAL
    {
        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            eAccountGroupNature[] AccountGroupNature = null;

            int count = 0;
            if (FilterParas != null)
            {
                if (FilterParas.Count() > count && FilterParas[count] is eAccountGroupNature[])
                {
                     AccountGroupNature = (eAccountGroupNature[])FilterParas[count];
                }
            }
            return GetLookupListFinal(AccountGroupNature);
        }

        public List<AccountGroupTypeLookupListModel> GetLookupList() { return GetLookupListFinal(null); }

        public List<AccountGroupTypeLookupListModel> GetLookupListFinal(eAccountGroupNature[] AccountGroupNatures)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                List<AccountGroupTypeLookupListModel> AccountGroupTypes = GetAccountGroupTypes();

                if (AccountGroupNatures != null && AccountGroupNatures.Count() > 0 )
                {
                    return (from gt in AccountGroupTypes

                            join jgn in AccountGroupNatures on gt.AccountGroupNature equals jgn

                            select gt).ToList();
                }
                else
                {
                    return AccountGroupTypes;
                }
            }
        }

        public List<AccountGroupTypeLookupListModel> GetAccountGroupTypes()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                List<AccountGroupTypeLookupListModel> AccountGroupTypes = new List<AccountGroupTypeLookupListModel>();

                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.CapitalAccount, AccountGroupTypeName = "Capital Account", AccountGroupNature = eAccountGroupNature.Liablities });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.FixedAssets, AccountGroupTypeName = "Fixed Assets", AccountGroupNature = eAccountGroupNature.Asset });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.CurrentAssets, AccountGroupTypeName = "Current Assets", AccountGroupNature = eAccountGroupNature.Asset });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.CurrentLiabilities, AccountGroupTypeName = "CurrentLiabilities", AccountGroupNature = eAccountGroupNature.Liablities });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.BankAccounts, AccountGroupTypeName = "Bank Accounts", AccountGroupNature = eAccountGroupNature.Asset });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.CashInHand, AccountGroupTypeName = "Cash-in-Hand", AccountGroupNature = eAccountGroupNature.Asset });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.DirectExpenses, AccountGroupTypeName = "Direct Expenses", AccountGroupNature = eAccountGroupNature.Expences });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.DirectIncome, AccountGroupTypeName = "Direct Income", AccountGroupNature = eAccountGroupNature.Income });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.IndirectExpenses, AccountGroupTypeName = "Indirect Expenses", AccountGroupNature = eAccountGroupNature.Expences });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.IndirectIncomes, AccountGroupTypeName = "Indirect Incomes", AccountGroupNature = eAccountGroupNature.Income });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.SalesAccounts, AccountGroupTypeName = "Sales Accounts", AccountGroupNature = eAccountGroupNature.Income });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.PurchaseAccounts, AccountGroupTypeName = "Purchase Accounts", AccountGroupNature = eAccountGroupNature.Expences });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.SundryCreditors, AccountGroupTypeName = "Sundry Creditors", AccountGroupNature = eAccountGroupNature.Liablities });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.SundryDebtors, AccountGroupTypeName = "Sundry Debtors", AccountGroupNature = eAccountGroupNature.Asset });
                AccountGroupTypes.Add(new AccountGroupTypeLookupListModel() { AccounGroupTypeID = eAccountGroupType.DutiesAndTaxes, AccountGroupTypeName = "Duties & Taxes", AccountGroupNature = eAccountGroupNature.Liablities });
                return AccountGroupTypes;
            }
        }
       
    }
}
