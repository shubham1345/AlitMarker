namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTax
{
    partial class frmStockItemTaxGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockItemTaxGridCRUD));
            this.gcStockItemTax = new DevExpress.XtraGrid.GridControl();
            this.gvStockItemTax = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditItemName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPerc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditPercentage = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colInclusiveTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductTaxCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditProductTax = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockItemTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockItemTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProductTax)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Masters.StockItemTax.StockItemTaxViewModel);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 64);
            this.lblFormCaption.Size = new System.Drawing.Size(853, 37);
            this.lblFormCaption.Text = "Stock Item Tax";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcStockItemTax
            // 
            this.gcStockItemTax.DataSource = this.bindingSource;
            this.gcStockItemTax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStockItemTax.Location = new System.Drawing.Point(0, 101);
            this.gcStockItemTax.MainView = this.gvStockItemTax;
            this.gcStockItemTax.MenuManager = this.barManager1;
            this.gcStockItemTax.Name = "gcStockItemTax";
            this.gcStockItemTax.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditProductTax,
            this.repositoryItemTextEditItemName,
            this.repositoryItemTextEditPercentage});
            this.gcStockItemTax.Size = new System.Drawing.Size(853, 315);
            this.gcStockItemTax.TabIndex = 7;
            this.gcStockItemTax.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockItemTax});
            // 
            // gvStockItemTax
            // 
            this.gvStockItemTax.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colPerc,
            this.colInclusiveTax,
            this.colProductTaxCategoryID});
            this.gvStockItemTax.GridControl = this.gcStockItemTax;
            this.gvStockItemTax.Name = "gvStockItemTax";
            this.gvStockItemTax.OptionsView.ShowGroupPanel = false;
            // 
            // colItemName
            // 
            this.colItemName.ColumnEdit = this.repositoryItemTextEditItemName;
            this.colItemName.FieldName = "ItemName";
            this.colItemName.MaxWidth = 500;
            this.colItemName.MinWidth = 100;
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 100;
            // 
            // repositoryItemTextEditItemName
            // 
            this.repositoryItemTextEditItemName.AutoHeight = false;
            this.repositoryItemTextEditItemName.MaxLength = 50;
            this.repositoryItemTextEditItemName.Name = "repositoryItemTextEditItemName";
            // 
            // colPerc
            // 
            this.colPerc.ColumnEdit = this.repositoryItemTextEditPercentage;
            this.colPerc.FieldName = "Perc";
            this.colPerc.MaxWidth = 100;
            this.colPerc.MinWidth = 50;
            this.colPerc.Name = "colPerc";
            this.colPerc.Visible = true;
            this.colPerc.VisibleIndex = 1;
            // 
            // repositoryItemTextEditPercentage
            // 
            this.repositoryItemTextEditPercentage.AutoHeight = false;
            this.repositoryItemTextEditPercentage.Mask.EditMask = "p";
            this.repositoryItemTextEditPercentage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEditPercentage.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEditPercentage.MaxLength = 5;
            this.repositoryItemTextEditPercentage.Name = "repositoryItemTextEditPercentage";
            // 
            // colInclusiveTax
            // 
            this.colInclusiveTax.FieldName = "InclusiveTax";
            this.colInclusiveTax.MaxWidth = 100;
            this.colInclusiveTax.MinWidth = 90;
            this.colInclusiveTax.Name = "colInclusiveTax";
            this.colInclusiveTax.Visible = true;
            this.colInclusiveTax.VisibleIndex = 2;
            this.colInclusiveTax.Width = 90;
            // 
            // colProductTaxCategoryID
            // 
            this.colProductTaxCategoryID.ColumnEdit = this.repositoryItemLookUpEditProductTax;
            this.colProductTaxCategoryID.FieldName = "ProductTaxCategoryID";
            this.colProductTaxCategoryID.MaxWidth = 500;
            this.colProductTaxCategoryID.MinWidth = 100;
            this.colProductTaxCategoryID.Name = "colProductTaxCategoryID";
            this.colProductTaxCategoryID.Visible = true;
            this.colProductTaxCategoryID.VisibleIndex = 3;
            this.colProductTaxCategoryID.Width = 100;
            // 
            // repositoryItemLookUpEditProductTax
            // 
            this.repositoryItemLookUpEditProductTax.AutoHeight = false;
            this.repositoryItemLookUpEditProductTax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditProductTax.Name = "repositoryItemLookUpEditProductTax";
            this.repositoryItemLookUpEditProductTax.NullText = "Select";
            // 
            // frmStockItemTaxGridCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 441);
            this.Controls.Add(this.gcStockItemTax);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStockItemTaxGridCRUD.IconOptions.Icon")));
            this.Name = "frmStockItemTaxGridCRUD";
            this.Text = "Stock Item Tax";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcStockItemTax, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockItemTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockItemTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProductTax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcStockItemTax;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockItemTax;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colInclusiveTax;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTaxCategoryID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProductTax;
    }
}