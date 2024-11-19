using Alit.Marker.DAL.Inventory.Transaction.StockIn;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Transaction.StockIn;
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
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Inventory.Masters.Unit;
using Alit.Marker.DAL.Inventory.Masters.Unit;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Inventory.Masters.StockItem;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockIn
{
    public partial class frmStockInCRUD : Template.frmCRUDTemplate
    {
        StockInDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StockInDAL();
                }

                return DALObject;
            }
        }

        StockItemDAL StockItemDALObj;
        List<StockItemLookupListModel> dsStockItem;

        UnitDAL UnitDALObj;
        List<UnitLookupListModel> dsUnit;

        List<StockInProductDetailViewModel> dsProductDetail;

        public frmStockInCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStockInCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObject = new StockInDAL();
            StockItemDALObj = new StockItemDAL();
            UnitDALObj = new UnitDAL();

            colProductNo.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductCode;
            colBarcode.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByBarcode;
            colProductName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductName;

            colRate.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnRate;
            colRate.OptionsColumn.AllowFocus = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;
            colRate.OptionsColumn.ReadOnly = !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;

            colUnitName.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddUnitColumn;
            colUnitName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnUnit;

            dsProductDetail = new List<StockInProductDetailViewModel>();
            stockInProductDetailViewModelBindingSource.DataSource = dsProductDetail;
        }

        #region Overriden Method

        protected override void OnLoadLookupDataSource()
        {
            dsStockItem = StockItemDALObj.GetLookupList();
            dsUnit = UnitDALObj.GetLookupList();

            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            lookupProduct.ValueMember = "ProductID";
            lookupProduct.DisplayMember = "ProductName";
            lookupProduct.DataSource = dsStockItem;

            lookupUnit.ValueMember = "UnitID";
            lookupUnit.DisplayMember = "UnitName";
            lookupUnit.DataSource = dsUnit;

            base.OnAssignLookupDataSource();
        }
        
        protected override void OnAssignFormValues()
        {
            dtpDate.EditValue = DateTime.Now.Date;
            base.OnAssignFormValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            txtRecieptNo.EditValue = DALObject.GenerateStockVNo();

            base.OnInitializeDefaultValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            gvProductDetail.CloseEditor();
            gvProductDetail.UpdateCurrentRow();
            gvProductDetail.UpdateSummary();

            if(dsProductDetail.Count(r=> r.ProductID != 0 && r.Quantity != 0) == 0)
            {
                MessageBox.Show("Please enter product detail", "Stok in", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new StockInViewModel()
            {
                StockInID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                VoucherNo = (long)txtRecieptNo.EditValue,
                VoucherDate = dtpDate.DateTime,
                Narration = memoNarration.Text,
                //ProductDetail = dsProductDetail
                ProductDetail = dsProductDetail.Where(r => r.Quantity != 0).ToList(),
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StockInViewModel EditingRecord = (StockInViewModel)RecordToFill;

            dtpDate.EditValue = EditingRecord.VoucherDate;
            txtRecieptNo.EditValue = EditingRecord.VoucherNo;
            memoNarration.Text = EditingRecord.Narration;

            stockInProductDetailViewModelBindingSource.DataSource = dsProductDetail = EditingRecord.ProductDetail;
            gvProductDetail.RefreshData();

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Other Methods and Events
        private void gvProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            StockInProductDetailViewModel CurrentRow = ((StockInProductDetailViewModel)gvProductDetail.GetRow(e.RowHandle));
            if (e.Column == colProductNo)
            {
                long PCode = 0;
                if (e.Value != null)
                {
                    if (!long.TryParse(e.Value.ToString(), out PCode))
                    {
                        return;
                    }

                    SelectProduct(StockItemDALObj.GetViewModelByPCode(PCode), CurrentRow);
                }
            }
            else if (e.Column == colBarcode)
            {
                if (e.Value != null)
                {
                    SelectProduct(StockItemDALObj.GetViewModelByBarcode(e.Value.ToString()), CurrentRow);
                }
            }
            else if (e.Column == colProductName)
            {
                if (e.Value != null)
                {
                    SelectProduct(StockItemDALObj.GetViewModelByPrimeKey(CurrentRow.ProductID), CurrentRow);
                }
            }
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, StockInProductDetailViewModel RowViewModel)
        {
            if (ProductViewModel == null)
            {
                RowViewModel.ProductID = 0;
                RowViewModel.PCode = 0;
                RowViewModel.Barcode = null;
                RowViewModel.ProductName = null;
                RowViewModel.Quantity = 0;
                RowViewModel.Rate = 0;
                RowViewModel.UnitID = 0;
            }
            else
            {
                RowViewModel.ProductID = ProductViewModel.ProductID;
                RowViewModel.PCode = ProductViewModel.PCode;
                RowViewModel.Barcode = ProductViewModel.Barcode;
                RowViewModel.ProductName = ProductViewModel.ProductName;
                RowViewModel.UnitID = ProductViewModel.UnitID;
                RowViewModel.Rate = ProductViewModel.PurchaseRate;
            }
        }

        private void repositoryItemButtonEditDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gvProductDetail.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            stockInProductDetailViewModelBindingSource.Remove(Row);
        }

        #endregion

        #region Validation
        private void dtpDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpDate, "Select Date");
            }
            else if (!CommonFunctions.CheckDateCurrentFinPer((DateTime)dtpDate.EditValue))
            {
                ErrorProvider.SetError(dtpDate, "Date must be in current financial period.");
            }
            else
            {
                ErrorProvider.SetError(dtpDate, null);
            }
        }

        private void txtRecieptNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtRecieptNo.EditValue == null || (long)txtRecieptNo.EditValue == 0)
            {
                ErrorProvider.SetError(txtRecieptNo, "Please enter Voucher No.");
            }
            else if (DALObject.IsDuplicateRecord((long)txtRecieptNo.EditValue, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtRecieptNo, "Can not accept duplicate Voucher No.");
            }
            else
            {
                ErrorProvider.SetError(txtRecieptNo, null);
            }
        }

        #endregion

    }
}
