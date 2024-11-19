using Alit.Marker.DAL.Inventory.Masters.StockItemTax;
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTax
{
    public partial class frmStockItemTaxGridCRUD : Template.frmGridCRUDTemplate
    {
        StockItemTaxDAL DALObject;

        StockItemTaxCategoryDAL StockItemTaxCategoryDALObj;
        List<StockItemTaxCategoryLookUpListModel> dsStockItemTaxCategory;

        public frmStockItemTaxGridCRUD()
        {
            InitializeComponent();

            DALObject = new StockItemTaxDAL();
            StockItemTaxCategoryDALObj = new StockItemTaxCategoryDAL();

            CrudGridControl = gcStockItemTax;
            CrudGridView = gvStockItemTax;
        }

        protected override void LoadLookupDataSource()
        {
            dsStockItemTaxCategory = StockItemTaxCategoryDALObj.GetLookUpList();
            base.LoadLookupDataSource();
        }

        protected override void AssignLookupDataSource()
        {
            repositoryItemLookUpEditProductTax.ValueMember = "ProductTaxCategoryID";
            repositoryItemLookUpEditProductTax.DisplayMember = "ProductTaxCategoryName";
            repositoryItemLookUpEditProductTax.DataSource = dsStockItemTaxCategory;

            base.AssignLookupDataSource();
        }

        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            if (DALObject == null)
            {
                DALObject = new StockItemTaxDAL();
            }
            return DALObject;
        }        
    }
}
