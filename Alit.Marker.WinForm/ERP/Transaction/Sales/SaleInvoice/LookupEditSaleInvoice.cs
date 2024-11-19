using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice
{
    public class LookupEditSaleInvoice : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleInvoiceCRUD);
            }
        }

        DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "SaleInvoiceDisplay";
            Properties.ValueMember = "SaleInvoiceID";
            base.AssignFormatProperties();
        }
    }
}
