using Alit.Marker.DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix;
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

namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix
{
    public partial class frmPurchaseReturnNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {
        PurchaseReturnNoPrefixDAL DALObject;
        public frmPurchaseReturnNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new PurchaseReturnNoPrefixDAL();

            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
