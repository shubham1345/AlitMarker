namespace Alit.Marker.WinForm.Manufacturing.Process
{
    partial class frmProcessDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessDashboard));
            this.gridControlProcess = new DevExpress.XtraGrid.GridControl();
            this.processDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcessDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinishQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnProductFormula = new DevExpress.XtraBars.BarButtonItem();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnProductFormula});
            this.ribbonControl1.MaxItemId = 51;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonPage1
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            // 
            // lcTitle
            // 
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(392, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(392, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(992, 55);
            this.lblFormCaption.Text = "Process";
            this.lblFormCaption.TextSize = new System.Drawing.Size(118, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // gridControlProcess
            // 
            this.gridControlProcess.DataSource = this.processDashboardViewModelBindingSource;
            this.gridControlProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProcess.Location = new System.Drawing.Point(0, 221);
            this.gridControlProcess.MainView = this.gridViewProcess;
            this.gridControlProcess.MenuManager = this.ribbonControl1;
            this.gridControlProcess.Name = "gridControlProcess";
            this.gridControlProcess.Size = new System.Drawing.Size(1384, 385);
            this.gridControlProcess.TabIndex = 11;
            this.gridControlProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProcess});
            // 
            // processDashboardViewModelBindingSource
            // 
            this.processDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Manufacturing.Process.ProcessDashboardViewModel);
            // 
            // gridViewProcess
            // 
            this.gridViewProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcessDate,
            this.colProcessNo,
            this.colPCode,
            this.colBarcode,
            this.colProductName,
            this.colNarration,
            this.colFinishQuantity,
            this.colUnitName,
            this.colRate,
            this.colAmount,
            this.colRecordState});
            this.gridViewProcess.CustomizationFormBounds = new System.Drawing.Rectangle(1114, 432, 252, 296);
            this.gridViewProcess.GridControl = this.gridControlProcess;
            this.gridViewProcess.Name = "gridViewProcess";
            this.gridViewProcess.OptionsView.ShowGroupPanel = false;
            // 
            // colProcessDate
            // 
            this.colProcessDate.FieldName = "ProcessDate";
            this.colProcessDate.MaxWidth = 125;
            this.colProcessDate.MinWidth = 100;
            this.colProcessDate.Name = "colProcessDate";
            this.colProcessDate.Visible = true;
            this.colProcessDate.VisibleIndex = 0;
            this.colProcessDate.Width = 125;
            // 
            // colProcessNo
            // 
            this.colProcessNo.FieldName = "ProcessNo";
            this.colProcessNo.MaxWidth = 100;
            this.colProcessNo.MinWidth = 50;
            this.colProcessNo.Name = "colProcessNo";
            this.colProcessNo.Visible = true;
            this.colProcessNo.VisibleIndex = 1;
            this.colProcessNo.Width = 100;
            // 
            // colPCode
            // 
            this.colPCode.FieldName = "PCode";
            this.colPCode.MaxWidth = 100;
            this.colPCode.MinWidth = 50;
            this.colPCode.Name = "colPCode";
            this.colPCode.Visible = true;
            this.colPCode.VisibleIndex = 2;
            this.colPCode.Width = 100;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.MaxWidth = 150;
            this.colBarcode.MinWidth = 75;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 3;
            this.colBarcode.Width = 141;
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "ProductName";
            this.colProductName.MaxWidth = 500;
            this.colProductName.MinWidth = 100;
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 4;
            this.colProductName.Width = 447;
            // 
            // colFinishQuantity
            // 
            this.colFinishQuantity.DisplayFormat.FormatString = "n2";
            this.colFinishQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinishQuantity.FieldName = "FinishQuantity";
            this.colFinishQuantity.MaxWidth = 125;
            this.colFinishQuantity.MinWidth = 75;
            this.colFinishQuantity.Name = "colFinishQuantity";
            this.colFinishQuantity.Visible = true;
            this.colFinishQuantity.VisibleIndex = 5;
            this.colFinishQuantity.Width = 125;
            // 
            // colUnitName
            // 
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MaxWidth = 100;
            this.colUnitName.MinWidth = 50;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 6;
            this.colUnitName.Width = 100;
            // 
            // colRate
            // 
            this.colRate.DisplayFormat.FormatString = "n2";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 125;
            this.colRate.MinWidth = 75;
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 7;
            this.colRate.Width = 125;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.MaxWidth = 100;
            this.colRecordState.MinWidth = 60;
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 8;
            this.colRecordState.Width = 60;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnProductFormula);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Process";
            // 
            // btnProductFormula
            // 
            this.btnProductFormula.Caption = "Formula";
            this.btnProductFormula.Id = 50;
            this.btnProductFormula.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProductFormula.ImageOptions.SvgImage")));
            this.btnProductFormula.Name = "btnProductFormula";
            this.btnProductFormula.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnProductFormula.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductFormula_ItemClick);
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 125;
            this.colAmount.MinWidth = 75;
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")});
            this.colAmount.Width = 100;
            // 
            // colNarration
            // 
            this.colNarration.FieldName = "Narration";
            this.colNarration.MaxWidth = 500;
            this.colNarration.MinWidth = 100;
            this.colNarration.Name = "colNarration";
            this.colNarration.Width = 200;
            // 
            // frmProcessDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 630);
            this.Controls.Add(this.gridControlProcess);
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmProcessDashboard.IconOptions.Icon")));
            this.Name = "frmProcessDashboard";
            this.Text = "Process";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gridControlProcess, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProcess;
        private System.Windows.Forms.BindingSource processDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
        private DevExpress.XtraBars.BarButtonItem btnProductFormula;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
    }
}