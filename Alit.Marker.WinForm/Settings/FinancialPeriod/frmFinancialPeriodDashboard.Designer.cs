namespace Alit.Marker.WinForm.Settings.FinancialPeriod
{
    partial class frmFinancialPeriodDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinancialPeriodDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.finPeriodDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinPeriodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinPeriodFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinPeriodText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCompany = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finPeriodDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCompany});
            this.ribbonControl1.MaxItemId = 49;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1131, 166);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1131, 24);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1131, 55);
            // 
            // lcTitle
            // 
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1131, 55);
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
            this.lblFormCaption.Size = new System.Drawing.Size(1103, 55);
            this.lblFormCaption.Text = "Financial Period";
            this.lblFormCaption.TextSize = new System.Drawing.Size(229, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // rpgMaster
            // 
            this.rpgMaster.ItemLinks.Add(this.btnCompany);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.finPeriodDashboardViewModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 221);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1131, 385);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // finPeriodDashboardViewModelBindingSource
            // 
            this.finPeriodDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Settings.FinancialPeriod.FinPeriodDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinPeriodName,
            this.colFinPeriodFrom,
            this.colFinPeriodText,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colFinPeriodName
            // 
            this.colFinPeriodName.FieldName = "FinPeriodName";
            this.colFinPeriodName.MinWidth = 150;
            this.colFinPeriodName.Name = "colFinPeriodName";
            this.colFinPeriodName.Visible = true;
            this.colFinPeriodName.VisibleIndex = 0;
            this.colFinPeriodName.Width = 150;
            // 
            // colFinPeriodFrom
            // 
            this.colFinPeriodFrom.FieldName = "FinPeriodFrom";
            this.colFinPeriodFrom.MaxWidth = 125;
            this.colFinPeriodFrom.MinWidth = 100;
            this.colFinPeriodFrom.Name = "colFinPeriodFrom";
            this.colFinPeriodFrom.Visible = true;
            this.colFinPeriodFrom.VisibleIndex = 1;
            this.colFinPeriodFrom.Width = 100;
            // 
            // colFinPeriodText
            // 
            this.colFinPeriodText.FieldName = "FinPeriodText";
            this.colFinPeriodText.MaxWidth = 125;
            this.colFinPeriodText.MinWidth = 100;
            this.colFinPeriodText.Name = "colFinPeriodText";
            this.colFinPeriodText.OptionsColumn.ReadOnly = true;
            this.colFinPeriodText.Visible = true;
            this.colFinPeriodText.VisibleIndex = 2;
            this.colFinPeriodText.Width = 100;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 3;
            // 
            // btnCompany
            // 
            this.btnCompany.Caption = "Company";
            this.btnCompany.Id = 47;
            this.btnCompany.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCompany.ImageOptions.SvgImage")));
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCompany_ItemClick);
            // 
            // frmFinancialPeriodDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmFinancialPeriodDashboard.IconOptions.Icon")));
            this.Name = "frmFinancialPeriodDashboard";
            this.Text = "Financial Period";
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
            ((System.ComponentModel.ISupportInitialize)(this.finPeriodDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnCompany;
        private System.Windows.Forms.BindingSource finPeriodDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFinPeriodName;
        private DevExpress.XtraGrid.Columns.GridColumn colFinPeriodFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colFinPeriodText;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}