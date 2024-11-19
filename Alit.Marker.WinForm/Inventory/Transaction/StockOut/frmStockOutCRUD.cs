using Alit.Marker.DAL.Inventory;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Transaction.StockOut;
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
using Alit.Marker.DAL.Inventory.Transaction.StockOut;
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.Model.Inventory.Masters.Unit;
using Alit.Marker.DAL.Inventory.Masters.Unit;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Inventory.Masters.StockItem;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockOut
{
    public partial class frmStockOutCRUD : Template.frmCRUDTemplate
    {
        StockOutDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StockOutDAL();
                }

                return DALObject;
            }
        }

        StockItemDAL StockItemDALObj;
        List<StockItemLookupListModel> dsProduct;

        UnitDAL UnitDALObj;
        List<UnitLookupListModel> dsUnit;

        PriceListDAL PriceListDALObj;
        List<PriceListLookupListModel> dsPriceList;

        List<StockOutProductDetailViewModel> dsProductDetail;

        public frmStockOutCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStockOutCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObject = new StockOutDAL();
            StockItemDALObj = new StockItemDAL();
            UnitDALObj = new UnitDAL();
            PriceListDALObj = new PriceListDAL();

            colProductNo.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductCode;
            colBarcode.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByBarcode;
            colProductName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductName;

            colRate.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnRate;
            colRate.OptionsColumn.AllowFocus = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;
            colRate.OptionsColumn.ReadOnly = !Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;

            colUnitName.Visible = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddUnitColumn;
            colUnitName.OptionsColumn.TabStop = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnUnit;

            dsProductDetail = new List<StockOutProductDetailViewModel>();
            StockOutProductDetailViewModelBindingSource.DataSource = dsProductDetail;
        }

        #region Overriden Method

        protected override void OnLoadLookupDataSource()
        {
            dsProduct = StockItemDALObj.GetLookupList();
            dsUnit = UnitDALObj.GetLookupList();
            dsPriceList = PriceListDALObj.GetLookupList();

            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            lookupProduct.ValueMember = "ProductID";
            lookupProduct.DisplayMember = "ProductName";
            lookupProduct.DataSource = dsProduct;

            lookupUnit.ValueMember = "UnitID";
            lookupUnit.DisplayMember = "UnitName";
            lookupUnit.DataSource = dsUnit;

            luePriceList.Properties.DisplayMember = "PriceListShortName";
            luePriceList.Properties.ValueMember = "PriceListID";
            luePriceList.Properties.DataSource = dsPriceList;
            
            if (dsPriceList.Count > 1)
            {
                lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            luePriceList.EditValue = dsPriceList.FirstOrDefault()?.PriceListID;

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

            if (dsProductDetail.Count(r => r.ProductID != 0 && r.Quantity != 0) == 0)
            {
                MessageBox.Show("Please enter product detail", "Stok in", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new StockOutViewModel()
            {
                StockOutID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                VoucherNo = (long)txtRecieptNo.EditValue,
                VoucherDate = dtpDate.DateTime,
                Narration = memoNarration.Text,
                //ProductDetail = dsProductDetail,
                ProductDetail = dsProductDetail.Where(r => r.Quantity != 0).ToList(),
                PriceListID = (long?)luePriceList.EditValue,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StockOutViewModel EditingRecord = (StockOutViewModel)RecordToFill;

            dtpDate.EditValue = EditingRecord.VoucherDate;
            txtRecieptNo.EditValue = EditingRecord.VoucherNo;
            luePriceList.EditValue = EditingRecord.PriceListID;
            memoNarration.Text = EditingRecord.Narration;

            StockOutProductDetailViewModelBindingSource.DataSource = dsProductDetail = EditingRecord.ProductDetail;
            gvProductDetail.RefreshData();

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
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
            else if (DALObject.IsDuplicateRecord((long)txtRecieptNo.EditValue
                , (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtRecieptNo, "Can not accept duplicate Voucher No.");
            }
            else
            {
                ErrorProvider.SetError(txtRecieptNo, null);
            }
        }

        #endregion

        #region Other Methods and Events

        private void gvProductDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            StockOutProductDetailViewModel CurrentRow = ((StockOutProductDetailViewModel)gvProductDetail.GetRow(e.RowHandle));
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

        public void SelectProduct(StockItemViewModel ProductViewModel, int RowHandel)
        {
            SelectProduct(ProductViewModel, (StockOutProductDetailViewModel)gvProductDetail.GetRow(RowHandel));
        }

        public void SelectProduct(StockItemViewModel ProductViewModel, StockOutProductDetailViewModel RowViewModel)
        {
            if (ProductViewModel == null)
            {
                RowViewModel.ProductID = 0;
                RowViewModel.PCode = 0;
                RowViewModel.Barcode = "";
                RowViewModel.ProductName = "";
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
                RowViewModel.Rate = StockItemDALObj.GetSaleRate(ProductViewModel.ProductID, (long?)luePriceList.EditValue ?? 0);
            }
        }

        #endregion

        private void repositoryItemButtonEditDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Row = gvProductDetail.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            StockOutProductDetailViewModelBindingSource.Remove(Row);
        }
    }
}
