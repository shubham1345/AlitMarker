using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Account.VoucherType;
using System.ComponentModel;

namespace Alit.Marker.WinForm.Account.VoucherType
{
    public class LookupEditVoucherType : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmVoucherTypeCRUD);
            }
        }

        private DAL.Account.VoucherType.VoucherTypeDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Account.VoucherType.VoucherTypeDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            base.AssignFormatProperties();
            Properties.DisplayMember = "VoucherTypeName";
            Properties.ValueMember = "VoucherTypeID";
        }

        [DefaultValue(null)]
        [DisplayName("Primary Voucher Type")]
        public ePrimaryVoucherType PrimaryVoucherTypeFilter { get; set; }

        protected override object[] GetLookupListFilterParas()
        {
            return new object[]
            {
                PrimaryVoucherTypeFilter,
            };
        }
    }
}
