using Alit.Marker.DAL.Product;
using Alit.Marker.Model;
using Alit.Marker.Model.Product;
using Alit.Marker.Model.TransactionsCommon;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.TransactionsCommon
{
    public class ProductDetailGridViewController
    {
        ProductDAL ProductDAL;

        public GridView ProductDetailGridView { get; private set; }

        public BindingSource ProductDetailBindingSource { get; private set; }

        public ProductDetailGridViewController(GridView productDetailGridView)
        {
            ProductDAL = new ProductDAL();

            this.ProductDetailGridView = productDetailGridView;

            if(ProductDetailGridView.DataSource is BindingSource)
            {
                ProductDetailBindingSource = (BindingSource)ProductDetailGridView.DataSource;
                ProductDetailBindingSource.ListChanged += ProductDetailBindingSource_ListChanged;
            }
        }

        #region Product Detail Grid

        void ProductDetailBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                ProductDetailBaseViewModel NewRecord = ((ProductDetailBaseViewModel)ProductDetailBindingSource.List[e.NewIndex]);

                //NewRecord.Quantity = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan;
                //if (DefaultUnitID.HasValue) NewRecord.UnitID = DefaultUnitID.Value;

                NewRecord.GAmtChanged += GAmtChanged;
                NewRecord.NetAmtChanged += NewRecord_NetAmtChanged;

                NewRecord.Tax1AmtChanged += NewRecord_Tax1AmtChanged;
                NewRecord.Tax2AmtChanged += NewRecord_Tax2AmtChanged;
                NewRecord.Tax3AmtChanged += NewRecord_Tax3AmtChanged;

                NewRecord.Tax1IDChanged += NewRecord_Tax1IDChanged;
                NewRecord.Tax2IDChanged += NewRecord_Tax2IDChanged;
                NewRecord.Tax3IDChanged += NewRecord_Tax3IDChanged;
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemMoved)
            {
                ProductDetailGridView.UpdateTotalSummary();
                ReSetTaxRecords();
                UpdateAdditionalItemsUpdatedAmount();
            }
        }

        bool IsProductRecordGAmtChanged;
        void GAmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            IsProductRecordGAmtChanged = true;
        }
        void NewRecord_Tax1IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }
        void NewRecord_Tax2IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }
        void NewRecord_Tax3IDChanged(object sender, Model.ValueChangedEventArgs e)
        {
            //ReSetTaxRecords();
        }

        void NewRecord_Tax1AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((ProductDetailBaseViewModel)sender).Tax1ID.HasValue)
            {
                UpdateTaxAmt(((ProductDetailBaseViewModel)sender).Tax1ID.Value);
            }
        }
        void NewRecord_Tax2AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((ProductDetailBaseViewModel)sender).Tax2ID.HasValue)
            {
                UpdateTaxAmt(((ProductDetailBaseViewModel)sender).Tax2ID.Value);
            }
        }
        void NewRecord_Tax3AmtChanged(object sender, Model.ValueChangedEventArgs e)
        {
            if (((ProductDetailBaseViewModel)sender).Tax3ID.HasValue)
            {
                UpdateTaxAmt(((ProductDetailBaseViewModel)sender).Tax3ID.Value);
            }
        }

        void NewRecord_NetAmtChanged(object sender, ValueChangedEventArgs e)
        {
            //ProductDetailGridView.UpdateSummary();
            //ProductDetailGridView.UpdateGroupSummary();
            //ProductDetailGridView.UpdateTotalSummary();
            ProductDetailGridView.PostEditor();
            ProductDetailGridView.UpdateCurrentRow();
            UpdateAdditionalsAmount(0);
        }

        private void ProductDetailGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ProductDetailBaseViewModel CurrentRow = ((ProductDetailBaseViewModel)ProductDetailGridView.GetRow(e.RowHandle));
            if (e.Column.FieldName == "PCode")
            {
                long PCode = 0;
                if (e.Value != null)
                {
                    if (!long.TryParse(e.Value.ToString(), out PCode))
                    {
                        return;
                    }

                    SelectProduct(ProductDAL.GetViewModelByPCode(PCode), CurrentRow);
                }
            }
            else if (e.Column.FieldName == "Barcode")
            {
                if (e.Value != null)
                {
                    SelectProduct(ProductDAL.GetViewModelByBarcode(e.Value.ToString()), CurrentRow);
                }
            }
            else if (e.Column.FieldName == "ProductName")
            {
                if (e.Value != null)
                {
                    string ProductName = e.Value.ToString();
                    ProductLookupListModel Product = ProductLookUpListDataSource.FirstOrDefault(r => r.ProductName == ProductName);
                    if (Product != null && Product.ProductID != -1)
                    {
                        SelectProduct(ProductDAL.GetViewModelByPrimeKey(Product.ProductID), CurrentRow);
                    }
                }
            }
            else if (e.Column.FieldName == "Tax1ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax1ID = 0;
                    CurrentRow.Tax1Amt = 0;
                    CurrentRow.Tax1Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemMasterLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax1Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax1Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
            else if (e.Column.FieldName == "Tax2ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax2ID = 0;
                    CurrentRow.Tax2Amt = 0;
                    CurrentRow.Tax2Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemMasterLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax2Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax2Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
            else if (e.Column.FieldName == "Tax3ID")
            {
                if (e.Value == null)
                {
                    CurrentRow.Tax3ID = 0;
                    CurrentRow.Tax3Amt = 0;
                    CurrentRow.Tax3Perc = 0;
                }
                else
                {
                    long TaxID = (long)e.Value;
                    AdditionalItemMasterLookupModel TaxItem = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == TaxID);
                    if (TaxItem != null)
                    {
                        //CurrentRow.TaxInclusive = TaxItem.IsInclusive;
                        CurrentRow.Tax3Perc = TaxItem.Perc;
                    }
                    else
                    {
                        CurrentRow.Tax3Perc = 0;
                        //CurrentRow.TaxInclusive = false;
                    }
                }
                ReSetTaxRecords();
            }
        }

        public void SelectProduct(ProductViewModel ProductViewModel, int RowHandel)
        {
            SelectProduct(ProductViewModel, (ProductDetailBaseViewModel)ProductDetailGridView.GetRow(RowHandel));
        }

        public void SelectProduct(ProductViewModel ProductViewModel, ProductDetailBaseViewModel RowViewModel)
        {
            if (ProductViewModel == null)
            {
                RowViewModel.ProductID = 0;
                RowViewModel.PCode = 0;
                RowViewModel.Barcode = "";
                RowViewModel.ProductName = "";
                RowViewModel.ProductDescr = "";
                RowViewModel.Rate = 0;
                RowViewModel.UnitID = 0;
            }
            else
            {
                RowViewModel.ProductID = ProductViewModel.ProductID;
                RowViewModel.PCode = ProductViewModel.PCode;
                RowViewModel.Barcode = ProductViewModel.Barcode;
                RowViewModel.ProductName = ProductViewModel.ProductName;
                RowViewModel.ProductDescr = ProductViewModel.ProdDescr;

                RowViewModel.UnitID = ProductViewModel.UnitID;

                RowViewModel.Rate = 0;
                RowViewModel.DiscPerc = 0;

                if (lookUpPriceList.EditValue != null)
                {
                    long PriceListID = (long)lookUpPriceList.EditValue;
                    ProductRateViewModel RateRecord = ProductViewModel.SaleRate.FirstOrDefault(r => r.PriceListID == PriceListID);
                    if (RateRecord != null)
                    {
                        RowViewModel.Rate = RateRecord.Rate;
                        RowViewModel.DiscPerc = RateRecord.DiscountPerc;
                    }
                }

                CustomerLookUpListModel SelectedCustomer = null;
                if (lookupCustomer.EditValue != null && (long)lookupCustomer.EditValue != -1)
                {
                    SelectedCustomer = (CustomerLookUpListModel)lookupCustomer.GetSelectedDataRow();
                }

                long CompanyStateID = Model.CommonProperties.LoginInfo.LoggedInCompany.City.StateID ?? 0;

                long CustomerStateID = 0;
                if (SelectedCustomer != null && SelectedCustomer.CustomerID != -1)
                {
                    CustomerStateID = SelectedCustomer.StateID;
                }
                else if (SelectedCustomer == null || SelectedCustomer.CustomerID == -1)
                {
                    object SelectedCity = lookUpCity.GetSelectedDataRow();
                    if (SelectedCity != null)
                    {
                        CustomerStateID = (long)((CityLookupListModel)SelectedCity).StateID;
                    }
                }

                bool IsInterstateSale = (CompanyStateID != CustomerStateID);

                if ((ProductTaxCat1_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat1_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax1ID = ProductViewModel.Tax1ID;
                }

                if ((ProductTaxCat2_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat2_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax2ID = ProductViewModel.Tax2ID;
                }

                if ((ProductTaxCat3_IsInterstateSale && IsInterstateSale) || (!ProductTaxCat3_IsInterstateSale && !IsInterstateSale))
                {
                    RowViewModel.Tax3ID = ProductViewModel.Tax3ID;
                }

                if (RowViewModel.Tax1ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax1ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax1Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax1Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax1Perc = 0;
                }


                if (RowViewModel.Tax2ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax2ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax2Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax2Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax2Perc = 0;
                }


                if (RowViewModel.Tax3ID != null)
                {
                    var tax = TaxItemsDS.FirstOrDefault(r => r.AdditionalItemID == (RowViewModel.Tax3ID ?? 0));
                    if (tax != null)
                    {
                        RowViewModel.Tax3Perc = tax.Perc;
                    }
                    else
                    {
                        RowViewModel.Tax3Perc = 0;
                    }
                }
                else
                {
                    RowViewModel.Tax3Perc = 0;
                }

                if (RowViewModel.Tax1ID != null || RowViewModel.Tax2ID != null || RowViewModel.Tax3ID != null)
                {
                    ReSetTaxRecords();
                    if (RowViewModel.Tax1ID.HasValue) UpdateTaxAmt(RowViewModel.Tax1ID ?? 0);
                    if (RowViewModel.Tax2ID.HasValue) UpdateTaxAmt(RowViewModel.Tax2ID ?? 0);
                    if (RowViewModel.Tax3ID.HasValue) UpdateTaxAmt(RowViewModel.Tax3ID ?? 0);
                }
                //RowViewModel.TaxID = ProductSaveModel.TaxPerc;
            }
        }

        private void ProductDetailGridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            object Row = ProductDetailGridView.GetRow(e.RowHandle);
            if (Row != null)
            {
                ProductDetailBaseViewModel NewRecord = ((ProductDetailBaseViewModel)Row);
                //((SaleInvoiceProductDetailViewModel)Row).Rate = ColorRate;
                NewRecord.Quantity = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan;
                if (DefaultUnitID.HasValue) NewRecord.UnitID = DefaultUnitID.Value;
            }
        }

        private void ProductDetailGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row == null) return;
            ProductDetailBaseViewModel ProductRow = (ProductDetailBaseViewModel)e.Row;
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts && ProductRow.ProductID == 0 && String.IsNullOrWhiteSpace(ProductRow.ProductName))
            {
                e.Valid = false;
                e.ErrorText = "Product no selected or Product name not entered";
            }
            else
            {
                e.Valid = true;
                e.ErrorText = "";
            }
        }

        void ProductDetailGridViewLookUpProduct_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            NewProduct.ProductName = (e.DisplayValue != null ? e.DisplayValue.ToString() : "");
            ((LookUpEdit)sender).EditValue = -1;
            e.Handled = true;
        }

        private void ProductDetailGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ProductDetailBaseViewModel AttachedObj = (ProductDetailBaseViewModel)ProductDetailGridView.GetRow(e.FocusedRowHandle);
            if (AttachedObj != null && AttachedObj.ProductID == -1)
            {
                NewProduct.ProductName = AttachedObj.ProductName;
            }
            //object ProductID = ProductDetailGridView.GetRowCellValue(e.FocusedRowHandle, "ProductID");
            //long ProductIDLong = 0;
            //if (ProductID == null || (ProductID != null && long.TryParse(ProductID.ToString(), out ProductIDLong) && ProductIDLong == -1))
            //{
            //    object ProductName = ProductDetailGridView.GetRowCellValue(e.FocusedRowHandle, "ProductName");
            //    if (ProductName != null)
            //    {
            //        NewProduct.ProductName = ProductName.ToString();
            //    }
            //}
        }

        private void ProductDetailGridView_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            UpdateGrossAmt();
        }

        private void gridControlProductDetail_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(gridControlProductDetail, "");
            if (CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            {
                if (ProductDetailBaseViewModelBindingSource.Cast<ProductDetailBaseViewModel>().Count(r => r.ProductID == 0 && String.IsNullOrWhiteSpace(r.ProductName) && r.Quantity != 0) > 0)
                {
                    ErrorProvider.SetError(gridControlProductDetail, "Product is required. Please select a Product from list or enter Product name.");
                }
            }
        }

        private void ProductDetailGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

            if (hitInfo.InRow)
            {

                view.FocusedRowHandle = hitInfo.RowHandle;
                Point GridLocation = view.GridControl.PointToScreen(e.Point);

                popupMenuGridShortCut.ShowPopup(new Point()
                {
                    X = GridLocation.X, // + e.Point.X
                    Y = GridLocation.Y // + e.Point.Y
                });
            }
        }

        #endregion

    }
}
