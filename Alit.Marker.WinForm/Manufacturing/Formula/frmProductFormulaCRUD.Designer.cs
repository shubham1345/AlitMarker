namespace Alit.Marker.WinForm.Manufacturing.Formula
{
    partial class frmProductFormulaCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductFormulaCRUD));
            this.txtRemark = new Alit.WinformControls.TextEdit();
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.gcRawMaterial = new DevExpress.XtraGrid.GridControl();
            this.productFormulaDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvRawMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemoveRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemoveRow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.deWEDate = new Alit.WinformControls.DateEdit();
            this.txtFinishQuantity = new Alit.WinformControls.TextEdit();
            this.lookupProduct = new Alit.WinformControls.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRawMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productFormulaDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRawMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetExitFocus
            // 
            this.btnSetExitFocus.Location = new System.Drawing.Point(129, 349);
            this.btnSetExitFocus.Margin = new System.Windows.Forms.Padding(3);
            this.btnSetExitFocus.Size = new System.Drawing.Size(87, 29);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3);
            this.panelContent.Size = new System.Drawing.Size(788, 561);
            // 
            // btnSetSaveFocus
            // 
            this.btnSetSaveFocus.Location = new System.Drawing.Point(35, 349);
            this.btnSetSaveFocus.Margin = new System.Windows.Forms.Padding(3);
            this.btnSetSaveFocus.Size = new System.Drawing.Size(87, 29);
            // 
            // txtRemark
            // 
            this.txtRemark.EnterMoveNextControl = true;
            this.txtRemark.Location = new System.Drawing.Point(128, 64);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 100;
            this.txtRemark.Size = new System.Drawing.Size(634, 22);
            this.txtRemark.StyleController = this.myLayoutControl1;
            this.txtRemark.TabIndex = 9;
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gcRawMaterial);
            this.myLayoutControl1.Controls.Add(this.txtRemark);
            this.myLayoutControl1.Controls.Add(this.deWEDate);
            this.myLayoutControl1.Controls.Add(this.txtFinishQuantity);
            this.myLayoutControl1.Controls.Add(this.lookupProduct);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(784, 557);
            this.myLayoutControl1.TabIndex = 10;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gcRawMaterial
            // 
            this.gcRawMaterial.DataSource = this.productFormulaDetailViewModelBindingSource;
            this.gcRawMaterial.Location = new System.Drawing.Point(12, 90);
            this.gcRawMaterial.MainView = this.gvRawMaterial;
            this.gcRawMaterial.MinimumSize = new System.Drawing.Size(100, 100);
            this.gcRawMaterial.Name = "gcRawMaterial";
            this.gcRawMaterial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditProduct,
            this.repositoryItemTxtAmt,
            this.repositoryItemButtonEditRemoveRow});
            this.gcRawMaterial.Size = new System.Drawing.Size(750, 455);
            this.gcRawMaterial.TabIndex = 8;
            this.gcRawMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRawMaterial});
            // 
            // productFormulaDetailViewModelBindingSource
            // 
            this.productFormulaDetailViewModelBindingSource.DataSource = typeof(Alit.Marker.Model.Manufacturing.Formula.ProductFormulaDetailViewModel);
            // 
            // gvRawMaterial
            // 
            this.gvRawMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colQuantity,
            this.colRate,
            this.colAmt,
            this.gcRemoveRow});
            this.gvRawMaterial.DetailHeight = 431;
            this.gvRawMaterial.FixedLineWidth = 3;
            this.gvRawMaterial.GridControl = this.gcRawMaterial;
            this.gvRawMaterial.Name = "gvRawMaterial";
            this.gvRawMaterial.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvRawMaterial.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvRawMaterial.OptionsNavigation.UseTabKey = false;
            this.gvRawMaterial.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvRawMaterial.OptionsView.ShowGroupPanel = false;
            // 
            // colProductID
            // 
            this.colProductID.ColumnEdit = this.repositoryItemLookUpEditProduct;
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 23;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            this.colProductID.Width = 541;
            // 
            // repositoryItemLookUpEditProduct
            // 
            this.repositoryItemLookUpEditProduct.AutoHeight = false;
            this.repositoryItemLookUpEditProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditProduct.Name = "repositoryItemLookUpEditProduct";
            this.repositoryItemLookUpEditProduct.NullText = "(Select Product)";
            // 
            // colQuantity
            // 
            this.colQuantity.ColumnEdit = this.repositoryItemTxtAmt;
            this.colQuantity.DisplayFormat.FormatString = "n2";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 117;
            this.colQuantity.MinWidth = 58;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            this.colQuantity.Width = 117;
            // 
            // repositoryItemTxtAmt
            // 
            this.repositoryItemTxtAmt.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtAmt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtAmt.AutoHeight = false;
            this.repositoryItemTxtAmt.Mask.EditMask = "n2";
            this.repositoryItemTxtAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtAmt.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtAmt.Name = "repositoryItemTxtAmt";
            // 
            // colRate
            // 
            this.colRate.ColumnEdit = this.repositoryItemTxtAmt;
            this.colRate.DisplayFormat.FormatString = "n2";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 145;
            this.colRate.MinWidth = 87;
            this.colRate.Name = "colRate";
            this.colRate.Width = 87;
            // 
            // colAmt
            // 
            this.colAmt.ColumnEdit = this.repositoryItemTxtAmt;
            this.colAmt.DisplayFormat.FormatString = "n2";
            this.colAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmt.FieldName = "Amt";
            this.colAmt.MaxWidth = 145;
            this.colAmt.MinWidth = 87;
            this.colAmt.Name = "colAmt";
            this.colAmt.OptionsColumn.ReadOnly = true;
            this.colAmt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amt", "{0:n2}")});
            this.colAmt.Width = 87;
            // 
            // gcRemoveRow
            // 
            this.gcRemoveRow.Caption = " ";
            this.gcRemoveRow.ColumnEdit = this.repositoryItemButtonEditRemoveRow;
            this.gcRemoveRow.MaxWidth = 20;
            this.gcRemoveRow.Name = "gcRemoveRow";
            this.gcRemoveRow.OptionsColumn.TabStop = false;
            this.gcRemoveRow.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gcRemoveRow.Visible = true;
            this.gcRemoveRow.VisibleIndex = 2;
            this.gcRemoveRow.Width = 20;
            // 
            // repositoryItemButtonEditRemoveRow
            // 
            this.repositoryItemButtonEditRemoveRow.AutoHeight = false;
            this.repositoryItemButtonEditRemoveRow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemoveRow.Name = "repositoryItemButtonEditRemoveRow";
            this.repositoryItemButtonEditRemoveRow.Click += new System.EventHandler(this.repositoryItemButtonEditRemoveRow_Click);
            // 
            // deWEDate
            // 
            this.deWEDate.EditValue = null;
            this.deWEDate.EnterMoveNextControl = true;
            this.deWEDate.Location = new System.Drawing.Point(423, 38);
            this.deWEDate.MaximumSize = new System.Drawing.Size(125, 0);
            this.deWEDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.deWEDate.Name = "deWEDate";
            this.deWEDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWEDate.Size = new System.Drawing.Size(125, 22);
            this.deWEDate.StyleController = this.myLayoutControl1;
            this.deWEDate.TabIndex = 6;
            // 
            // txtFinishQuantity
            // 
            this.txtFinishQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFinishQuantity.EnterMoveNextControl = true;
            this.txtFinishQuantity.Location = new System.Drawing.Point(128, 38);
            this.txtFinishQuantity.MaximumSize = new System.Drawing.Size(175, 0);
            this.txtFinishQuantity.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtFinishQuantity.Name = "txtFinishQuantity";
            this.txtFinishQuantity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtFinishQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtFinishQuantity.Properties.Mask.EditMask = "n2";
            this.txtFinishQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFinishQuantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFinishQuantity.Size = new System.Drawing.Size(175, 22);
            this.txtFinishQuantity.StyleController = this.myLayoutControl1;
            this.txtFinishQuantity.TabIndex = 5;
            this.txtFinishQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtFinishQuantity_Validating);
            // 
            // lookupProduct
            // 
            this.lookupProduct.EnterMoveNextControl = true;
            this.lookupProduct.Location = new System.Drawing.Point(128, 12);
            this.lookupProduct.MaximumSize = new System.Drawing.Size(583, 0);
            this.lookupProduct.Name = "lookupProduct";
            this.lookupProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupProduct.Properties.NullText = "Select";
            this.lookupProduct.Size = new System.Drawing.Size(583, 22);
            this.lookupProduct.StyleController = this.myLayoutControl1;
            this.lookupProduct.TabIndex = 4;
            this.lookupProduct.EditValueChanged += new System.EventHandler(this.lookupProduct_EditValueChanged);
            this.lookupProduct.Validating += new System.ComponentModel.CancelEventHandler(this.lookupProduct_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.emptySpaceItem3,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(784, 557);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookupProduct;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(703, 26);
            this.layoutControlItem1.Text = "Finish Product";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(113, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFinishQuantity;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(295, 26);
            this.layoutControlItem2.Text = "Finish Quantity";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(113, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(754, 26);
            this.layoutControlItem4.Text = "Remark";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(113, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcRawMaterial;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(754, 459);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(540, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(214, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deWEDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(295, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(245, 26);
            this.layoutControlItem3.Text = "Effective From Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(113, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(754, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 537);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(703, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(51, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmProductFormulaCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 595);
            this.FirstControl = this.myLayoutControl1;
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmProductFormulaCRUD.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmProductFormulaCRUD";
            this.Text = "Product Formula";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRawMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productFormulaDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRawMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcRawMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRawMaterial;
        private WinformControls.DateEdit deWEDate;
        private WinformControls.TextEdit txtFinishQuantity;
        private WinformControls.LookUpEdit lookupProduct;
        private System.Windows.Forms.BindingSource productFormulaDetailViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmt;
        private WinformControls.TextEdit txtRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemoveRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemoveRow;
        private WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}