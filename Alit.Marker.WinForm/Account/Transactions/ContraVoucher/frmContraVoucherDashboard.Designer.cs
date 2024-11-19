namespace Alit.Marker.WinForm.Account.Transactions.ContraVoucher
{
    partial class frmContraVoucherDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContraVoucherDashboard));
            this.gcContraVoucher = new DevExpress.XtraGrid.GridControl();
            this.gvContraVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contraVoucherDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colContraVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContraVoucherDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcContraVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContraVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contraVoucherDashboardViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(980, 159);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 405);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(980, 23);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(980, 55);
            // 
            // lcTitle
            // 
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(980, 55);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(210, 55);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(210, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(770, 55);
            this.lblFormCaption.Text = "Contra Voucher";
            this.lblFormCaption.TextSize = new System.Drawing.Size(235, 38);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // gcContraVoucher
            // 
            this.gcContraVoucher.DataSource = this.contraVoucherDashboardViewModelBindingSource;
            this.gcContraVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcContraVoucher.Location = new System.Drawing.Point(0, 214);
            this.gcContraVoucher.MainView = this.gvContraVoucher;
            this.gcContraVoucher.MenuManager = this.ribbonControl1;
            this.gcContraVoucher.Name = "gcContraVoucher";
            this.gcContraVoucher.Size = new System.Drawing.Size(980, 191);
            this.gcContraVoucher.TabIndex = 11;
            this.gcContraVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvContraVoucher});
            // 
            // gvContraVoucher
            // 
            this.gvContraVoucher.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContraVoucherNo,
            this.colContraVoucherDate,
            this.colAmount,
            this.colNarration,
            this.colRecordState});
            this.gvContraVoucher.GridControl = this.gcContraVoucher;
            this.gvContraVoucher.Name = "gvContraVoucher";
            // 
            // contraVoucherDashboardViewModelBindingSource
            // 
            this.contraVoucherDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Account.Transactions.ContraVoucher.ContraVoucherDashboardViewModel);
            // 
            // colContraVoucherNo
            // 
            this.colContraVoucherNo.DisplayFormat.FormatString = "n0";
            this.colContraVoucherNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colContraVoucherNo.FieldName = "ContraVoucherNo";
            this.colContraVoucherNo.MaxWidth = 125;
            this.colContraVoucherNo.MinWidth = 125;
            this.colContraVoucherNo.Name = "colContraVoucherNo";
            this.colContraVoucherNo.Visible = true;
            this.colContraVoucherNo.VisibleIndex = 0;
            this.colContraVoucherNo.Width = 125;
            // 
            // colContraVoucherDate
            // 
            this.colContraVoucherDate.FieldName = "ContraVoucherDate";
            this.colContraVoucherDate.MaxWidth = 150;
            this.colContraVoucherDate.MinWidth = 135;
            this.colContraVoucherDate.Name = "colContraVoucherDate";
            this.colContraVoucherDate.Visible = true;
            this.colContraVoucherDate.VisibleIndex = 1;
            this.colContraVoucherDate.Width = 135;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 150;
            this.colAmount.MinWidth = 75;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            this.colAmount.Width = 150;
            // 
            // colNarration
            // 
            this.colNarration.FieldName = "Narration";
            this.colNarration.MaxWidth = 1000;
            this.colNarration.MinWidth = 100;
            this.colNarration.Name = "colNarration";
            this.colNarration.Visible = true;
            this.colNarration.VisibleIndex = 3;
            this.colNarration.Width = 500;
            // 
            // colRecordState
            // 
            this.colRecordState.FieldName = "RecordState";
            this.colRecordState.Name = "colRecordState";
            this.colRecordState.Visible = true;
            this.colRecordState.VisibleIndex = 4;
            // 
            // frmContraVoucherDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 428);
            this.Controls.Add(this.gcContraVoucher);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmContraVoucherDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmContraVoucherDashboard";
            this.Text = "Contra Voucher";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gcContraVoucher, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcContraVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContraVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contraVoucherDashboardViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcContraVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContraVoucher;
        private System.Windows.Forms.BindingSource contraVoucherDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colContraVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn colContraVoucherDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}