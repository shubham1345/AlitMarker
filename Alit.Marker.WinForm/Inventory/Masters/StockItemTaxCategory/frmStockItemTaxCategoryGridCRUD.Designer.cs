namespace Alit.Marker.WinForm.Inventory.Masters.StockItemTaxCategory
{
    partial class frmStockItemTaxCategoryGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockItemTaxCategoryGridCRUD));
            this.gcStockItemTaxCategory = new DevExpress.XtraGrid.GridControl();
            this.gvStockItemTaxCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductTaxCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colIsInterstateTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApplicable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockItemTaxCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockItemTaxCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Masters.StockItemTaxCategory.StockItemTaxCategoryViewModel);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 64);
            this.lblFormCaption.Size = new System.Drawing.Size(853, 37);
            this.lblFormCaption.Text = "Stock Item Tax Category";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcStockItemTaxCategory
            // 
            this.gcStockItemTaxCategory.DataSource = this.bindingSource;
            this.gcStockItemTaxCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStockItemTaxCategory.Location = new System.Drawing.Point(0, 101);
            this.gcStockItemTaxCategory.MainView = this.gvStockItemTaxCategory;
            this.gcStockItemTaxCategory.MenuManager = this.barManager1;
            this.gcStockItemTaxCategory.Name = "gcStockItemTaxCategory";
            this.gcStockItemTaxCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gcStockItemTaxCategory.Size = new System.Drawing.Size(853, 315);
            this.gcStockItemTaxCategory.TabIndex = 7;
            this.gcStockItemTaxCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockItemTaxCategory});
            // 
            // gvStockItemTaxCategory
            // 
            this.gvStockItemTaxCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxIndex,
            this.colProductTaxCategoryName,
            this.colIsInterstateTax,
            this.colApplicable});
            this.gvStockItemTaxCategory.GridControl = this.gcStockItemTaxCategory;
            this.gvStockItemTaxCategory.Name = "gvStockItemTaxCategory";
            this.gvStockItemTaxCategory.OptionsView.ShowGroupPanel = false;
            // 
            // colProductTaxCategoryName
            // 
            this.colProductTaxCategoryName.ColumnEdit = this.repositoryItemTextEdit1;
            this.colProductTaxCategoryName.FieldName = "ProductTaxCategoryName";
            this.colProductTaxCategoryName.MaxWidth = 500;
            this.colProductTaxCategoryName.MinWidth = 200;
            this.colProductTaxCategoryName.Name = "colProductTaxCategoryName";
            this.colProductTaxCategoryName.Visible = true;
            this.colProductTaxCategoryName.VisibleIndex = 1;
            this.colProductTaxCategoryName.Width = 200;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.MaxLength = 50;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colIsInterstateTax
            // 
            this.colIsInterstateTax.FieldName = "IsInterstateTax";
            this.colIsInterstateTax.MaxWidth = 100;
            this.colIsInterstateTax.MinWidth = 90;
            this.colIsInterstateTax.Name = "colIsInterstateTax";
            this.colIsInterstateTax.Visible = true;
            this.colIsInterstateTax.VisibleIndex = 2;
            this.colIsInterstateTax.Width = 90;
            // 
            // colApplicable
            // 
            this.colApplicable.FieldName = "Applicable";
            this.colApplicable.MaxWidth = 100;
            this.colApplicable.MinWidth = 50;
            this.colApplicable.Name = "colApplicable";
            this.colApplicable.Visible = true;
            this.colApplicable.VisibleIndex = 3;
            // 
            // colTaxIndex
            // 
            this.colTaxIndex.FieldName = "TaxIndex";
            this.colTaxIndex.MaxWidth = 100;
            this.colTaxIndex.MinWidth = 50;
            this.colTaxIndex.Name = "colTaxIndex";
            this.colTaxIndex.OptionsColumn.AllowEdit = false;
            this.colTaxIndex.OptionsColumn.ReadOnly = true;
            this.colTaxIndex.OptionsColumn.TabStop = false;
            this.colTaxIndex.Visible = true;
            this.colTaxIndex.VisibleIndex = 0;
            // 
            // frmStockItemTaxCategoryGridCRUD
            // 
            this.AllowAddNewEnable = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 441);
            this.Controls.Add(this.gcStockItemTaxCategory);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStockItemTaxCategoryGridCRUD.IconOptions.Icon")));
            this.Name = "frmStockItemTaxCategoryGridCRUD";
            this.Text = "Stock Item Tax Category";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcStockItemTaxCategory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockItemTaxCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockItemTaxCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcStockItemTaxCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockItemTaxCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTaxCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsInterstateTax;
        private DevExpress.XtraGrid.Columns.GridColumn colApplicable;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxIndex;
    }
}