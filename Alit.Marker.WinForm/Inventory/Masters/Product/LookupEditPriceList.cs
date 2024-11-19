using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.Product
{
    public class LookupEditPriceList : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmPriceListCRUD);
            }
        }

        private DAL.Inventory.Masters.Product.PriceListDAL DALObj;
        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Inventory.Masters.Product.PriceListDAL();
            }
            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PriceListName";
            Properties.ValueMember = "PriceListID";
            Properties.PopupWidth = 500;
            base.AssignFormatProperties();
        }
    }
}
