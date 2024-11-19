using Alit.Marker.DAL.Inventory;
using Alit.Marker.DAL.Inventory.Masters.StockItem;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory;
using Alit.Marker.Model.Inventory.Masters.StockItem;
using Alit.Marker.Model.Template;
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

namespace Alit.Marker.WinForm.Inventory
{
    public partial class frmOpeningStock : Template.frmCRUDTemplate
    {
        ProductOpeningStockDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new ProductOpeningStockDAL();
                }

                return DALObject;
            }
        }

        StockItemDAL StockItemDALObj;

        StockItemDetailViewModel SelectedProduct_;
        StockItemDetailViewModel SelectedProduct
        {
            get { return SelectedProduct_; }
            set
            {
                SelectedProduct_ = value;

                if (SelectedProduct_ != null)
                {
                    txtBarcode.EditValue = SelectedProduct_.Barcode;
                    txtProductCode.EditValue = SelectedProduct_.PCode;
                    txtProductName.EditValue = SelectedProduct_.ProductName;
                    txtUnitName.EditValue = SelectedProduct_.UnitName;
                }
                else
                {
                    txtBarcode.EditValue = null;
                    txtProductCode.EditValue = null;
                    txtProductName.EditValue = null;
                    txtUnitName.EditValue = null;
                }
            }
        }



        long? ProductID_;
        public long? ProductID
        {
            get
            {
                return ProductID_;
            }
            set
            {
                ProductID_ = value;

                if (StockItemDALObj == null)
                {
                    StockItemDALObj = new StockItemDAL();
                }
                if (ProductID_ != null)
                {
                    SelectedProduct = StockItemDALObj.GetDetailViewModelByPrimeKey(ProductID_.Value);
                }
                else
                {
                    SelectedProduct = null;
                }
            }
        }

        public frmOpeningStock() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }, 0) { }

        public frmOpeningStock(Model.Template.CRUDMTemplateParas paras, long productID) : base(paras)
        {
            InitializeComponent();
            FirstControl = txtOpStockQty;
            DALObject = new ProductOpeningStockDAL();
            StockItemDALObj = new DAL.Inventory.Masters.StockItem.StockItemDAL();
            this.ProductID = productID;
            dtpOpStockDate.EditValue = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;

            lciProductCode.Visibility = (Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);

            lciBarcode.Visibility = (Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        protected override void OnAssignFormValues()
        {
            if (EditingRecord != null)
            {
                dtpOpStockDate.Enabled = false;
            }
            else
            {
                dtpOpStockDate.Enabled = true;
            }
            base.OnAssignFormValues();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new ProductOpeningStockViewModel()
            {
                OpeningStockID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? ((ProductOpeningStockViewModel)EditingRecord).OpeningStockID : 0),
                ProductID = ProductID.Value,
                OpeningStockDate = dtpOpStockDate.DateTime,
                OpeningStockQty = (decimal)txtOpStockQty.EditValue,
                Rate = (decimal)txtRate.EditValue,
                Narration = txtNarration.Text
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            ProductOpeningStockViewModel EditingRecord = (ProductOpeningStockViewModel)RecordToFill;
           
            ProductID = EditingRecord.ProductID;
            dtpOpStockDate.EditValue = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
            txtOpStockQty.EditValue = EditingRecord.OpeningStockQty;
            txtRate.EditValue = EditingRecord.Rate;
            txtNarration.Text = EditingRecord.Narration;
            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        protected override bool OnValidateBeforeSave()
        {
            if (FormCurrentUI == eFormCurrentUI.Edit && (decimal)txtOpStockQty.EditValue == 0)
            {
                if (MessageBox.Show("Are you sure ? Do you want to delete Opening Stock ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DALObject.DeleteRecord(((ProductOpeningStockViewModel)EditingRecord).OpeningStockID);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return false;
                }
                else
                {
                    return false;
                }
            }
            return base.OnValidateBeforeSave();
        }

        private void dtpOpStockDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpOpStockDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpOpStockDate, "Please enter date");
            }
            else
            {
                ErrorProvider.SetError(dtpOpStockDate, null);
            }
        }

        private void txtOpStockQty_Validating(object sender, CancelEventArgs e)
        {
            if (txtOpStockQty.EditValue == null)
            {
                ErrorProvider.SetError(txtOpStockQty, "Please enter quantity.");
            }
            else if ((decimal)txtOpStockQty.EditValue == 0 &&  FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                ErrorProvider.SetError(txtOpStockQty, "Quantity can not be zero.");
            }
            else
            {
                ErrorProvider.SetError(txtOpStockQty, null);
            }
        }

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            if (txtRate.EditValue == null)
            {
                ErrorProvider.SetError(txtRate, "Please enter rate");
            }
            else
            {
                ErrorProvider.SetError(txtRate, null);
            }
        }
    }
}
