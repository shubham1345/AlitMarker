using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix
{
    public class LookupEditSaleReturnNoPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmSaleReturnNoPrefixCRUD);
            }
        }

        private DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix.SaleReturnNoPrefixDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix.SaleReturnNoPrefixDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "SaleReturnNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
