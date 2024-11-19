using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace Alit.Marker.WinForm.Inventory.Transaction.StockIn
{
    partial class frmStockInCRUD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockInCRUD));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.gcProductDetail = new DevExpress.XtraGrid.GridControl();
            this.stockInProductDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvProductDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditPCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.memoNarration = new Alit.WinformControls.MemoEdit();
            this.txtRecieptNo = new Alit.WinformControls.TextEdit();
            this.dtpDate = new Alit.WinformControls.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colDeleteRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditDeleteRow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInProductDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditPCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNarration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecieptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDeleteRow)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.Size = new System.Drawing.Size(848, 515);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Size = new System.Drawing.Size(848, 455);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcProductDetail);
            this.layoutControl1.Controls.Add(this.memoNarration);
            this.layoutControl1.Controls.Add(this.txtRecieptNo);
            this.layoutControl1.Controls.Add(this.dtpDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(844, 451);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcProductDetail
            // 
            this.gcProductDetail.DataSource = this.stockInProductDetailViewModelBindingSource;
            this.gcProductDetail.Location = new System.Drawing.Point(12, 38);
            this.gcProductDetail.MainView = this.gvProductDetail;
            this.gcProductDetail.MenuManager = this.barManager1;
            this.gcProductDetail.Name = "gcProductDetail";
            this.gcProductDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditRate,
            this.repositoryItemTextEditQuantity,
            this.repositoryItemTextEditPCode,
            this.repositoryItemTextEditAmount,
            this.lookupProduct,
            this.lookupUnit,
            this.repositoryItemButtonEditDeleteRow});
            this.gcProductDetail.Size = new System.Drawing.Size(820, 299);
            this.gcProductDetail.TabIndex = 10;
            this.gcProductDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProductDetail});
            // 
            // stockInProductDetailViewModelBindingSource
            // 
            this.stockInProductDetailViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Transaction.StockIn.StockInProductDetailViewModel);
            // 
            // gvProductDetail
            // 
            this.gvProductDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductNo,
            this.colBarcode,
            this.colProductName,
            this.colQty,
            this.colUnitName,
            this.colRate,
            this.colAmount,
            this.colDeleteRow});
            this.gvProductDetail.GridControl = this.gcProductDetail;
            this.gvProductDetail.Name = "gvProductDetail";
            this.gvProductDetail.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvProductDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvProductDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvProductDetail.OptionsView.ShowGroupPanel = false;
            this.gvProductDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvProductDetail_CellValueChanged);
            // 
            // colProductNo
            // 
            this.colProductNo.ColumnEdit = this.repositoryItemTextEditPCode;
            this.colProductNo.FieldName = "PCode";
            this.colProductNo.MaxWidth = 100;
            this.colProductNo.MinWidth = 50;
            this.colProductNo.Name = "colProductNo";
            this.colProductNo.Visible = true;
            this.colProductNo.VisibleIndex = 0;
            this.colProductNo.Width = 68;
            // 
            // repositoryItemTextEditPCode
            // 
            this.repositoryItemTextEditPCode.AutoHeight = false;
            this.repositoryItemTextEditPCode.Mask.EditMask = "n0";
            this.repositoryItemTextEditPCode.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEditPCode.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEditPCode.MaxLength = 10;
            this.repositoryItemTextEditPCode.Name = "repositoryItemTextEditPCode";
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.MaxWidth = 200;
            this.colBarcode.MinWidth = 75;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            this.colBarcode.Width = 95;
            // 
            // colProductName
            // 
            this.colProductName.ColumnEdit = this.lookupProduct;
            this.colProductName.FieldName = "ProductID";
            this.colProductName.MaxWidth = 500;
            this.colProductName.MinWidth = 100;
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            this.colProductName.Width = 260;
            // 
            // lookupProduct
            // 
            this.lookupProduct.AutoHeight = false;
            this.lookupProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupProduct.DropDownRows = 10;
            this.lookupProduct.Name = "lookupProduct";
            this.lookupProduct.NullText = "";
            this.lookupProduct.PopupWidth = 700;
            // 
            // colQty
            // 
            this.colQty.ColumnEdit = this.repositoryItemTextEditQuantity;
            this.colQty.FieldName = "Quantity";
            this.colQty.MaxWidth = 125;
            this.colQty.MinWidth = 75;
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 3;
            this.colQty.Width = 98;
            // 
            // repositoryItemTextEditQuantity
            // 
            this.repositoryItemTextEditQuantity.AutoHeight = false;
            this.repositoryItemTextEditQuantity.Mask.EditMask = "n2";
            this.repositoryItemTextEditQuantity.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEditQuantity.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEditQuantity.MaxLength = 12;
            this.repositoryItemTextEditQuantity.Name = "repositoryItemTextEditQuantity";
            // 
            // colUnitName
            // 
            this.colUnitName.ColumnEdit = this.lookupUnit;
            this.colUnitName.FieldName = "UnitID";
            this.colUnitName.MaxWidth = 100;
            this.colUnitName.MinWidth = 50;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.OptionsColumn.AllowEdit = false;
            this.colUnitName.OptionsColumn.ReadOnly = true;
            this.colUnitName.OptionsColumn.TabStop = false;
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 4;
            this.colUnitName.Width = 50;
            // 
            // lookupUnit
            // 
            this.lookupUnit.AutoHeight = false;
            this.lookupUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupUnit.Name = "lookupUnit";
            this.lookupUnit.NullText = "";
            // 
            // colRate
            // 
            this.colRate.ColumnEdit = this.repositoryItemTextEditRate;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 125;
            this.colRate.MinWidth = 75;
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 5;
            this.colRate.Width = 98;
            // 
            // repositoryItemTextEditRate
            // 
            this.repositoryItemTextEditRate.AutoHeight = false;
            this.repositoryItemTextEditRate.Mask.EditMask = "n2";
            this.repositoryItemTextEditRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEditRate.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEditRate.MaxLength = 12;
            this.repositoryItemTextEditRate.Name = "repositoryItemTextEditRate";
            // 
            // colAmount
            // 
            this.colAmount.ColumnEdit = this.repositoryItemTextEditAmount;
            this.colAmount.FieldName = "GAmt";
            this.colAmount.MaxWidth = 175;
            this.colAmount.MinWidth = 100;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowEdit = false;
            this.colAmount.OptionsColumn.ReadOnly = true;
            this.colAmount.OptionsColumn.TabStop = false;
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            this.colAmount.Width = 150;
            // 
            // repositoryItemTextEditAmount
            // 
            this.repositoryItemTextEditAmount.AutoHeight = false;
            this.repositoryItemTextEditAmount.Mask.EditMask = "n2";
            this.repositoryItemTextEditAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEditAmount.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEditAmount.MaxLength = 12;
            this.repositoryItemTextEditAmount.Name = "repositoryItemTextEditAmount";
            // 
            // memoNarration
            // 
            this.memoNarration.Location = new System.Drawing.Point(12, 360);
            this.memoNarration.MaximumSize = new System.Drawing.Size(0, 100);
            this.memoNarration.MenuManager = this.barManager1;
            this.memoNarration.MinimumSize = new System.Drawing.Size(100, 30);
            this.memoNarration.Name = "memoNarration";
            this.memoNarration.Properties.MaxLength = 1000;
            this.memoNarration.Size = new System.Drawing.Size(820, 79);
            this.memoNarration.StyleController = this.layoutControl1;
            this.memoNarration.TabIndex = 9;
            this.memoNarration.TabStop = false;
            // 
            // txtRecieptNo
            // 
            this.txtRecieptNo.EditValue = ((long)(0));
            this.txtRecieptNo.EnterMoveNextControl = true;
            this.txtRecieptNo.Location = new System.Drawing.Point(269, 12);
            this.txtRecieptNo.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtRecieptNo.MenuManager = this.barManager1;
            this.txtRecieptNo.MinimumSize = new System.Drawing.Size(50, 0);
            this.txtRecieptNo.Name = "txtRecieptNo";
            this.txtRecieptNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRecieptNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRecieptNo.Properties.Mask.EditMask = "n0";
            this.txtRecieptNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRecieptNo.Properties.ReadOnly = true;
            this.txtRecieptNo.Size = new System.Drawing.Size(100, 22);
            this.txtRecieptNo.StyleController = this.layoutControl1;
            this.txtRecieptNo.TabIndex = 5;
            this.txtRecieptNo.TabStop = false;
            this.txtRecieptNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtRecieptNo_Validating);
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = null;
            this.dtpDate.EnterMoveNextControl = true;
            this.dtpDate.Location = new System.Drawing.Point(44, 12);
            this.dtpDate.MaximumSize = new System.Drawing.Size(150, 0);
            this.dtpDate.MenuManager = this.barManager1;
            this.dtpDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtpDate.Size = new System.Drawing.Size(150, 22);
            this.dtpDate.StyleController = this.layoutControl1;
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDate_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(844, 451);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.memoNarration;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 329);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(824, 102);
            this.layoutControlItem6.Text = "Narration";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtRecieptNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(186, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(175, 26);
            this.layoutControlItem1.Text = "Receipt No.";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtpDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(186, 26);
            this.layoutControlItem2.Text = "Date";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(27, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(361, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(463, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcProductDetail;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(824, 303);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // colDeleteRow
            // 
            this.colDeleteRow.ColumnEdit = this.repositoryItemButtonEditDeleteRow;
            this.colDeleteRow.MaxWidth = 20;
            this.colDeleteRow.Name = "colDeleteRow";
            this.colDeleteRow.OptionsColumn.TabStop = false;
            this.colDeleteRow.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDeleteRow.Visible = true;
            this.colDeleteRow.VisibleIndex = 7;
            this.colDeleteRow.Width = 20;
            // 
            // repositoryItemButtonEditDeleteRow
            // 
            this.repositoryItemButtonEditDeleteRow.AutoHeight = false;
            this.repositoryItemButtonEditDeleteRow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditDeleteRow.Name = "repositoryItemButtonEditDeleteRow";
            this.repositoryItemButtonEditDeleteRow.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditDeleteRow_ButtonClick);
            // 
            // frmStockInCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 515);
            this.FirstControl = this.layoutControl1;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStockInCRUD.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockInCRUD";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Stock In";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).EndInit();
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInProductDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditPCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNarration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecieptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDeleteRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Alit.WinformControls.TextEdit txtRecieptNo;
        private Alit.WinformControls.DateEdit dtpDate;
        private Alit.WinformControls.MemoEdit memoNarration;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private GridControl gcProductDetail;
        private GridView gvProductDetail;
        private LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource stockInProductDetailViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupProduct;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditDeleteRow;
    }
}