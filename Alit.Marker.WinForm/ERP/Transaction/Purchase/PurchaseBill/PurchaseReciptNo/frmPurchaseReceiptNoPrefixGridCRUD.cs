using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo;
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

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo
{
    public partial class frmPurchaseReceiptNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {
        PurchaseReceiptNoPrefixDAL DALObject;
        public frmPurchaseReceiptNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new PurchaseReceiptNoPrefixDAL();

            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
