namespace Alit.Marker.WinForm.City.State
{
    partial class frmStateGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStateGridCRUD));
            this.gcState = new DevExpress.XtraGrid.GridControl();
            this.stateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvState = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemlueCountry = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemlueCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 69);
            this.lblFormCaption.Size = new System.Drawing.Size(1022, 37);
            this.lblFormCaption.Text = "State";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcState
            // 
            this.gcState.DataSource = this.stateViewModelBindingSource;
            this.gcState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcState.Location = new System.Drawing.Point(0, 106);
            this.gcState.MainView = this.gvState;
            this.gcState.MenuManager = this.barManager1;
            this.gcState.Name = "gcState";
            this.gcState.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemlueCountry});
            this.gcState.Size = new System.Drawing.Size(1022, 182);
            this.gcState.TabIndex = 7;
            this.gcState.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvState});
            // 
            // stateViewModelBindingSource
            // 
            this.stateViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.City.State.StateViewModel);
            // 
            // gvState
            // 
            this.gvState.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStateName,
            this.colCountry});
            this.gvState.GridControl = this.gcState;
            this.gvState.Name = "gvState";
            // 
            // colStateName
            // 
            this.colStateName.FieldName = "StateName";
            this.colStateName.Name = "colStateName";
            this.colStateName.Visible = true;
            this.colStateName.VisibleIndex = 0;
            // 
            // colCountry
            // 
            this.colCountry.ColumnEdit = this.repositoryItemlueCountry;
            this.colCountry.FieldName = "CountryID";
            this.colCountry.Name = "colCountry";
            this.colCountry.Visible = true;
            this.colCountry.VisibleIndex = 1;
            // 
            // repositoryItemlueCountry
            // 
            this.repositoryItemlueCountry.AutoHeight = false;
            this.repositoryItemlueCountry.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemlueCountry.Name = "repositoryItemlueCountry";
            this.repositoryItemlueCountry.NullText = "Select";
            // 
            // frmStateGridCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 315);
            this.Controls.Add(this.gcState);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStateGridCRUD.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmStateGridCRUD";
            this.Text = "State";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcState, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemlueCountry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcState;
        private DevExpress.XtraGrid.Views.Grid.GridView gvState;
        private System.Windows.Forms.BindingSource stateViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colStateName;
        private DevExpress.XtraGrid.Columns.GridColumn colCountry;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemlueCountry;
    }
}