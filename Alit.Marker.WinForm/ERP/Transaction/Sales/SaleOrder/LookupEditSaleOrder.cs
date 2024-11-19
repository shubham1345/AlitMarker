using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;
using System.ComponentModel;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder
{
    public class LookupEditSaleOrder : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleOrderCRUD);
            }
        }

        [DefaultValue(null)]
        public long? CustomerID { get; set; }

        [DefaultValue(null)]
        public bool PendingSaleOrderOnly { get; set; }

        [DefaultValue(null)]
        public long? IncluseSaleOrderID { get; set; }

        private DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "SaleOrderNo"; 
            Properties.ValueMember = "SaleOrderID";
            base.AssignFormatProperties();
        }

        protected override object[] GetLookupListFilterParas()
        {
            return new object[] { CustomerID, PendingSaleOrderOnly, IncluseSaleOrderID };
        }
    }
}
