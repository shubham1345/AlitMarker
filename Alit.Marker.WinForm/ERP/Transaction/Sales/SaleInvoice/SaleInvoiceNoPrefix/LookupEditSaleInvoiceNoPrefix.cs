using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix
{
    public class LookupEditSaleInvoiceNoPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleInvoiceNoPrefixCRUD);
            }
        }

        private DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix.SaleInvoiceNoPrefixDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix.SaleInvoiceNoPrefixDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "SaleInvoiceNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
