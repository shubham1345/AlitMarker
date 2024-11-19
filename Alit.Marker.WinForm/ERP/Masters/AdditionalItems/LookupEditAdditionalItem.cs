using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using System.ComponentModel;
using Alit.Marker.Model.TransactionsCommon;

namespace Alit.Marker.WinForm.ERP.Masters.AdditionalItems
{
    public class LookupEditAdditionalItem : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmAdditionalItemCRUD);
            }
        }

        [DefaultValue(null)]
        [DisplayName("Additional Item Filter")]
        public eAdditionalItemType? AdditionalItemTypeFilter { get; set; }

        DAL.ERP.Masters.AdditionalItems.AdditionalItemDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Masters.AdditionalItems.AdditionalItemDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "AddnitionalItemName";
            Properties.ValueMember = "AdditionalItemID";
            base.AssignFormatProperties();
        }
        
        protected override object[] GetLookupListFilterParas()
        {
            return new object[] { AdditionalItemTypeFilter };
        }
    }
}
