using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using System.ComponentModel;

namespace Alit.Marker.WinForm.Account.Group
{
    public class LookupEditAccountGroup : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAccountGroupCRUD);
            }
        }

        private DAL.Account.Group.AccountGroupDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Account.Group.AccountGroupDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "AccountGroupName";
            Properties.ValueMember = "AccountGroupID";
            base.AssignFormatProperties();
        }


        [DefaultValue(null)]
        [DisplayName("Parent Account Group ID Filter")]
        public int? ParentAccountGroupIDFilter { get; set; }

        [DefaultValue(null)]
        [DisplayName("Show Only Primary Groups Filter")]
        public bool? ShowOnlyPrimaryAccountGroups { get; set; }

        protected override object[] GetLookupListFilterParas()
        {
            return new object[]
            {
                ParentAccountGroupIDFilter,
                ShowOnlyPrimaryAccountGroups,
            };
        }
    }
}
