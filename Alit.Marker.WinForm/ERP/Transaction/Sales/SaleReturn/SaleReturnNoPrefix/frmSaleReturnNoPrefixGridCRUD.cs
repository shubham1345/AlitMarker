using Alit.Marker.DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix;
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

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix
{
    public partial class frmSaleReturnNoPrefixGridCRUD : Template.frmGridCRUDTemplate
    {
        SaleReturnNoPrefixDAL DALObject;
        public frmSaleReturnNoPrefixGridCRUD()
        {
            InitializeComponent();

            DALObject = new SaleReturnNoPrefixDAL();
            
            CrudGridControl = gridControl1;
            CrudGridView = gridView1;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
