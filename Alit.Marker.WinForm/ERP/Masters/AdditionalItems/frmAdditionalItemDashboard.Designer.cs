namespace Alit.Marker.WinForm.ERP.Masters.AdditionalItems
{
    partial class frmAdditionalItemDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdditionalItemDashboard));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.additionalItemDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalculateOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReverseCalculate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInclusiveRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddByDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItemDashboardViewModelBindingSource)).BeginInit();
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
            // 
            // lcTitle
            // 
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
            this.lblFormCaption.Text = "Discount and Tax";
            this.lblFormCaption.TextSize = new System.Drawing.Size(251, 38);
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
            this.gridControl1.DataSource = this.additionalItemDashboardViewModelBindingSource;
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
            // additionalItemDashboardViewModelBindingSource
            // 
            this.additionalItemDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.ERP.Masters.AdditionalItems.AdditionalItemDashboardViewModel);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 41;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colNature,
            this.colCalculateOn,
            this.colPercentage,
            this.colReverseCalculate,
            this.colInclusiveRate,
            this.colAddByDefault,
            this.colDefaultOrder,
            this.colRecordState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.AllowMultilineHeaders = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            // 
            // colItemName
            // 
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 584;
            // 
            // colNature
            // 
            this.colNature.FieldName = "Nature";
            this.colNature.MaxWidth = 100;
            this.colNature.MinWidth = 60;
            this.colNature.Name = "colNature";
            this.colNature.Visible = true;
            this.colNature.VisibleIndex = 1;
            this.colNature.Width = 100;
            // 
            // colCalculateOn
            // 
            this.colCalculateOn.FieldName = "CalculateOn";
            this.colCalculateOn.MaxWidth = 125;
            this.colCalculateOn.MinWidth = 75;
            this.colCalculateOn.Name = "colCalculateOn";
            this.colCalculateOn.Visible = true;
            this.colCalculateOn.VisibleIndex = 2;
            this.colCalculateOn.Width = 125;
            // 
            // colPercentage
            // 
            this.colPercentage.DisplayFormat.FormatString = "n2";
            this.colPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentage.FieldName = "Percentage";
            this.colPercentage.MaxWidth = 100;
            this.colPercentage.MinWidth = 60;
            this.colPercentage.Name = "colPercentage";
            this.colPercentage.Visible = true;
            this.colPercentage.VisibleIndex = 3;
            this.colPercentage.Width = 100;
            // 
            // colReverseCalculate
            // 
            this.colReverseCalculate.FieldName = "ReverseCalculate";
            this.colReverseCalculate.MaxWidth = 100;
            this.colReverseCalculate.MinWidth = 75;
            this.colReverseCalculate.Name = "colReverseCalculate";
            this.colReverseCalculate.Visible = true;
            this.colReverseCalculate.VisibleIndex = 4;
            // 
            // colInclusiveRate
            // 
            this.colInclusiveRate.FieldName = "InclusiveRate";
            this.colInclusiveRate.MaxWidth = 75;
            this.colInclusiveRate.MinWidth = 75;
            this.colInclusiveRate.Name = "colInclusiveRate";
            this.colInclusiveRate.Visible = true;
            this.colInclusiveRate.VisibleIndex = 5;
            // 
            // colAddByDefault
            // 
            this.colAddByDefault.FieldName = "AddByDefault";
            this.colAddByDefault.MaxWidth = 100;
            this.colAddByDefault.MinWidth = 50;
            this.colAddByDefault.Name = "colAddByDefault";
            this.colAddByDefault.Visible = true;
            this.colAddByDefault.VisibleIndex = 6;
            this.colAddByDefault.Width = 100;
            // 
            // colDefaultOrder
            // 
            this.colDefaultOrder.FieldName = "DefaultOrder";
            this.colDefaultOrder.MaxWidth = 100;
            this.colDefaultOrder.MinWidth = 50;
            this.colDefaultOrder.Name = "colDefaultOrder";
            this.colDefaultOrder.Visible = true;
            this.colDefaultOrder.VisibleIndex = 7;
            this.colDefaultOrder.Width = 83;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 60;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 8;
            this.colRecordState.Width = 92;
            // 
            // frmAdditionalItemDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmAdditionalItemDashboard.IconOptions.Icon")));
            this.Name = "frmAdditionalItemDashboard";
            this.Text = "Discount and Tax";
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
            ((System.ComponentModel.ISupportInitialize)(this.additionalItemDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource additionalItemDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colNature;
        private DevExpress.XtraGrid.Columns.GridColumn colCalculateOn;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colReverseCalculate;
        private DevExpress.XtraGrid.Columns.GridColumn colInclusiveRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAddByDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}