using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Customer
{
    public class LookupEditCustomer : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmCustomerCRUD);
            }
        }

        private DAL.Customer.CustomerDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Customer.CustomerDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "CustomerName";
            Properties.ValueMember = "CustomerID";
            this.Properties.DropDownRows = 15;
            this.Properties.ImmediatePopup = true;
            this.Properties.NullText = "Select Customer";
            this.Properties.PopupWidth = 1000;
            base.AssignFormatProperties();
        }
    }
}
