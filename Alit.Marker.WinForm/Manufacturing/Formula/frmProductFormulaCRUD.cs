using Alit.Marker.DAL.Manufacturing.Formula;
using Alit.Marker.Model;
using Alit.Marker.Model.Manufacturing.Formula;
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
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Inventory.Masters.StockItem;

namespace Alit.Marker.WinForm.Manufacturing.Formula
{
    public partial class frmProductFormulaCRUD : Template.frmNormalTemplate
    {
        StockItemDAL StockItemDALObj;
        ProductFormulaDAL DALObject;

        List<StockItemLookupListModel> dsFinishProduct;
        List<StockItemLookupListModel> dsRawProduct;
        List<ProductFormulaDetailViewModel> dsFormulaDetail;

        long? EditingFormulaID;
        public frmProductFormulaCRUD()
        {
            InitializeComponent();

            FirstControl = lookupProduct;

            StockItemDALObj = new StockItemDAL();
            DALObject = new ProductFormulaDAL();

            dsFormulaDetail = new List<ProductFormulaDetailViewModel>();
            productFormulaDetailViewModelBindingSource.DataSource = dsFormulaDetail;
        }

        #region Overriden Methods

        protected override void OnLoadLookupDataSource()
        {
            dsFinishProduct = StockItemDALObj.GetLookupList();
            dsRawProduct = dsFinishProduct.ToList();
            //--
            base.OnLoadLookupDataSource();
        }

        protected override void OnAssignLookupDataSource()
        {
            lookupProduct.Properties.ValueMember = "ProductID";
            lookupProduct.Properties.DisplayMember = "ProductName";
            lookupProduct.Properties.DataSource = dsFinishProduct;
            Inventory.Masters.StockItem.ProductLookupFormatter.FormatProductLookupList(lookupProduct);

            repositoryItemLookUpEditProduct.ValueMember = "ProductID";
            repositoryItemLookUpEditProduct.DisplayMember = "ProductName";
            repositoryItemLookUpEditProduct.DataSource = dsRawProduct;
            CommonFunctions.gridViewlookupProductSelection_ColumnFormat(repositoryItemLookUpEditProduct);

            base.OnAssignLookupDataSource();
        }

        protected override bool OnValidateBeforeSave()
        {
            gvRawMaterial.CloseEditor();
            gvRawMaterial.UpdateCurrentRow();
            gvRawMaterial.UpdateSummary();

            if (dsFormulaDetail.Count(r => r.Quantity != 0) == 0)
            {
                MessageBox.Show("Please enter raw material detail", "Formula Detail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return base.OnValidateBeforeSave();
        }

        protected override void OnSaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.SaveRecord(new ProductFormulaViewModel()
                                    {
                                        ProductFormulaID = EditingFormulaID ?? 0,
                                        ProductID = (long)lookupProduct.EditValue,
                                        WEDate = (DateTime?)deWEDate.EditValue,
                                        FinishQuantity = (decimal)txtFinishQuantity.EditValue,
                                        Remark = txtRemark.Text,
                                        ProductDetail = dsFormulaDetail,
                                    });
        }

        #endregion

        private void lookupProduct_Validating(object sender, CancelEventArgs e)
        {
            if (lookupProduct.EditValue == null)
            {
                ErrorProvider.SetError(lookupProduct, "Please select product.");
            }
            else
            {
                ErrorProvider.SetError(lookupProduct, null);
            }
        }

        private void txtFinishQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtFinishQuantity.EditValue == null || ((decimal)txtFinishQuantity.EditValue) == 0)
            {
                ErrorProvider.SetError(txtFinishQuantity, "Please enter finish quantity.");
            }
            else
            {
                ErrorProvider.SetError(txtFinishQuantity, null);
            }
        }

        private void lookupProduct_EditValueChanged(object sender, EventArgs e)
        {
            txtFinishQuantity.EditValue = 0M;
            deWEDate.EditValue = null;
            dsFormulaDetail.Clear();

            if (lookupProduct.EditValue != null)
            {
                var ViewModel = DALObject.GetLatestFormulaByProductID((long)lookupProduct.EditValue);
                if (ViewModel != null)
                {
                    EditingFormulaID = ViewModel.ProductFormulaID;
                    txtFinishQuantity.EditValue = ViewModel.FinishQuantity;
                    deWEDate.EditValue = ViewModel.WEDate;
                    txtRemark.EditValue = ViewModel.Remark;
                    //--
                    dsFormulaDetail = ViewModel.ProductDetail;
                    productFormulaDetailViewModelBindingSource.DataSource = dsFormulaDetail;
                }
            }
            gvRawMaterial.RefreshData();
        }

        private void repositoryItemButtonEditRemoveRow_Click(object sender, EventArgs e)
        {
            if (!gvRawMaterial.IsNewItemRow(gvRawMaterial.FocusedRowHandle))
            {
                productFormulaDetailViewModelBindingSource.RemoveAt(gvRawMaterial.GetDataSourceRowIndex(gvRawMaterial.FocusedRowHandle));
            }
        }
    }
}
