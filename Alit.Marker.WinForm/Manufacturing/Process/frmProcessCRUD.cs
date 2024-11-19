using Alit.Marker.DAL.Manufacturing.Process;
using Alit.Marker.DAL.Manufacturing.Formula;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Manufacturing.Process;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Inventory.Masters.StockItem;

namespace Alit.Marker.WinForm.Manufacturing.Process
{
    public partial class frmProcessCRUD : Template.frmCRUDTemplate
    {
        ProcessDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new ProcessDAL();
                }

                return DALObject;
            }
        }

        ProductFormulaDAL FormulaDALObj;
        StockItemDAL StockItemDALObj;

        List<StockItemLookupListModel> dsFinishProduct;
        List<StockItemLookupListModel> dsRawProduct;
        List<ProcessDetailViewModel> dsProcessDetail;

        decimal FormulaFinishQty { get; set; }

        public decimal FinishProductRate
        {
            get
            {
                return (decimal?)txtFinishProductRate.EditValue ?? 0;
            }
            set
            {
                txtFinishProductRate.EditValue = value;
            }
        }

        public frmProcessCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmProcessCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            FirstControl = lookupProduct;

            StockItemDALObj = new StockItemDAL();
            DALObject = new ProcessDAL();
            FormulaDALObj = new ProductFormulaDAL();

            dsProcessDetail = new List<ProcessDetailViewModel>();
            processDetailViewModelBindingSource.DataSource = dsProcessDetail;
        }

        protected override void OnLoadLookupDataSource()
        {
            LoadProductLookupDateSource();

            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            AssignProductLookupDataSource();

            base.OnAssignLookupDataSource();
        }

        void LoadProductLookupDateSource()
        {
            dsFinishProduct = StockItemDALObj.GetLookupList();
            dsRawProduct = StockItemDALObj.GetLookupList();
        }

        void AssignProductLookupDataSource()
        {
            lookupProduct.Properties.ValueMember = "ProductID";
            lookupProduct.Properties.DisplayMember = "ProductName";
            lookupProduct.Properties.DataSource = dsFinishProduct;
            Inventory.Masters.StockItem.ProductLookupFormatter.FormatProductLookupList(lookupProduct);

            repositoryItemLookUpEditRawProduct.ValueMember = "ProductID";
            repositoryItemLookUpEditRawProduct.DisplayMember = "ProductName";
            repositoryItemLookUpEditRawProduct.DataSource = dsRawProduct;
            CommonFunctions.gridViewlookupProductSelection_ColumnFormat(repositoryItemLookUpEditRawProduct);
        }

        protected override void OnAssignFormValues()
        {
            deProcessDate.EditValue = DateTime.Now.Date;
            base.OnAssignFormValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            txtProcessNo.EditValue = DALObject.GenerateStockVNo();

            base.OnInitializeDefaultValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            gvDetail.CloseEditor();

            if (dsProcessDetail.Count(r => r.Quantity != 0) == 0)
            {
                MessageBox.Show("Please enter raw material detail", "Formula Detail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new ProcessViewModel()
            {
                ProcessID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                ProcessNo = (long)txtProcessNo.EditValue,
                ProcessDate = (DateTime)deProcessDate.EditValue,
                Narration = txtNarration.Text,
                ProductID = (long)lookupProduct.EditValue,
                Rate = (decimal?)txtFinishProductRate.EditValue ?? 0,
                FinishQuantity = (decimal?)txtFinishQuantity.EditValue ?? 0,
                ProductDetail = dsProcessDetail,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            ProcessViewModel EditingRecord = (ProcessViewModel)RecordToFill;

            deProcessDate.EditValue = EditingRecord.ProcessDate;
            txtProcessNo.EditValue = EditingRecord.ProcessNo;
            lookupProduct.EditValue = EditingRecord.ProductID;
            txtFinishProductRate.EditValue = EditingRecord.Rate;
            txtFinishQuantity.EditValue = EditingRecord.FinishQuantity;
            txtNarration.Text = EditingRecord.Narration;

            dsProcessDetail = EditingRecord.ProductDetail;
            processDetailViewModelBindingSource.DataSource = dsProcessDetail;
            gvDetail.RefreshData();

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        

        private void txtFinishQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (!CommonFunctions.CheckParseDecimal(txtFinishQuantity.Text))
            {
                ErrorProvider.SetError(txtFinishQuantity, "Invalid quantity.");
            }
            else
            {
                ErrorProvider.SetError(txtFinishQuantity, "");
            }
        }

        private void deProcessDate_Validating(object sender, CancelEventArgs e)
        {
            if (deProcessDate.EditValue == null)
            {
                ErrorProvider.SetError(deProcessDate, "Select Date");
            }
            else if (!CommonFunctions.CheckDateCurrentFinPer((DateTime)deProcessDate.EditValue))
            {
                ErrorProvider.SetError(deProcessDate, "Date must be in current financial period.");
            }
            else
            {
                ErrorProvider.SetError(deProcessDate, "");
            }
        }

        private void txtProcessNo_Validating(object sender, CancelEventArgs e)
        {
            if (!CommonFunctions.CheckParseLong(txtProcessNo.Text))
            {
                ErrorProvider.SetError(txtProcessNo, "Valid voucher number required.");
            }
            else
            {
                ErrorProvider.SetError(txtProcessNo, "");
            }
        }

        private void lookupProduct_Validating(object sender, CancelEventArgs e)
        {
            if (lookupProduct.EditValue == null)
            {
                ErrorProvider.SetError(lookupProduct, "Product is required. Please select a Product.");
            }
            else
            {
                ErrorProvider.SetError(lookupProduct, "");
            }
        }

        private void repositoryItemButtonEditRemoveRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!gvDetail.IsNewItemRow(gvDetail.FocusedRowHandle))
            {
                processDetailViewModelBindingSource.RemoveAt(gvDetail.GetDataSourceRowIndex(gvDetail.FocusedRowHandle));
            }
            //UpdateFinishProductRate();
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colProductID)
            {
                ProcessDetailViewModel Row = (ProcessDetailViewModel)gvDetail.GetFocusedRow();
                if (Row != null)
                {
                    decimal PurchaseRate = StockItemDALObj.GetPurchaseRate(Row.ProductID);
                    Row.Rate = PurchaseRate;
                    gvDetail.RefreshRow(e.RowHandle);
                }
            }
            else if (e.Column.FieldName == "Quantity" || e.Column.FieldName == "Rate")
            {
                gvDetail.UpdateTotalSummary();
                UpdateFinishProductRate();
            }
        }

        void UpdateFinishProductRate()
        {
            decimal FinishQty = ((decimal?)txtFinishQuantity.EditValue ?? 0);
            if (FinishQty == 0)
            {
                FinishQty = 1;
            }
            gvDetail.UpdateSummary();
            FinishProductRate = Math.Round(((decimal?)colAmt.SummaryItem.SummaryValue ?? 0) / FinishQty, 2);
        }

        private void lookupProduct_EditValueChanged(object sender, EventArgs e)
        {
            dsProcessDetail.Clear();
            txtFinishQuantity.EditValue = 0M;
            //--
            if (lookupProduct.EditValue != null)
            {
                var Formula = FormulaDALObj.GetLatestFormulaByProductID((long)lookupProduct.EditValue);
                if (Formula != null)
                {
                    txtFinishQuantity.EditValue = Formula.FinishQuantity;
                    FormulaFinishQty = Formula.FinishQuantity;

                    foreach (var fd in Formula.ProductDetail)
                    {
                        ProcessDetailViewModel ProcessDetail = new ProcessDetailViewModel()
                        {
                            ProductID = fd.ProductID,
                            FormulaQuantity = fd.Quantity,
                            Quantity = fd.Quantity,
                            Rate = 0,
                        };
                        //--
                        ProcessDetail.Rate = StockItemDALObj.GetPurchaseRate(fd.ProductID);
                        //--
                        dsProcessDetail.Add(ProcessDetail);
                    }
                }
            }
            gvDetail.RefreshData();
            UpdateFinishProductRate();
        }

        private void txtFinishQuantity_EditValueChanged(object sender, EventArgs e)
        {
            if (FormulaFinishQty != 0)
            {
                decimal FinishQty = (decimal?)txtFinishQuantity.EditValue ?? 0;
                foreach (var r in dsProcessDetail.Where(r => r.FormulaQuantity != 0))
                {
                    r.Quantity = (r.FormulaQuantity / FormulaFinishQty) * FinishQty;
                }
                gvDetail.RefreshData();
            }
            UpdateFinishProductRate();
        }

        private void gvDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            UpdateFinishProductRate();
        }

        private void processDetailViewModelBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateFinishProductRate();
        }
    }
}
