using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using System.ComponentModel;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.Model.Account.Group;

namespace Alit.Marker.WinForm.Account.Account
{
    public class LookupEditAccount : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAccountCRUD);
            }
        }

        private DAL.Account.Account.AccountDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Account.Account.AccountDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "AccountName";
            Properties.ValueMember = "AccountID";
            base.AssignFormatProperties();
        }

        ////[DefaultValue(null)]
        ////[DisplayName("Account Type")]
        ////public eAccountLookupType? eAccountType { get; set; }

        [DefaultValue(null)]
        [DisplayName("Account Group Type")]
        public eAccountGroupType[] AccountGroupTypeFilter { get; set; }

        protected override object[] GetLookupListFilterParas()
        {
            return new object[]
            {
                AccountGroupTypeFilter
            };
        }
    }
}
