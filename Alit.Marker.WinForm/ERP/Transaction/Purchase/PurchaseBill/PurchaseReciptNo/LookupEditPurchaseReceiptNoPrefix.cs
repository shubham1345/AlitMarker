using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo
{
    public class LookupEditPurchaseReceiptNoPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPurchaseReceiptNoPrefixCRUD);
            }
        }

        private DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "PurchaseReceiptNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
