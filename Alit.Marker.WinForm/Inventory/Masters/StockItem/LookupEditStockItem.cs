using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItem
{
    public class LookupEditStockItem : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockItemCRUD);
            }
        }

        DAL.Inventory.Masters.StockItem.StockItemDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Masters.StockItem.StockItemDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "ProductName";
            Properties.ValueMember = "ProductID";
            base.AssignFormatProperties();
        }
    }
}
