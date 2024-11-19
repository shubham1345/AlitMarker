using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix
{
    public partial class frmSaleInvoiceNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {
        SaleInvoiceNoPrefixDAL DALObject;
        public frmSaleInvoiceNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new SaleInvoiceNoPrefixDAL();

            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
