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
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix
{
    public partial class frmSaleOrderNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {

        SaleOrderNoPrefixDAL DALObject;
        public frmSaleOrderNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new SaleOrderNoPrefixDAL();


            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
