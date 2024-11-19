using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix
{
    public class LookupEditSaleOrderPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleOrderNoPrefix);
            }
        }

        private DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix.SaleOrderNoPrefixDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix.SaleOrderNoPrefixDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "SaleOrderNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
