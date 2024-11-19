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
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTaxCategory
{
    public partial class frmStockItemTaxCategoryGridCRUD : Template.frmGridCRUDTemplate
    {
        StockItemTaxCategoryDAL DALObject;

        public frmStockItemTaxCategoryGridCRUD()
        {
            InitializeComponent();
            DALObject = new StockItemTaxCategoryDAL();

            CrudGridControl = gcStockItemTaxCategory;
            CrudGridView = gvStockItemTaxCategory;
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return DALObject;
        }
    }
}
