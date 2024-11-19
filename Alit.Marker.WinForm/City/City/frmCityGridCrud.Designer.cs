namespace Alit.Marker.WinForm.City.City
{
    partial class frmCityGridCrud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCityGridCrud));
            this.gcCity = new DevExpress.XtraGrid.GridControl();
            this.cityViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvCity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemlueStateCountry = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemlueStateCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 69);
            this.lblFormCaption.Size = new System.Drawing.Size(839, 37);
            this.lblFormCaption.Text = "City";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcCity
            // 
            this.gcCity.DataSource = this.cityViewModelBindingSource;
            this.gcCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCity.Location = new System.Drawing.Point(0, 106);
            this.gcCity.MainView = this.gvCity;
            this.gcCity.MenuManager = this.barManager1;
            this.gcCity.Name = "gcCity";
            this.gcCity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemlueStateCountry});
            this.gcCity.Size = new System.Drawing.Size(839, 300);
            this.gcCity.TabIndex = 7;
            this.gcCity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCity});
            // 
            // cityViewModelBindingSource
            // 
            this.cityViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.City.City.CityViewModel);
            // 
            // gvCity
            // 
            this.gvCity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCityName,
            this.colState});
            this.gvCity.GridControl = this.gcCity;
            this.gvCity.Name = "gvCity";
            this.gvCity.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // colCityName
            // 
            this.colCityName.FieldName = "CityName";
            this.colCityName.Name = "colCityName";
            this.colCityName.Visible = true;
            this.colCityName.VisibleIndex = 0;
            // 
            // colState
            // 
            this.colState.ColumnEdit = this.repositoryItemlueStateCountry;
            this.colState.FieldName = "StateID";
            this.colState.Name = "colState";
            this.colState.Visible = true;
            this.colState.VisibleIndex = 1;
            // 
            // repositoryItemlueStateCountry
            // 
            this.repositoryItemlueStateCountry.AutoHeight = false;
            this.repositoryItemlueStateCountry.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemlueStateCountry.Name = "repositoryItemlueStateCountry";
            this.repositoryItemlueStateCountry.NullText = "Select";
            // 
            // frmCityGridCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 433);
            this.Controls.Add(this.gcCity);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCityGridCrud.IconOptions.Icon")));
            this.Name = "frmCityGridCrud";
            this.Text = "City";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcCity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemlueStateCountry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCity;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCity;
        private System.Windows.Forms.BindingSource cityViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemlueStateCountry;
    }
}