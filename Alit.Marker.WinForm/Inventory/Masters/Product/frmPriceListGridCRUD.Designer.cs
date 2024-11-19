namespace Alit.Marker.WinForm.Inventory.Masters.Product
{
    partial class frmPriceListGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriceListGridCRUD));
            this.gcPriceList = new DevExpress.XtraGrid.GridControl();
            this.gvPriceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriceListName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditUnitName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPriceListShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditShortName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditUnitName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditShortName)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Alit.Marker.Model.Inventory.Masters.Product.PriceListViewModel);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 64);
            this.lblFormCaption.Size = new System.Drawing.Size(853, 37);
            this.lblFormCaption.Text = "Price List";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcPriceList
            // 
            this.gcPriceList.DataSource = this.bindingSource;
            this.gcPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPriceList.Location = new System.Drawing.Point(0, 101);
            this.gcPriceList.MainView = this.gvPriceList;
            this.gcPriceList.MenuManager = this.barManager1;
            this.gcPriceList.Name = "gcPriceList";
            this.gcPriceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditUnitName,
            this.repositoryItemTextEditShortName});
            this.gcPriceList.Size = new System.Drawing.Size(853, 315);
            this.gcPriceList.TabIndex = 7;
            this.gcPriceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPriceList});
            // 
            // gvPriceList
            // 
            this.gvPriceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriceListName,
            this.colPriceListShortName});
            this.gvPriceList.GridControl = this.gcPriceList;
            this.gvPriceList.Name = "gvPriceList";
            this.gvPriceList.OptionsView.ShowGroupPanel = false;
            // 
            // colPriceListName
            // 
            this.colPriceListName.ColumnEdit = this.repositoryItemTextEditUnitName;
            this.colPriceListName.FieldName = "PriceListName";
            this.colPriceListName.Name = "colPriceListName";
            this.colPriceListName.Visible = true;
            this.colPriceListName.VisibleIndex = 0;
            // 
            // repositoryItemTextEditUnitName
            // 
            this.repositoryItemTextEditUnitName.AutoHeight = false;
            this.repositoryItemTextEditUnitName.MaxLength = 50;
            this.repositoryItemTextEditUnitName.Name = "repositoryItemTextEditUnitName";
            // 
            // colPriceListShortName
            // 
            this.colPriceListShortName.ColumnEdit = this.repositoryItemTextEditShortName;
            this.colPriceListShortName.FieldName = "PriceListShortName";
            this.colPriceListShortName.MaxWidth = 100;
            this.colPriceListShortName.Name = "colPriceListShortName";
            this.colPriceListShortName.Visible = true;
            this.colPriceListShortName.VisibleIndex = 1;
            // 
            // repositoryItemTextEditShortName
            // 
            this.repositoryItemTextEditShortName.AutoHeight = false;
            this.repositoryItemTextEditShortName.MaxLength = 5;
            this.repositoryItemTextEditShortName.Name = "repositoryItemTextEditShortName";
            // 
            // frmPriceListGridCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 441);
            this.Controls.Add(this.gcPriceList);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmPriceListGridCRUD.IconOptions.Icon")));
            this.Name = "frmPriceListGridCRUD";
            this.Text = "Price List";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcPriceList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditUnitName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditShortName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPriceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPriceList;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListShortName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditShortName;
    }
}