namespace Alit.Marker.WinForm.Inventory
{
    partial class frmOpeningStockGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpeningStockGridCRUD));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productOpeningStockViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningStockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemOpeningStck = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colUpdateUpdateButton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDeleteButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
       
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOpeningStockViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemOpeningStck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDeleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 64);
            this.lblFormCaption.Size = new System.Drawing.Size(1087, 37);
            this.lblFormCaption.Text = "Opening Stock";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gridControl1);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(0, 101);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1087, 259);
            this.myLayoutControl1.TabIndex = 7;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productOpeningStockViewModelBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDeleteButton,
            this.repositoryItemOpeningStck});
            this.gridControl1.Size = new System.Drawing.Size(1063, 235);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productOpeningStockViewModelBindingSource
            // 
            this.productOpeningStockViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.ProductOpeningStockViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPCode,
            this.colBarcode,
            this.colHSN,
            this.colProductName,
            this.colUnitName,
            this.colOpeningStockQty,
            this.colUpdateUpdateButton});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colPCode
            // 
            this.colPCode.FieldName = "PCode";
            this.colPCode.MaxWidth = 125;
            this.colPCode.MinWidth = 75;
            this.colPCode.Name = "colPCode";
            this.colPCode.OptionsColumn.AllowEdit = false;
            this.colPCode.OptionsColumn.AllowFocus = false;
            this.colPCode.OptionsColumn.ReadOnly = true;
            this.colPCode.Visible = true;
            this.colPCode.VisibleIndex = 0;
            this.colPCode.Width = 125;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "BarCode";
            this.colBarcode.MaxWidth = 125;
            this.colBarcode.MinWidth = 75;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.AllowEdit = false;
            this.colBarcode.OptionsColumn.AllowFocus = false;
            this.colBarcode.OptionsColumn.ReadOnly = true;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            this.colBarcode.Width = 125;
            // 
            // colHSN
            // 
            this.colHSN.FieldName = "HSN";
            this.colHSN.MaxWidth = 125;
            this.colHSN.MinWidth = 75;
            this.colHSN.Name = "colHSN";
            this.colHSN.OptionsColumn.AllowEdit = false;
            this.colHSN.OptionsColumn.AllowFocus = false;
            this.colHSN.OptionsColumn.ReadOnly = true;
            this.colHSN.Visible = true;
            this.colHSN.VisibleIndex = 2;
            this.colHSN.Width = 125;
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MaxWidth = 500;
            this.colProductName.MinWidth = 150;
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsColumn.AllowEdit = false;
            this.colProductName.OptionsColumn.AllowFocus = false;
            this.colProductName.OptionsColumn.ReadOnly = true;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 444;
            // 
            // colUnitName
            // 
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MaxWidth = 125;
            this.colUnitName.MinWidth = 75;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.OptionsColumn.AllowEdit = false;
            this.colUnitName.OptionsColumn.AllowFocus = false;
            this.colUnitName.OptionsColumn.ReadOnly = true;
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 4;
            this.colUnitName.Width = 125;
            // 
            // colOpeningStockQty
            // 
            this.colOpeningStockQty.ColumnEdit = this.repositoryItemOpeningStck;
            this.colOpeningStockQty.FieldName = "OpeningStockQty";
            this.colOpeningStockQty.MaxWidth = 125;
            this.colOpeningStockQty.MinWidth = 90;
            this.colOpeningStockQty.Name = "colOpeningStockQty";
            this.colOpeningStockQty.Visible = true;
            this.colOpeningStockQty.VisibleIndex = 5;
            this.colOpeningStockQty.Width = 125;
            // 
            // repositoryItemOpeningStck
            // 
            this.repositoryItemOpeningStck.AutoHeight = false;
            this.repositoryItemOpeningStck.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.repositoryItemOpeningStck.DisplayFormat.FormatString = "{0:#,#0.00;-#,#0.00; }";
            this.repositoryItemOpeningStck.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemOpeningStck.Mask.EditMask = "n2";
            this.repositoryItemOpeningStck.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemOpeningStck.Name = "repositoryItemOpeningStck";
            this.repositoryItemOpeningStck.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemOpeningStck_ButtonClick);
            this.repositoryItemOpeningStck.Enter += new System.EventHandler(this.repositoryItemOpeningStck_Enter);
            // 
            // colUpdateUpdateButton
            // 
            this.colUpdateUpdateButton.ColumnEdit = this.repositoryItemDeleteButton;
            this.colUpdateUpdateButton.MaxWidth = 20;
            this.colUpdateUpdateButton.Name = "colUpdateUpdateButton";
            this.colUpdateUpdateButton.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colUpdateUpdateButton.Visible = true;
            this.colUpdateUpdateButton.VisibleIndex = 6;
            this.colUpdateUpdateButton.Width = 20;
            // 
            // repositoryItemDeleteButton
            // 
            this.repositoryItemDeleteButton.AutoHeight = false;
            this.repositoryItemDeleteButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemDeleteButton.Name = "repositoryItemDeleteButton";
            this.repositoryItemDeleteButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemDeleteButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemDeleteButton_ButtonClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1087, 259);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1067, 239);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "With Stock";
            this.barButtonItem1.Id = 45;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
         
         
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Near;
            this.barButtonItem2.Id = 45;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 45;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "With Stock";
            this.barButtonItem4.Id = 45;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // frmOpeningStockGridCrudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 385);
            this.Controls.Add(this.myLayoutControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmOpeningStockGridCrudForm.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmOpeningStockGridCrudForm";
            this.Text = "Opening Stock";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.myLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOpeningStockViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemOpeningStck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDeleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningStockQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colHSN;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource productOpeningStockViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateUpdateButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemDeleteButton;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemOpeningStck;
    }
}