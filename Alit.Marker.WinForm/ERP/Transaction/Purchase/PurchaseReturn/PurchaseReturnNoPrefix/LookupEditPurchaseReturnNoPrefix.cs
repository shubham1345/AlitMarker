using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix
{
    public class LookupEditPurchaseReturnNoPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPurchaseReturnNoPrefix);
            }
        }

        private DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "PurchaseReturnNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
