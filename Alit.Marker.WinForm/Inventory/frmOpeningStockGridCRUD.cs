using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.DAL.Template;
using Alit.Marker.DAL.Inventory;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.Inventory;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Alit.Marker.WinForm.Inventory
{
    public partial class frmOpeningStockGridCRUD : Template.frmGridCRUDTemplate
    {
        #region Constructor
        public frmOpeningStockGridCRUD()
        {
            InitializeComponent();

            CrudDALObj = new ProductOpeningStockDAL();

            CrudGridControl = gridControl1;
            CrudGridView = gridView1;

            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        #endregion

        #region Overridden methods
      
        protected override IGridCRUDDAL GetGridCRUDDALObj()
        {
            return CrudDALObj;
        }

        protected override void InitLayout()
        {
            AllowAddNewEnable = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            base.InitLayout();
        }

        protected override bool ValidateBeforeSave(IGridCRUDViewModel ViewModel)
        {
            var Row = (ProductOpeningStockViewModel)ViewModel;
            if (Row == null || (Row.OpeningStockID == 0 && Row.OpeningStockQty == 0))
            {
                return false;
            }
            return base.ValidateBeforeSave(ViewModel);
        }

        protected override void AssignFormValues()
        {
            repositoryItemOpeningStck.Buttons[0].Visible = false;
            base.AssignFormValues();
        }

        protected override void SaveRecord(SavingParemeter Paras, IGridCRUDViewModel ViewModel)
        {
            var Row = (ProductOpeningStockViewModel)ViewModel;
            if (Row == null)
            {
                return;
            }
            if (Row.OpeningStockID != 0 && Row.OpeningStockQty == 0)
            {
                Paras.SavingResult = CrudDALObj.DeleteRecord(Row.OpeningStockID);
                if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    Row.OpeningStockID = 0;
                    return;
                }                
            }
            else
            {
                base.SaveRecord(Paras, ViewModel);
            }
            //base.SaveRecord(Paras, ViewModel);
        }

        protected override void AfterSaving(SavingParemeter Paras, IGridCRUDViewModel ViewModel)
        {
            ReloadCrudData();
            base.AfterSaving(Paras, ViewModel);
        }

        #endregion

        #region Buttons

        private void btnWithStck_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
        }

        private void repositoryItemOpeningStck_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            gridView1.MoveNext();
        }

        private void repositoryItemDeleteButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                var Row = (ProductOpeningStockViewModel)gridView1.GetFocusedRow();
                if (Row == null)
                {
                    return;
                }
                var res = CrudDALObj.DeleteRecord(Row.OpeningStockID);
                if (res != null && res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    Row.OpeningStockID = 0;
                }
            ReloadCrudData();
            }
        }

        private void repositoryItemOpeningStck_Enter(object sender, EventArgs e)
        {
            repositoryItemOpeningStck.Buttons[0].Visible = true;
        }

        #endregion

        #region Grid events

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var row = (ProductOpeningStockViewModel)gridView1.GetFocusedRow();
            if (row == null)
            {
                return;
            }
            row.RowError = null;
            if (row.OpeningStockID == 0 && row.OpeningStockQty == 0)
            {
                row.RowError += "Can not accept zero in Opening Stock.";
                return;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //repositoryItemOpeningStck.Buttons[0].Visible = false;
        }

        #endregion
    }
}
