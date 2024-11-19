namespace Alit.Marker.WinForm.Account.VoucherType
{
    partial class frmVoucherTypeCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherTypeCRUD));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.cmbPrimaryVoucherType = new Alit.WinformControls.ComboBoxEdit();
            this.txtVoucherTypeName = new Alit.WinformControls.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrimaryVoucherType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetExitFocus
            // 
            this.btnSetExitFocus.Location = new System.Drawing.Point(166, 415);
            this.btnSetExitFocus.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetExitFocus.Size = new System.Drawing.Size(112, 34);
            // 
            // btnSetSaveFocus
            // 
            this.btnSetSaveFocus.Location = new System.Drawing.Point(45, 415);
            this.btnSetSaveFocus.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetSaveFocus.Size = new System.Drawing.Size(112, 34);
            // 
            // panelBase1
            // 
            this.panelBase1.Margin = new System.Windows.Forms.Padding(4);
            this.panelBase1.Size = new System.Drawing.Size(670, 152);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Size = new System.Drawing.Size(670, 92);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.cmbPrimaryVoucherType);
            this.myLayoutControl1.Controls.Add(this.txtVoucherTypeName);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(666, 88);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // cmbPrimaryVoucherType
            // 
            this.cmbPrimaryVoucherType.EnterMoveNextControl = true;
            this.cmbPrimaryVoucherType.Location = new System.Drawing.Point(144, 38);
            this.cmbPrimaryVoucherType.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbPrimaryVoucherType.MenuManager = this.barManager1;
            this.cmbPrimaryVoucherType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbPrimaryVoucherType.Name = "cmbPrimaryVoucherType";
            this.cmbPrimaryVoucherType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrimaryVoucherType.Properties.Items.AddRange(new object[] {
            "None",
            "Journal Voucher",
            "Contra Voucher",
            "Sale",
            "Sale Return",
            "Purchase",
            "Purchase Return",
            "Receipt",
            "Payment"});
            this.cmbPrimaryVoucherType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPrimaryVoucherType.Size = new System.Drawing.Size(150, 22);
            this.cmbPrimaryVoucherType.StyleController = this.myLayoutControl1;
            this.cmbPrimaryVoucherType.TabIndex = 5;
            // 
            // txtVoucherTypeName
            // 
            this.txtVoucherTypeName.EnterMoveNextControl = true;
            this.txtVoucherTypeName.Location = new System.Drawing.Point(144, 12);
            this.txtVoucherTypeName.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtVoucherTypeName.MenuManager = this.barManager1;
            this.txtVoucherTypeName.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtVoucherTypeName.Name = "txtVoucherTypeName";
            this.txtVoucherTypeName.Properties.MaxLength = 50;
            this.txtVoucherTypeName.Size = new System.Drawing.Size(500, 22);
            this.txtVoucherTypeName.StyleController = this.myLayoutControl1;
            this.txtVoucherTypeName.TabIndex = 4;
            this.txtVoucherTypeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtVoucherTypeName_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(666, 88);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtVoucherTypeName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(636, 26);
            this.layoutControlItem1.Text = "Voucher Type Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(129, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(646, 16);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbPrimaryVoucherType;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(286, 26);
            this.layoutControlItem2.Text = "Primary Voucher Type";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(129, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(636, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(286, 26);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(360, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmVoucherTypeCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 152);
            this.FirstControl = this.myLayoutControl1;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmVoucherTypeCRUD.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVoucherTypeCRUD";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Voucher Type";
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
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrimaryVoucherType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControls.myLayoutControl myLayoutControl1;
        private WinformControls.ComboBoxEdit cmbPrimaryVoucherType;
        private WinformControls.TextEdit txtVoucherTypeName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}