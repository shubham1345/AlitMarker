namespace Alit.Marker.WinForm.Users.UserGroup
{
    partial class frmUserGroupGridCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserGroupGridCRUD));
            this.gcUserGroup = new DevExpress.XtraGrid.GridControl();
            this.userGroupViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtUserGroup = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGroupViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 69);
            this.lblFormCaption.Size = new System.Drawing.Size(891, 37);
            this.lblFormCaption.Text = "User Group";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcUserGroup
            // 
            this.gcUserGroup.DataSource = this.userGroupViewModelBindingSource;
            this.gcUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUserGroup.Location = new System.Drawing.Point(0, 106);
            this.gcUserGroup.MainView = this.gvUserGroup;
            this.gcUserGroup.MenuManager = this.barManager1;
            this.gcUserGroup.Name = "gcUserGroup";
            this.gcUserGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemtxtUserGroup});
            this.gcUserGroup.Size = new System.Drawing.Size(891, 300);
            this.gcUserGroup.TabIndex = 7;
            this.gcUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserGroup});
            // 
            // userGroupViewModelBindingSource
            // 
            this.userGroupViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Users.UserGroup.UserGroupViewModel);
            // 
            // gvUserGroup
            // 
            this.gvUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserGroupName});
            this.gvUserGroup.GridControl = this.gcUserGroup;
            this.gvUserGroup.Name = "gvUserGroup";
            // 
            // colUserGroupName
            // 
            this.colUserGroupName.ColumnEdit = this.repositoryItemtxtUserGroup;
            this.colUserGroupName.FieldName = "UserGroupName";
            this.colUserGroupName.MaxWidth = 500;
            this.colUserGroupName.MinWidth = 100;
            this.colUserGroupName.Name = "colUserGroupName";
            this.colUserGroupName.Visible = true;
            this.colUserGroupName.VisibleIndex = 0;
            this.colUserGroupName.Width = 100;
            // 
            // repositoryItemtxtUserGroup
            // 
            this.repositoryItemtxtUserGroup.AutoHeight = false;
            this.repositoryItemtxtUserGroup.MaxLength = 50;
            this.repositoryItemtxtUserGroup.Name = "repositoryItemtxtUserGroup";
            // 
            // frmUserGroupGridCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 433);
            this.Controls.Add(this.gcUserGroup);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmUserGroupGridCRUD.IconOptions.Icon")));
            this.Name = "frmUserGroupGridCRUD";
            this.Text = "User Group";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcUserGroup, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGroupViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtUserGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserGroup;
        private System.Windows.Forms.BindingSource userGroupViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemtxtUserGroup;
    }
}