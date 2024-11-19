namespace Alit.Marker.WinForm.Account.Transactions.Bank
{
    partial class frmBankReconciliation
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankReconciliation));
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookupEditBookAccount1 = new Alit.Marker.WinForm.Account.Account.LookupEditBookAccount();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkIncludeReconciled = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcBankReconciliation = new DevExpress.XtraGrid.GridControl();
            this.bankReconciliationDashboardViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvBankReconciliation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReconciled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colValueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colVoucherDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).BeginInit();
            this.lcTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEditBookAccount1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeReconciled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBankReconciliation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankReconciliationDashboardViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBankReconciliation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnUpdate});
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ribbonControl1.MaxItemId = 51;
            // 
            // 
            // 
            this.ribbonControl1.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl1.SearchEditItem.EditWidth = 150;
            this.ribbonControl1.SearchEditItem.Id = -5000;
            this.ribbonControl1.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1147, 166);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 616);
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1147, 24);
            // 
            // RootTitle
            // 
            this.RootTitle.Size = new System.Drawing.Size(1147, 61);
            // 
            // lcTitle
            // 
            this.lcTitle.Controls.Add(this.chkIncludeReconciled);
            this.lcTitle.Controls.Add(this.lookupEditBookAccount1);
            this.lcTitle.Controls.Add(this.deDateTo);
            this.lcTitle.Controls.Add(this.deDateFrom);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcTitle.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcTitle.OptionsView.HighlightFocusedItem = true;
            this.lcTitle.Size = new System.Drawing.Size(1147, 61);
            // 
            // lcgDefaultFilterGroupBox
            // 
            this.lcgDefaultFilterGroupBox.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.lcgDefaultFilterGroupBox.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirectionGroup.DownThenAcross;
            this.lcgDefaultFilterGroupBox.Size = new System.Drawing.Size(594, 61);
            this.lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AppearanceItemCaption.FontSizeDelta = 15;
            this.lblFormCaption.AppearanceItemCaption.Options.UseFont = true;
            this.lblFormCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(594, 0);
            this.lblFormCaption.Size = new System.Drawing.Size(553, 61);
            this.lblFormCaption.Text = "Bank Reconciliation";
            this.lblFormCaption.TextSize = new System.Drawing.Size(281, 38);
            // 
            // rpgCRUD
            // 
            this.rpgCRUD.ItemLinks.Add(this.btnUpdate);
            // 
            // btnDocumentExportTo
            // 
            this.btnDocumentExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDocumentExportTo.ImageOptions.SvgImage")));
            // 
            // btnDashboardExportTo
            // 
            this.btnDashboardExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDashboardExportTo.ImageOptions.SvgImage")));
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(93, 4);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateFrom.MenuManager = this.ribbonControl1;
            this.deDateFrom.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Size = new System.Drawing.Size(123, 22);
            this.deDateFrom.StyleController = this.lcTitle;
            this.deDateFrom.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(193, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(102, 30);
            this.deDateTo.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateTo.MenuManager = this.ribbonControl1;
            this.deDateTo.MinimumSize = new System.Drawing.Size(90, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Size = new System.Drawing.Size(114, 22);
            this.deDateTo.StyleController = this.lcTitle;
            this.deDateTo.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(193, 30);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 25);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // lookupEditBookAccount1
            // 
            this.lookupEditBookAccount1.AccountGroupType = new Alit.Marker.Model.Account.Group.eAccountGroupType[] {
        Alit.Marker.Model.Account.Group.eAccountGroupType.BankAccounts};
            this.lookupEditBookAccount1.EnterMoveNextControl = true;
            this.lookupEditBookAccount1.Location = new System.Drawing.Point(273, 4);
            this.lookupEditBookAccount1.MaximumSize = new System.Drawing.Size(500, 0);
            this.lookupEditBookAccount1.MenuManager = this.ribbonControl1;
            this.lookupEditBookAccount1.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupEditBookAccount1.Name = "lookupEditBookAccount1";
            this.lookupEditBookAccount1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lookupEditBookAccount1.Properties.DisplayMember = "AccountName";
            this.lookupEditBookAccount1.Properties.NullText = "Select";
            this.lookupEditBookAccount1.Properties.ValueMember = "AccountID";
            this.lookupEditBookAccount1.Size = new System.Drawing.Size(316, 22);
            this.lookupEditBookAccount1.StyleController = this.lcTitle;
            this.lookupEditBookAccount1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookupEditBookAccount1;
            this.layoutControlItem3.Location = new System.Drawing.Point(193, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(373, 26);
            this.layoutControlItem3.Text = "Account";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // chkIncludeReconciled
            // 
            this.chkIncludeReconciled.Location = new System.Drawing.Point(220, 30);
            this.chkIncludeReconciled.MenuManager = this.ribbonControl1;
            this.chkIncludeReconciled.Name = "chkIncludeReconciled";
            this.chkIncludeReconciled.Properties.Caption = "Include Reconciled Transactions";
            this.chkIncludeReconciled.Size = new System.Drawing.Size(219, 20);
            this.chkIncludeReconciled.StyleController = this.lcTitle;
            this.chkIncludeReconciled.TabIndex = 7;
            this.chkIncludeReconciled.CheckedChanged += new System.EventHandler(this.chkIncludeReconciled_CheckedChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkIncludeReconciled;
            this.layoutControlItem4.Location = new System.Drawing.Point(193, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(223, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // gcBankReconciliation
            // 
            this.gcBankReconciliation.DataSource = this.bankReconciliationDashboardViewModelBindingSource;
            this.gcBankReconciliation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBankReconciliation.Location = new System.Drawing.Point(0, 227);
            this.gcBankReconciliation.MainView = this.gvBankReconciliation;
            this.gcBankReconciliation.MenuManager = this.ribbonControl1;
            this.gcBankReconciliation.Name = "gcBankReconciliation";
            this.gcBankReconciliation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit1});
            this.gcBankReconciliation.Size = new System.Drawing.Size(1147, 389);
            this.gcBankReconciliation.TabIndex = 11;
            this.gcBankReconciliation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBankReconciliation});
            // 
            // bankReconciliationDashboardViewModelBindingSource
            // 
            this.bankReconciliationDashboardViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Account.Transactions.Bank.BankReconciliationDashboardViewModel);
            // 
            // gvBankReconciliation
            // 
            this.gvBankReconciliation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReconciled,
            this.colValueDate,
            this.colVoucherDate,
            this.colVoucherNo,
            this.colVoucherTypeName,
            this.colNarration,
            this.colDebitAmount,
            this.colCreditAmount,
            this.colBalance});
            this.gvBankReconciliation.GridControl = this.gcBankReconciliation;
            this.gvBankReconciliation.Name = "gvBankReconciliation";
            this.gvBankReconciliation.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvBankReconciliation.OptionsView.ShowFooter = true;
            this.gvBankReconciliation.OptionsView.ShowGroupPanel = false;
            this.gvBankReconciliation.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gvBankReconciliation_CustomSummaryCalculate);
            this.gvBankReconciliation.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvBankReconciliation_CellValueChanged);
            // 
            // colReconciled
            // 
            this.colReconciled.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colReconciled.FieldName = "Reconciled";
            this.colReconciled.MaxWidth = 75;
            this.colReconciled.MinWidth = 75;
            this.colReconciled.Name = "colReconciled";
            this.colReconciled.Visible = true;
            this.colReconciled.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            // 
            // colValueDate
            // 
            this.colValueDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colValueDate.FieldName = "ValueDate";
            this.colValueDate.MaxWidth = 125;
            this.colValueDate.MinWidth = 90;
            this.colValueDate.Name = "colValueDate";
            this.colValueDate.Visible = true;
            this.colValueDate.VisibleIndex = 1;
            this.colValueDate.Width = 125;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // colVoucherDate
            // 
            this.colVoucherDate.FieldName = "VoucherDate";
            this.colVoucherDate.MaxWidth = 125;
            this.colVoucherDate.MinWidth = 90;
            this.colVoucherDate.Name = "colVoucherDate";
            this.colVoucherDate.OptionsColumn.AllowEdit = false;
            this.colVoucherDate.OptionsColumn.TabStop = false;
            this.colVoucherDate.Visible = true;
            this.colVoucherDate.VisibleIndex = 2;
            this.colVoucherDate.Width = 125;
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.FieldName = "VoucherNo";
            this.colVoucherNo.MaxWidth = 90;
            this.colVoucherNo.MinWidth = 85;
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.OptionsColumn.AllowEdit = false;
            this.colVoucherNo.OptionsColumn.TabStop = false;
            this.colVoucherNo.Visible = true;
            this.colVoucherNo.VisibleIndex = 3;
            this.colVoucherNo.Width = 90;
            // 
            // colVoucherTypeName
            // 
            this.colVoucherTypeName.FieldName = "VoucherTypeName";
            this.colVoucherTypeName.MaxWidth = 500;
            this.colVoucherTypeName.MinWidth = 100;
            this.colVoucherTypeName.Name = "colVoucherTypeName";
            this.colVoucherTypeName.OptionsColumn.AllowEdit = false;
            this.colVoucherTypeName.OptionsColumn.TabStop = false;
            this.colVoucherTypeName.Visible = true;
            this.colVoucherTypeName.VisibleIndex = 4;
            this.colVoucherTypeName.Width = 148;
            // 
            // colNarration
            // 
            this.colNarration.FieldName = "Narration";
            this.colNarration.MaxWidth = 1000;
            this.colNarration.MinWidth = 100;
            this.colNarration.Name = "colNarration";
            this.colNarration.OptionsColumn.AllowEdit = false;
            this.colNarration.OptionsColumn.TabStop = false;
            this.colNarration.Visible = true;
            this.colNarration.VisibleIndex = 5;
            this.colNarration.Width = 148;
            // 
            // colDebitAmount
            // 
            this.colDebitAmount.DisplayFormat.FormatString = "{0:#,#0.00;#,#0.00; }";
            this.colDebitAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebitAmount.FieldName = "DebitAmount";
            this.colDebitAmount.MaxWidth = 150;
            this.colDebitAmount.MinWidth = 70;
            this.colDebitAmount.Name = "colDebitAmount";
            this.colDebitAmount.OptionsColumn.AllowEdit = false;
            this.colDebitAmount.OptionsColumn.TabStop = false;
            this.colDebitAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebitAmount", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colDebitAmount.Visible = true;
            this.colDebitAmount.VisibleIndex = 6;
            this.colDebitAmount.Width = 111;
            // 
            // colCreditAmount
            // 
            this.colCreditAmount.DisplayFormat.FormatString = "{0:#,#0.00;#,#0.00; }";
            this.colCreditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCreditAmount.FieldName = "CreditAmount";
            this.colCreditAmount.MaxWidth = 150;
            this.colCreditAmount.MinWidth = 70;
            this.colCreditAmount.Name = "colCreditAmount";
            this.colCreditAmount.OptionsColumn.AllowEdit = false;
            this.colCreditAmount.OptionsColumn.TabStop = false;
            this.colCreditAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditAmount", "{0:#,##0.00 DR;#,##0.00 CR;0.00 }")});
            this.colCreditAmount.Visible = true;
            this.colCreditAmount.VisibleIndex = 7;
            this.colCreditAmount.Width = 111;
            // 
            // colBalance
            // 
            this.colBalance.DisplayFormat.FormatString = "{0:#,##0.00 DR;#,##0.00 CR;0.00 }";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBalance.FieldName = "Balance";
            this.colBalance.MaxWidth = 200;
            this.colBalance.MinWidth = 70;
            this.colBalance.Name = "colBalance";
            this.colBalance.OptionsColumn.AllowEdit = false;
            this.colBalance.OptionsColumn.TabStop = false;
            this.colBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "Book Balance : {0:#,#0.00 DR;#,#0.00 CR;0.00   }", "BookBalance"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "Bank Balance : {0:#,#0.00 DR;#,#0.00 CR;0.00   }", "BankBalance"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "Diff. : {0:#,#0.00 DR;#,#0.00 CR;0.00   }", "Difference")});
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 8;
            this.colBalance.Width = 200;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(416, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(150, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Update";
            this.btnUpdate.Id = 50;
            this.btnUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdate.ImageOptions.SvgImage")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // frmBankReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 640);
            this.Controls.Add(this.gcBankReconciliation);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmBankReconciliation.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmBankReconciliation";
            this.Text = "Bank Reconciliation";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.lcTitle, 0);
            this.Controls.SetChildIndex(this.gcBankReconciliation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTitle)).EndInit();
            this.lcTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgDefaultFilterGroupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEditBookAccount1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeReconciled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBankReconciliation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankReconciliationDashboardViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBankReconciliation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIncludeReconciled;
        private Account.LookupEditBookAccount lookupEditBookAccount1;
        private WinformControls.DateEdit deDateTo;
        private WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gcBankReconciliation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBankReconciliation;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource bankReconciliationDashboardViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colReconciled;
        private DevExpress.XtraGrid.Columns.GridColumn colValueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
    }
}