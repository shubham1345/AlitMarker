using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTax
{
    public class LookupEditStockItemTax : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockItemTaxCRUD);
            }
        }

        DAL.Inventory.Masters.StockItemTax.StockItemTaxDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Masters.StockItemTax.StockItemTaxDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.ValueMember = "AdditionalItemID";
            Properties.DisplayMember = "ItemName";
            base.AssignFormatProperties();
        }
    }
}
