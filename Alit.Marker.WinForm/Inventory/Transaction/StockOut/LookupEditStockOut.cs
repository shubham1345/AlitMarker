using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockOut
{
    public class LookupEditStockOut : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockOutCRUD);
            }
        }

        DAL.Inventory.Transaction.StockOut.StockOutDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Transaction.StockOut.StockOutDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "VoucherNo";
            Properties.ValueMember = "StockOutID";
            base.AssignFormatProperties();
        }
    }
}
