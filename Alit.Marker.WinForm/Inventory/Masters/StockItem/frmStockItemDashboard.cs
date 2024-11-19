using Alit.Marker.DAL.Inventory;
using Alit.Marker.DAL.Inventory.Masters.StockItem;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItem
{
    public partial class frmStockItemDashboard : Inventory.frmInventoryDefaultDashboard
    {

        StockItemDashboardViewModel SelectedProduct;
        ProductOpeningStockDAL OpeningStockDALObj;
        StockItemDAL StockItemDALObj;

        public override Type CrudFormType
        {
            get
            {
                return typeof(frmStockItemCRUD);
            }
        }

        public frmStockItemDashboard()
        {
            InitializeComponent();

            DashboardDALObj = new StockItemDAL();
            OpeningStockDALObj = new ProductOpeningStockDAL();
            StockItemDALObj = new StockItemDAL();
            DashboardGridControl = gridControl1;
            DashboardGridView = gridView1;

            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode)
            {
                colPCode.Visible = false;
            }
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode)
            {
                colBarcode.Visible = false;
            }
            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.HSNCode)
            {
                colHSNCode.Visible = false;
            }
        }

        private void btnOpeningStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedProduct != null)
            {
                ProductOpeningStockViewModel OpeningStockViewModel = OpeningStockDALObj.GetViewModelByProductID(SelectedProduct.ProductID);

                using (Inventory.frmOpeningStock frm =
                    new Inventory.frmOpeningStock(new Model.Template.CRUDMTemplateParas()
                    {
                        FormDefaultUI = (OpeningStockViewModel == null ? Model.Template.eFormCurrentUI.NewEntry : Model.Template.eFormCurrentUI.Edit),
                        EditingRecord = OpeningStockViewModel,
                    }, SelectedProduct.ProductID))
                {
                    frm.ShowDialog();
                    ReloadDashboardData();
                    UpdateRowState();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateRowState();
        }

        void UpdateRowState()
        {
            SelectedProduct = (StockItemDashboardViewModel)gridView1.GetFocusedRow();


            if (SelectedProduct == null)
            {
                btnOpeningStock.Enabled = false;
                btnDeleteOpeningStock.Enabled = false;
            }
            else
            {
                btnOpeningStock.Enabled = true;
                btnDeleteOpeningStock.Enabled = (SelectedProduct.OpeningStockID != null);
            }
        }

        private void btnDeleteOpeningStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // need to fetch user's permission for product opening stock
            //if (UserMenuPermission != null)
            //{
            //    if (!UserMenuPermission.CanDelete)
            //    {
            //        Alit.WinformControls.MessageBox.Show(this, "Can not delete. You don't have permission to delete records.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            if (SelectedProduct == null || !SelectedProduct.OpeningStockID.HasValue)
            {
                return;
            }

            long PrimeKeyID = SelectedProduct.OpeningStockID.Value;
            var ValidationResult = OpeningStockDALObj.ValidateBeforeDelete(PrimeKeyID);

            if (ValidationResult.IsValidForDelete)
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Are you sure ? Do you want to delete opening stock of selected product ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletingParameter para = new DeletingParameter() { PrimeKeyID = PrimeKeyID };

                    ShowWaitForm();

                    para.DeletingResult = OpeningStockDALObj.DeleteRecord(PrimeKeyID, SelectedProduct.ProductID);

                    CloseWaitForm();

                    AfterDeleteRecord(para);

                    if (para.DeletingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                    {
                        ReloadDashboardData();
                        UpdateRowState();
                    }
                }
            }
            else
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not Delete.\r\n\r\n" + ValidationResult.ValidationMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnStockInHand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Reports.frmRepStockInHand frm = new Reports.frmRepStockInHand())
            {
                frm.ShowDialog();
            }
        }

        private void btnStockLedger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StockItemDashboardViewModel Row = (StockItemDashboardViewModel)gridView1.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            using (Reports.frmRepStockLedger frm = new Reports.frmRepStockLedger(Row.ProductID, null, null))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnOpeningStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StockItemDashboardViewModel Row = (StockItemDashboardViewModel)gridView1.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            var StockVoucherRecord = OpeningStockDALObj.GetViewModelByPrimeKey(Row.PrimeKeyID);
            //var EditingRecordOpeningStock = OpeningStockDALObj.GetViewModelByProductID(Row.ProductID);
            if (StockVoucherRecord == null)
            {
                using (Inventory.frmOpeningStock frm = new Inventory.frmOpeningStock(new Model.Template.CRUDMTemplateParas()
                {
                    FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry,

                }, Row.ProductID))
                {
                    frm.ShowDialog(this);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        ReloadDashboardData();
                        UpdateRowState();
                    }
                }
            }
            else
            {
                using (Inventory.frmOpeningStock frm = new Inventory.frmOpeningStock(new Model.Template.CRUDMTemplateParas()
                {
                    FormDefaultUI = Model.Template.eFormCurrentUI.Edit,
                    EditingRecord = StockVoucherRecord,

                }, Row.ProductID))
                {
                    frm.ShowDialog(this);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        ReloadDashboardData();
                        UpdateRowState();
                    }

                }
            }
        }

        private void frmStockItemDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
