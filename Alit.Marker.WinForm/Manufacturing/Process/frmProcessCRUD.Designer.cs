namespace Alit.Marker.WinForm.Manufacturing.Process
{
    partial class frmProcessCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessCRUD));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.txtFinishProductRate = new Alit.WinformControls.TextEdit();
            this.txtNarration = new Alit.WinformControls.TextEdit();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.processDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditRawProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemoveRow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txtFinishQuantity = new Alit.WinformControls.TextEdit();
            this.lookupProduct = new Alit.WinformControls.LookUpEdit();
            this.txtProcessNo = new Alit.WinformControls.TextEdit();
            this.deProcessDate = new Alit.WinformControls.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcProduct = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishProductRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditRawProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deProcessDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deProcessDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.Size = new System.Drawing.Size(884, 460);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Size = new System.Drawing.Size(884, 400);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtFinishProductRate);
            this.myLayoutControl1.Controls.Add(this.txtNarration);
            this.myLayoutControl1.Controls.Add(this.gcDetail);
            this.myLayoutControl1.Controls.Add(this.txtFinishQuantity);
            this.myLayoutControl1.Controls.Add(this.lookupProduct);
            this.myLayoutControl1.Controls.Add(this.txtProcessNo);
            this.myLayoutControl1.Controls.Add(this.deProcessDate);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(880, 396);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtFinishProductRate
            // 
            this.txtFinishProductRate.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFinishProductRate.EnterMoveNextControl = true;
            this.txtFinishProductRate.Location = new System.Drawing.Point(309, 64);
            this.txtFinishProductRate.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtFinishProductRate.MenuManager = this.barManager1;
            this.txtFinishProductRate.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtFinishProductRate.Name = "txtFinishProductRate";
            this.txtFinishProductRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtFinishProductRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtFinishProductRate.Properties.Mask.EditMask = "n2";
            this.txtFinishProductRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFinishProductRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFinishProductRate.Properties.ReadOnly = true;
            this.txtFinishProductRate.Size = new System.Drawing.Size(136, 22);
            this.txtFinishProductRate.StyleController = this.myLayoutControl1;
            this.txtFinishProductRate.TabIndex = 10;
            this.txtFinishProductRate.TabStop = false;
            // 
            // txtNarration
            // 
            this.txtNarration.EnterMoveNextControl = true;
            this.txtNarration.Location = new System.Drawing.Point(103, 90);
            this.txtNarration.MenuManager = this.barManager1;
            this.txtNarration.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Properties.MaxLength = 100;
            this.txtNarration.Size = new System.Drawing.Size(765, 22);
            this.txtNarration.StyleController = this.myLayoutControl1;
            this.txtNarration.TabIndex = 9;
            // 
            // gcDetail
            // 
            this.gcDetail.DataSource = this.processDetailViewModelBindingSource;
            this.gcDetail.Location = new System.Drawing.Point(12, 116);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.MenuManager = this.barManager1;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditRawProduct,
            this.repositoryItemTxtAmount,
            this.repositoryItemButtonEditRemoveRow});
            this.gcDetail.Size = new System.Drawing.Size(856, 268);
            this.gcDetail.TabIndex = 8;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // processDetailViewModelBindingSource
            // 
            this.processDetailViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Manufacturing.Process.ProcessDetailViewModel);
            this.processDetailViewModelBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.processDetailViewModelBindingSource_ListChanged);
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colQuantity,
            this.colRate,
            this.colAmt,
            this.colRemove});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDetail.OptionsNavigation.UseTabKey = false;
            this.gvDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvDetail.OptionsView.ShowFooter = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanged);
            this.gvDetail.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvDetail_RowUpdated);
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Raw Material";
            this.colProductID.ColumnEdit = this.repositoryItemLookUpEditRawProduct;
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MaxWidth = 500;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditRawProduct
            // 
            this.repositoryItemLookUpEditRawProduct.AutoHeight = false;
            this.repositoryItemLookUpEditRawProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditRawProduct.Name = "repositoryItemLookUpEditRawProduct";
            this.repositoryItemLookUpEditRawProduct.NullText = "(Select Product)";
            this.repositoryItemLookUpEditRawProduct.PopupWidth = 800;
            // 
            // colQuantity
            // 
            this.colQuantity.ColumnEdit = this.repositoryItemTxtAmount;
            this.colQuantity.DisplayFormat.FormatString = "n2";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 125;
            this.colQuantity.MinWidth = 75;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            // 
            // repositoryItemTxtAmount
            // 
            this.repositoryItemTxtAmount.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtAmount.AutoHeight = false;
            this.repositoryItemTxtAmount.Mask.EditMask = "n2";
            this.repositoryItemTxtAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtAmount.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtAmount.Name = "repositoryItemTxtAmount";
            // 
            // colRate
            // 
            this.colRate.ColumnEdit = this.repositoryItemTxtAmount;
            this.colRate.DisplayFormat.FormatString = "n2";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 125;
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 2;
            // 
            // colAmt
            // 
            this.colAmt.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colAmt.AppearanceCell.Options.UseBackColor = true;
            this.colAmt.DisplayFormat.FormatString = "n2";
            this.colAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmt.FieldName = "Amt";
            this.colAmt.MaxWidth = 125;
            this.colAmt.Name = "colAmt";
            this.colAmt.OptionsColumn.AllowEdit = false;
            this.colAmt.OptionsColumn.ReadOnly = true;
            this.colAmt.OptionsColumn.TabStop = false;
            this.colAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amt", "{0:n2}")});
            this.colAmt.Visible = true;
            this.colAmt.VisibleIndex = 3;
            // 
            // colRemove
            // 
            this.colRemove.Caption = " ";
            this.colRemove.ColumnEdit = this.repositoryItemButtonEditRemoveRow;
            this.colRemove.MaxWidth = 20;
            this.colRemove.Name = "colRemove";
            this.colRemove.OptionsColumn.TabStop = false;
            this.colRemove.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemove.Visible = true;
            this.colRemove.VisibleIndex = 4;
            this.colRemove.Width = 20;
            // 
            // repositoryItemButtonEditRemoveRow
            // 
            this.repositoryItemButtonEditRemoveRow.AutoHeight = false;
            this.repositoryItemButtonEditRemoveRow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemoveRow.Name = "repositoryItemButtonEditRemoveRow";
            this.repositoryItemButtonEditRemoveRow.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditRemoveRow_ButtonClick);
            // 
            // txtFinishQuantity
            // 
            this.txtFinishQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFinishQuantity.EnterMoveNextControl = true;
            this.txtFinishQuantity.Location = new System.Drawing.Point(103, 64);
            this.txtFinishQuantity.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtFinishQuantity.MenuManager = this.barManager1;
            this.txtFinishQuantity.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtFinishQuantity.Name = "txtFinishQuantity";
            this.txtFinishQuantity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtFinishQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtFinishQuantity.Properties.Mask.EditMask = "n2";
            this.txtFinishQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFinishQuantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFinishQuantity.Size = new System.Drawing.Size(135, 22);
            this.txtFinishQuantity.StyleController = this.myLayoutControl1;
            this.txtFinishQuantity.TabIndex = 7;
            this.txtFinishQuantity.EditValueChanged += new System.EventHandler(this.txtFinishQuantity_EditValueChanged);
            this.txtFinishQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtFinishQuantity_Validating);
            // 
            // lookupProduct
            // 
            this.lookupProduct.EnterMoveNextControl = true;
            this.lookupProduct.Location = new System.Drawing.Point(103, 38);
            this.lookupProduct.MaximumSize = new System.Drawing.Size(500, 0);
            this.lookupProduct.MenuManager = this.barManager1;
            this.lookupProduct.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupProduct.Name = "lookupProduct";
            this.lookupProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupProduct.Properties.NullText = "Select";
            this.lookupProduct.Properties.PopupWidth = 800;
            this.lookupProduct.Size = new System.Drawing.Size(463, 22);
            this.lookupProduct.StyleController = this.myLayoutControl1;
            this.lookupProduct.TabIndex = 6;
            this.lookupProduct.EditValueChanged += new System.EventHandler(this.lookupProduct_EditValueChanged);
            this.lookupProduct.Validating += new System.ComponentModel.CancelEventHandler(this.lookupProduct_Validating);
            // 
            // txtProcessNo
            // 
            this.txtProcessNo.EditValue = ((long)(0));
            this.txtProcessNo.EnterMoveNextControl = true;
            this.txtProcessNo.Location = new System.Drawing.Point(315, 12);
            this.txtProcessNo.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtProcessNo.MenuManager = this.barManager1;
            this.txtProcessNo.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtProcessNo.Name = "txtProcessNo";
            this.txtProcessNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProcessNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtProcessNo.Properties.ReadOnly = true;
            this.txtProcessNo.Size = new System.Drawing.Size(136, 22);
            this.txtProcessNo.StyleController = this.myLayoutControl1;
            this.txtProcessNo.TabIndex = 5;
            this.txtProcessNo.TabStop = false;
            this.txtProcessNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtProcessNo_Validating);
            // 
            // deProcessDate
            // 
            this.deProcessDate.EditValue = null;
            this.deProcessDate.EnterMoveNextControl = true;
            this.deProcessDate.Location = new System.Drawing.Point(103, 12);
            this.deProcessDate.MaximumSize = new System.Drawing.Size(150, 0);
            this.deProcessDate.MenuManager = this.barManager1;
            this.deProcessDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.deProcessDate.Name = "deProcessDate";
            this.deProcessDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deProcessDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deProcessDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deProcessDate.Size = new System.Drawing.Size(135, 22);
            this.deProcessDate.StyleController = this.myLayoutControl1;
            this.deProcessDate.TabIndex = 4;
            this.deProcessDate.Validating += new System.ComponentModel.CancelEventHandler(this.deProcessDate_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.lcProduct,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(880, 396);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deProcessDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 26);
            this.layoutControlItem1.Text = "Process Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtProcessNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(230, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(213, 26);
            this.layoutControlItem2.Text = "Process No";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // lcProduct
            // 
            this.lcProduct.Control = this.lookupProduct;
            this.lcProduct.Location = new System.Drawing.Point(0, 26);
            this.lcProduct.Name = "lcProduct";
            this.lcProduct.Size = new System.Drawing.Size(558, 26);
            this.lcProduct.Text = "Finish Product";
            this.lcProduct.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtFinishQuantity;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(230, 26);
            this.layoutControlItem4.Text = "Finish Quantity";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcDetail;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(860, 272);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtNarration;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(860, 26);
            this.layoutControlItem6.Text = "Narration";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(443, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(417, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(558, 26);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(302, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(437, 52);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(423, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtFinishProductRate;
            this.layoutControlItem3.Location = new System.Drawing.Point(230, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(207, 26);
            this.layoutControlItem3.Text = "Rate / Unit";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(62, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // frmProcessCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 460);
            this.FirstControl = this.myLayoutControl1;
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmProcessCRUD.IconOptions.Icon")));
            this.Name = "frmProcessCRUD";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Process";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).EndInit();
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishProductRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNarration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditRawProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deProcessDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deProcessDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControls.myLayoutControl myLayoutControl1;
        private WinformControls.TextEdit txtNarration;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private WinformControls.TextEdit txtFinishQuantity;
        private WinformControls.LookUpEdit lookupProduct;
        private WinformControls.TextEdit txtProcessNo;
        private WinformControls.DateEdit deProcessDate;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem lcProduct;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private System.Windows.Forms.BindingSource processDetailViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmt;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRawProduct;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemove;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemoveRow;
        private WinformControls.TextEdit txtFinishProductRate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}