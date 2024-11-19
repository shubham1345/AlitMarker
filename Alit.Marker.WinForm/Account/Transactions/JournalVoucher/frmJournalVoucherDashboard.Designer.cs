namespace Alit.Marker.WinForm.Account.Transactions.JournalVoucher
{
    partial class frmJournalVoucherDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalVoucherDashboard));
            this.gcJournalVoucher = new DevExpress.XtraGrid.GridControl();
            this.gvJournalVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.journalVoucherDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colJournalVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJournalVoucherDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJournalVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJournalVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalVoucherDashboardViewModelBindingSource)).BeginInit();
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
            this.lblFormCaption.Text = "Journal Voucher";
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
            // gcJournalVoucher
            // 
            this.gcJournalVoucher.DataSource = this.journalVoucherDashboardViewModelBindingSource;
            this.gcJournalVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJournalVoucher.Location = new System.Drawing.Point(0, 214);
            this.gcJournalVoucher.MainView = this.gvJournalVoucher;
            this.gcJournalVoucher.MenuManager = this.ribbonControl1;
            this.gcJournalVoucher.Name = "gcJournalVoucher";
            this.gcJournalVoucher.Size = new System.Drawing.Size(980, 191);
            this.gcJournalVoucher.TabIndex = 11;
            this.gcJournalVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvJournalVoucher});
            // 
            // gvJournalVoucher
            // 
            this.gvJournalVoucher.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJournalVoucherNo,
            this.colJournalVoucherDate,
            this.colAmount,
            this.colNarration,
            this.colRecordState});
            this.gvJournalVoucher.GridControl = this.gcJournalVoucher;
            this.gvJournalVoucher.Name = "gvJournalVoucher";
            // 
            // journalVoucherDashboardViewModelBindingSource
            // 
            this.journalVoucherDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Account.Transactions.JournalVoucher.JournalVoucherDashboardViewModel);
            // 
            // colJournalVoucherNo
            // 
            this.colJournalVoucherNo.DisplayFormat.FormatString = "n0";
            this.colJournalVoucherNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colJournalVoucherNo.FieldName = "JournalVoucherNo";
            this.colJournalVoucherNo.MaxWidth = 125;
            this.colJournalVoucherNo.MinWidth = 125;
            this.colJournalVoucherNo.Name = "colJournalVoucherNo";
            this.colJournalVoucherNo.Visible = true;
            this.colJournalVoucherNo.VisibleIndex = 0;
            this.colJournalVoucherNo.Width = 125;
            // 
            // colJournalVoucherDate
            // 
            this.colJournalVoucherDate.FieldName = "JournalVoucherDate";
            this.colJournalVoucherDate.MaxWidth = 150;
            this.colJournalVoucherDate.MinWidth = 135;
            this.colJournalVoucherDate.Name = "colJournalVoucherDate";
            this.colJournalVoucherDate.Visible = true;
            this.colJournalVoucherDate.VisibleIndex = 1;
            this.colJournalVoucherDate.Width = 135;
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
            // frmJournalVoucherDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 428);
            this.Controls.Add(this.gcJournalVoucher);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmJournalVoucherDashboard.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmJournalVoucherDashboard";
            this.Text = "Journal Voucher";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gcJournalVoucher, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJournalVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJournalVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalVoucherDashboardViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcJournalVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJournalVoucher;
        private System.Windows.Forms.BindingSource journalVoucherDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colJournalVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn colJournalVoucherDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordState;
    }
}