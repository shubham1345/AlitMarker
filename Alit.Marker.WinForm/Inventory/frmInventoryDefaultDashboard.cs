using Alit.Marker.WinForm.Inventory.Masters.Product;
using Alit.Marker.WinForm.Inventory.Masters.StockItemTax;
using Alit.Marker.WinForm.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.WinForm.Inventory.Masters.Unit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Inventory
{
    public partial class frmInventoryDefaultDashboard : Template.frmDashboardTemplate
    {
        public frmInventoryDefaultDashboard()
        {
            InitializeComponent();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;
        }


        private void btnUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmUnitGridCrud frm = new frmUnitGridCrud())
            {
                frm.ShowDialog();
            }
        }

        private void btnPriceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmPriceListGridCRUD frm = new frmPriceListGridCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnStockItemTax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmStockItemTaxGridCRUD frm = new frmStockItemTaxGridCRUD())
            {
                frm.ShowDialog();
            }
        }

        private void btnStockItemTaxCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmStockItemTaxCategoryGridCRUD frm = new frmStockItemTaxCategoryGridCRUD())
            {
                frm.ShowDialog();
            }
        }
    }
}
