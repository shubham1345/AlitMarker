using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Account.Transactions.Receipt.ReceiptNoPrefix
{
    public class LookupEditReceiptNoPrefix : Template.LookupEditListTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmReceiptNoPrefixCRUD);
            }
        }
        private DAL.Account.Transactions.Receipt.ReceiptNoPrefix.ReceiptNoPrefixDAL DALObj;

        protected override ILookupListDAL GetDALObject()
        {
            if (DALObj == null)
            {
                DALObj = new DAL.Account.Transactions.Receipt.ReceiptNoPrefix.ReceiptNoPrefixDAL();
            }

            return DALObj;
        }

        protected override void AssignFormatProperties()
        {
            Properties.DisplayMember = "PrefixName";
            Properties.ValueMember = "ReceiptNoPrefixID";
            base.AssignFormatProperties();
        }
    }
}
