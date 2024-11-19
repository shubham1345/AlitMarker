using Alit.Marker.DAL;
using Alit.Marker.Model;
using DevExpress.XtraEditors;
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
using Alit.Marker.Model.TransactionsCommon;
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.Model.Inventory.Masters.Unit;
using Alit.Marker.DAL.Inventory.Masters.Unit;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Inventory.Masters.StockItem;
using Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.DAL.Inventory.Masters.StockItemTaxCategory;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;

namespace Alit.Marker.WinForm.Inventory.Masters.StockItem
{
    public partial class frmStockItemCRUD : Template.frmCRUDTemplate
    {
        StockItemDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StockItemDAL();
                }

                return DALObject;
            }
        }

        AdditionalItemDAL AdditionalItemMasterDAL;
        PriceListDAL PriceListDAL;
        StockItemTaxCategoryDAL StockItemTaxCategoryDALObj;

        List<PriceListLookupListModel> dsPriceList;
        List<StockItemRateViewModel> dsSaleRate;
        List<AdditionalItemLookupModel> dsTax;

        public frmStockItemCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStockItemCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();

            DALObject = new StockItemDAL();
            AdditionalItemMasterDAL = new AdditionalItemDAL();
            PriceListDAL = new PriceListDAL();
            dsSaleRate = new List<StockItemRateViewModel>();

            Control firstControl = null;
            if (CommonProperties.LoginInfo.SoftwareSettings.ProductCode)
            {
                if (firstControl == null)
                    firstControl = txtPCode;
            }
            else
            {
                lciPCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                esiProductCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode)
            {
                if (firstControl == null)
                    firstControl = txtBarcode;
            }
            else
            {
                lciBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                esiBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if (firstControl == null)
            {
                firstControl = txtProductName;
            }

            FirstControl = firstControl;

            if (CommonProperties.LoginInfo.SoftwareSettings.HSNCode)
            {
                lciHSNCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciHSNCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //--
            StockItemTaxCategoryDALObj = new StockItemTaxCategoryDAL();
            StockItemTaxCategoryViewModel TaxCat1 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(1);
            if (TaxCat1 != null && TaxCat1.Applicable)
            {
                lciTax1.Text = TaxCat1.ProductTaxCategoryName;
            }
            else
            {
                lciTax1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            StockItemTaxCategoryViewModel TaxCat2 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(2);
            if (TaxCat2 != null && TaxCat2.Applicable)
            {
                lciTax2.Text = TaxCat2.ProductTaxCategoryName;
            }
            else
            {
                lciTax2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            StockItemTaxCategoryViewModel TaxCat3 = StockItemTaxCategoryDALObj.GetViewModelByTaxIndex(3);
            if (TaxCat3 != null && TaxCat3.Applicable)
            {
                lciTax3.Text = TaxCat3.ProductTaxCategoryName;
            }
            else
            {
                lciTax3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        #region Overriden Method
        protected override void OnLoadLookupDataSource()
        {
            dsPriceList = PriceListDAL.GetLookupList();

            dsTax = AdditionalItemMasterDAL.GetLookupListFinal(eAdditionalItemType.Tax);            

            dsTax.Insert(0, new AdditionalItemLookupModel() { AdditionalItemID = null, AddnitionalItemName = "None", Perc = 0 });

            base.OnLoadLookupDataSource();
        }       

        protected override void OnAssignLookupDataSource()
        {
            lookUpTax1.Properties.ValueMember = "AdditionalItemID";
            lookUpTax1.Properties.DisplayMember = "AddnitionalItemName";
            lookUpTax1.Properties.DataSource = dsTax.Where(r => r.ProductTaxCategoryID == 1 || r.ProductTaxCategoryID == null);

            lookUpTax2.Properties.ValueMember = "AdditionalItemID";
            lookUpTax2.Properties.DisplayMember = "AddnitionalItemName";
            lookUpTax2.Properties.DataSource = dsTax.Where(r => r.ProductTaxCategoryID == 2 || r.ProductTaxCategoryID == null);

            lookUpTax3.Properties.ValueMember = "AdditionalItemID";
            lookUpTax3.Properties.DisplayMember = "AddnitionalItemName";
            lookUpTax3.Properties.DataSource = dsTax.Where(r => r.ProductTaxCategoryID == 3 || r.ProductTaxCategoryID == null);


            base.OnAssignLookupDataSource();
        }

        protected override void OnAssignFormValues()
        {
            dsSaleRate = dsPriceList.Select<PriceListLookupListModel, StockItemRateViewModel>(r => new StockItemRateViewModel()
            {
                PriceListID = r.PriceListID,
                PriceListName = r.PriceListName,
                Rate = 0,
                DiscountPerc = 0
            }).ToList();
            gcRate.DataSource = dsSaleRate;

            if (EditingRecord != null)
            {
                grpbOpeningStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                grpbOpeningStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            base.OnAssignFormValues();
        }

        protected override void OnInitializeDefaultValues()
        {
            dsSaleRate.ForEach(r => { r.Rate = 0; r.DiscountPerc = 0; });
            gcRate.DataSource = null;
            gcRate.DataSource = dsSaleRate;

            long PCode = DALObject.GeneratePCode();
            txtPCode.Text = PCode.ToString();
            txtBarcode.Text = PCode.ToString("000000000#");

            lookUpTax1.EditValue = null;
            lookUpTax2.EditValue = null;
            lookUpTax3.EditValue = null;

            base.OnInitializeDefaultValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            gvRate.PostEditor();
            gvRate.UpdateCurrentRow();
            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            long PCode = 0;
            long.TryParse(txtPCode.Text, out PCode);

            return new StockItemViewModel()
            {
                ProductID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PCode = PCode,
                Barcode = txtBarcode.Text,
                ProductName = txtProductName.Text,
                ProdDescr = txtProdDescr.Text,
                HSNCode = txtHSNCode.Text,
                UnitID = (long)lookUpUnit.EditValue,
                OpeningStock = new Model.Inventory.ProductOpeningStockViewModel
                {
                    OpeningStockQty = (decimal)txtOpeningStock.EditValue,
                    Rate = (decimal)txtRate.EditValue,
                },

                Tax1ID = (lciTax1.Visible ? (long?)lookUpTax1.EditValue : null),
                Tax2ID = (lciTax2.Visible ? (long?)lookUpTax2.EditValue : null),
                Tax3ID = (lciTax3.Visible ? (long?)lookUpTax3.EditValue : null),

                PurchaseRate = CommonFunctions.ParseDecimal(txtPurchaseRate.Text),
                SaleRate = dsSaleRate,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StockItemViewModel EditingRecord = ((StockItemViewModel)RecordToFill);

            txtPCode.Text = EditingRecord.PCode.ToString();
            txtBarcode.Text = EditingRecord.Barcode;
            txtHSNCode.Text = EditingRecord.HSNCode;
            txtProductName.Text = EditingRecord.ProductName;
            txtProdDescr.Text = EditingRecord.ProdDescr;
            lookUpUnit.EditValue = EditingRecord.UnitID;
            txtPurchaseRate.Text = EditingRecord.PurchaseRate.ToString();

            if (lciTax1.Visible)
            {
                lookUpTax1.EditValue = EditingRecord.Tax1ID;
            }
            else
            {
                lookUpTax1.EditValue = null;
            }

            if (lciTax1.Visible)
            {
                lookUpTax2.EditValue = EditingRecord.Tax2ID;
            }
            else
            {
                lookUpTax2.EditValue = null;
            }

            if (lciTax1.Visible)
            {
                lookUpTax3.EditValue = EditingRecord.Tax3ID;
            }
            else
            {
                lookUpTax3.EditValue = null;
            }

            foreach (StockItemRateViewModel RateRecord in EditingRecord.SaleRate)
            {
                StockItemRateViewModel RateItem = dsSaleRate.FirstOrDefault(r => r.PriceListID == RateRecord.PriceListID);
                if (RateItem != null)
                {
                    RateItem.Rate = RateRecord.Rate;
                    RateItem.DiscountPerc = RateRecord.DiscountPerc;
                }
            }
            gcRate.DataSource = null;
            gcRate.DataSource = dsSaleRate;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validating
        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtProductName.Text))
            {
                ErrorProvider.SetError(txtProductName, "Please enter Stock Item Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtProductName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtProductName, "Can not accept duplicate Stock Item Name.");
            }
            else
            {
                ErrorProvider.SetError(txtProductName, null);
            }
        }

        private void lookUpUnit_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpUnit.EditValue == null)
            {
                ErrorProvider.SetError(lookUpUnit, "Please select a Unit");
            }
            else
            {
                ErrorProvider.SetError(lookUpUnit, null);
            }
        }

        private void gridcRate_Leave(object sender, EventArgs e)
        {
            if (gvRate.RowCount > 0)
            {
                gvRate.FocusedColumn = colRate;
            }
        }

        private void txtPCode_Validating(object sender, CancelEventArgs e)
        {
            long PCode = 0;
            if (String.IsNullOrWhiteSpace(txtPCode.Text))
            {
                ErrorProvider.SetError(txtPCode, "Please enter Stock Item Code.");
            }
            else if (!long.TryParse(txtPCode.Text, out PCode))
            {
                ErrorProvider.SetError(txtPCode, "Please enter valid numeric value in Stock Item Code.");
            }
            else if (DALObject.IsDuplicatePCode(PCode, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPCode, "Can not accept duplicate Stock Item Code.");
            }
            else
            {
                ErrorProvider.SetError(txtPCode, null);
            }
        }

        private void txtHSNCode_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(txtHSNCode, null);
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.HSNCode)
            {
                if (String.IsNullOrWhiteSpace(txtHSNCode.Text))
                {
                    ErrorProvider.SetError(txtHSNCode, "Please enter HSN Code.");
                }
            }
        }
        #endregion
    }

    public static class ProductLookupFormatter
    {
        /// <summary>
        /// Format columns for Lookup Control which has datasource of ProductLookupListModel
        /// </summary>
        /// <param name="lookupControl"></param>
        public static void FormatProductLookupList(LookUpEdit lookupControl)
        {
            lookupControl.Properties.NullText = "[Select Product]";
            lookupControl.Properties.PopupWidth = 1000;

            if (lookupControl.Properties.DataSource == null || !(lookupControl.Properties.DataSource is StockItemLookupListModel))
            {
                if (lookupControl.Properties.Columns.Count == 0)
                {
                    lookupControl.Properties.PopulateColumns();
                }

                lookupControl.Properties.Columns["PCode"].Width = 100;
                lookupControl.Properties.Columns["PCode"].Visible = CommonProperties.LoginInfo.SoftwareSettings.ProductCode;

                lookupControl.Properties.Columns["Barcode"].Width = 100;
                lookupControl.Properties.Columns["Barcode"].Visible = CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode;

                lookupControl.Properties.Columns["CurrentStock"].Width = 100;
                lookupControl.Properties.Columns["CurrentStock"].FormatType = DevExpress.Utils.FormatType.Numeric;
                lookupControl.Properties.Columns["CurrentStock"].FormatString = "n2";

                lookupControl.Properties.Columns["UnitName"].Width = 100;

                lookupControl.Properties.Columns["ProductName"].Width =
                    lookupControl.Properties.PopupWidth - Math.Max(lookupControl.Properties.Columns.Sum(r => r.Visible ? r.Width : 0), 100);
            }
        }
    }
}
