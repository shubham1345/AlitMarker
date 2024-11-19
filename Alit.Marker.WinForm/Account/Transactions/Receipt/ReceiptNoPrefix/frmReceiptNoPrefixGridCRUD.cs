using Alit.Marker.DAL.Account.Transactions.Receipt.ReceiptNoPrefix;
using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Account.Transactions.Receipt.ReceiptNoPrefix
{
    public partial class frmReceiptNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {

        ReceiptNoPrefixDAL DALObject;
        public frmReceiptNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new ReceiptNoPrefixDAL();


            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
