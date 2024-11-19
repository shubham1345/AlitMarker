using Alit.Marker.DAL.Inventory.Transaction.StockIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockIn
{
    public partial class frmStockInDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockInCRUD);
            }
        }

        public frmStockInDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new StockInDAL();

            DashboardGridControl = gridControl1;
            DashboardGridView = gridViewHeader;
        }

        protected override void FormatDashboardGridView(GridView DashboardGridView)
        {
            base.FormatDashboardGridView(DashboardGridView);
            //--
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode)
            {
                gridViewHeader.Columns.Remove(colPCode);
            }
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode)
            {
                gridViewHeader.Columns.Remove(colBarcode);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
