using Alit.Marker.DAL.Template;
using Alit.Marker.DBO;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Account.Account
{
    public class BookAccountLookupListDAL : ILookupListDAL
    {
        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }

        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            eAccountGroupType[] AccountGroupTypes = null;

            int count = 0;
            if (FilterParas != null)
            {
                if (FilterParas.Count() > count && FilterParas[count] is eAccountGroupType[])
                {
                    AccountGroupTypes = (eAccountGroupType[])FilterParas[count];
                }
            }
            return GetLookupListFinal(AccountGroupTypes);
        }

        //public List<AccountGroupLookupListModel> GetLookupList() { return GetLookupList(null); }

        public List<BookAccountLookUpListModel> GetLookupListFinal()
        {
            return GetLookupListFinal(null);
        }

        public List<BookAccountLookUpListModel> GetLookupListFinal(eAccountGroupType[] AccountGroupTypes)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var res = (from r in db.tblAccounts

                           join jaccg in db.tblAccountGroups on r.AccountGroupID equals jaccg.AccountGroupID
                           into gaccg from acg in gaccg.DefaultIfEmpty()

                           where r.rstate != (byte)eRecordState.Deactivated
                           && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID                           
                           orderby r.AccountName
                           select new BookAccountLookUpListModel()
                           {
                               RecordState = (eRecordState)r.rstate,
                               AccountID = r.AccountID,
                               AccountName = r.AccountName,
                               AccountGroupType = (acg != null ? (eAccountGroupType?)acg.GroupTypeID : null)
                           });

                if (AccountGroupTypes != null)
                {
                    res = res.Where(r => r.AccountGroupType != null && AccountGroupTypes.Contains((eAccountGroupType)r.AccountGroupType));
                }
                return res.ToList();
            }
        }
    }
}
