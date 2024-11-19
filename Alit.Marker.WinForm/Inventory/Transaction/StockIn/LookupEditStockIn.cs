using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockIn
{
    public class LookupEditStockIn : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockInCRUD);
            }
        }

        DAL.Inventory.Transaction.StockIn.StockInDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Transaction.StockIn.StockInDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "VoucherNo";
            Properties.ValueMember = "StockInID";
            base.AssignFormatProperties();
        }
    }
}
