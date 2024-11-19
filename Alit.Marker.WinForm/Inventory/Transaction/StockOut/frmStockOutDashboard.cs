using Alit.Marker.DAL.Inventory.Transaction.StockOut;
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

namespace Alit.Marker.WinForm.Inventory.Transaction.StockOut
{
    public partial class frmStockOutDashboard : Template.frmDashboardTemplate
    {
        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockOutCRUD);
            }
        }

        public frmStockOutDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new StockOutDAL();

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
    }
}
