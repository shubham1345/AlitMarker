using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Account.Group;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;

namespace Alit.Marker.WinForm.Account.Group
{
    public class LookupEditAccountGroupType : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                //throw new NotImplementedException();
                return null;
            }
        }

        private DAL.Account.Group.AccountGroupTypeDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Account.Group.AccountGroupTypeDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "AccountGroupTypeName";
            Properties.ValueMember = "AccounGroupTypeID";
            base.AssignFormatProperties();
        }

        [DefaultValue(null)]
        [DisplayName("Account Group Nature")]
        public eAccountGroupNature[] AccountGroupNatureFilter { get; set; }

        protected override object[] GetLookupListFilterParas()
        {
            return new object[]
            {
                AccountGroupNatureFilter
            };
        }

    }
}
