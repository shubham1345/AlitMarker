namespace Alit.Marker.WinForm.Account.Group
{
    partial class frmAccountGroupDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountGroupDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.accountGroupDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccountGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountGroupNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountGroupDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1384, 159);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 607);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1384, 23);
            // 
            // lcTitle
            // 
            this.lcTitle.Location = new System.Drawing.Point(0, 159);
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(28, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(28, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(1356, 55);
            this.lblFormCaption.Text = "Account Group";
            this.lblFormCaption.TextSize = new System.Drawing.Size(217, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.accountGroupDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 214);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1384, 393);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // accountGroupDashboardViewModelBindingSource
            // 
            this.accountGroupDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Account.Group.AccountGroupDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccountGroupName,
            this.colParentGroupName,
            this.colAccountGroupNature,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colAccountGroupName
            // 
            this.colAccountGroupName.FieldName = "AccountGroupName";
            this.colAccountGroupName.MaxWidth = 500;
            this.colAccountGroupName.MinWidth = 140;
            this.colAccountGroupName.Name = "colAccountGroupName";
            this.colAccountGroupName.Visible = true;
            this.colAccountGroupName.VisibleIndex = 0;
            this.colAccountGroupName.Width = 140;
            // 
            // colParentGroupName
            // 
            this.colParentGroupName.FieldName = "ParentGroupName";
            this.colParentGroupName.MaxWidth = 500;
            this.colParentGroupName.MinWidth = 55;
            this.colParentGroupName.Name = "colParentGroupName";
            this.colParentGroupName.Visible = true;
            this.colParentGroupName.VisibleIndex = 1;
            this.colParentGroupName.Width = 55;
            // 
            // colAccountGroupNature
            // 
            this.colAccountGroupNature.FieldName = "AccountGroupNature";
            this.colAccountGroupNature.MaxWidth = 200;
            this.colAccountGroupNature.MinWidth = 90;
            this.colAccountGroupNature.Name = "colAccountGroupNature";
            this.colAccountGroupNature.Visible = true;
            this.colAccountGroupNature.VisibleIndex = 2;
            this.colAccountGroupNature.Width = 90;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 3;
            // 
            // frmAccountGroupDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmAccountGroupDashboard.IconOptions.Icon")));
            this.Name = "frmAccountGroupDashboard";
            this.Text = "Account Group";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountGroupDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource accountGroupDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colParentGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountGroupNature;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}