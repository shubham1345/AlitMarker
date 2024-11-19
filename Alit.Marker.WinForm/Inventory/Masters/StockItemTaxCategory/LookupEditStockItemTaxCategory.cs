using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTaxCategory
{
    public class LookupEditStockItemTaxCategory : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockItemTaxCategoryCRUD);
            }
        }

        DAL.Inventory.Masters.StockItemTaxCategory.StockItemTaxCategoryDAL DALObj;
         
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Masters.StockItemTaxCategory.StockItemTaxCategoryDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "ProductTaxCategoryName";
            Properties.ValueMember = "ProductTaxCategoryID";
            base.AssignFormatProperties();
        }
    }
}
