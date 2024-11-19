namespace Alit.Marker.WinForm.Customer
{
    partial class frmCustomerOpeningBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerOpeningBalance));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.memoNarration = new Alit.WinformControls.MemoEdit();
            this.txtOpBalAmt = new Alit.WinformControls.TextEdit();
            this.txtCustomerName = new Alit.WinformControls.TextEdit();
            this.txtOpeningBalanceDate = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.customerOpeningBalanceEditListModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoNarration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpBalAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOpeningBalanceEditListModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.Size = new System.Drawing.Size(640, 278);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Size = new System.Drawing.Size(640, 218);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.memoNarration);
            this.layoutControl1.Controls.Add(this.txtOpBalAmt);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtOpeningBalanceDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(636, 214);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // memoNarration
            // 
            this.memoNarration.Location = new System.Drawing.Point(114, 90);
            this.memoNarration.MaximumSize = new System.Drawing.Size(500, 100);
            this.memoNarration.MenuManager = this.barManager1;
            this.memoNarration.MinimumSize = new System.Drawing.Size(100, 0);
            this.memoNarration.Name = "memoNarration";
            this.memoNarration.Properties.MaxLength = 500;
            this.memoNarration.Size = new System.Drawing.Size(500, 87);
            this.memoNarration.StyleController = this.layoutControl1;
            this.memoNarration.TabIndex = 7;
            this.memoNarration.TabStop = false;
            // 
            // txtOpBalAmt
            // 
            this.txtOpBalAmt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOpBalAmt.EnterMoveNextControl = true;
            this.txtOpBalAmt.Location = new System.Drawing.Point(114, 64);
            this.txtOpBalAmt.MaximumSize = new System.Drawing.Size(125, 0);
            this.txtOpBalAmt.MenuManager = this.barManager1;
            this.txtOpBalAmt.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtOpBalAmt.Name = "txtOpBalAmt";
            this.txtOpBalAmt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOpBalAmt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOpBalAmt.Properties.Mask.EditMask = "n2";
            this.txtOpBalAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOpBalAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtOpBalAmt.Properties.MaxLength = 12;
            this.txtOpBalAmt.Size = new System.Drawing.Size(125, 22);
            this.txtOpBalAmt.StyleController = this.layoutControl1;
            this.txtOpBalAmt.TabIndex = 6;
            this.txtOpBalAmt.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpBalAmt_Validating);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.EditValue = "";
            this.txtCustomerName.EnterMoveNextControl = true;
            this.txtCustomerName.Location = new System.Drawing.Point(114, 12);
            this.txtCustomerName.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtCustomerName.MenuManager = this.barManager1;
            this.txtCustomerName.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.NullText = "Select";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(500, 22);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 4;
            this.txtCustomerName.TabStop = false;
            // 
            // txtOpeningBalanceDate
            // 
            this.txtOpeningBalanceDate.EnterMoveNextControl = true;
            this.txtOpeningBalanceDate.Location = new System.Drawing.Point(114, 38);
            this.txtOpeningBalanceDate.MaximumSize = new System.Drawing.Size(125, 0);
            this.txtOpeningBalanceDate.MenuManager = this.barManager1;
            this.txtOpeningBalanceDate.MinimumSize = new System.Drawing.Size(90, 0);
            this.txtOpeningBalanceDate.Name = "txtOpeningBalanceDate";
            this.txtOpeningBalanceDate.Properties.DisplayFormat.FormatString = "d";
            this.txtOpeningBalanceDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOpeningBalanceDate.Properties.EditFormat.FormatString = "d";
            this.txtOpeningBalanceDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOpeningBalanceDate.Properties.Mask.EditMask = "d";
            this.txtOpeningBalanceDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtOpeningBalanceDate.Properties.ReadOnly = true;
            this.txtOpeningBalanceDate.Size = new System.Drawing.Size(125, 22);
            this.txtOpeningBalanceDate.StyleController = this.layoutControl1;
            this.txtOpeningBalanceDate.TabIndex = 5;
            this.txtOpeningBalanceDate.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(636, 214);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOpeningBalanceDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(231, 26);
            this.layoutControlItem2.Text = "Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(606, 26);
            this.layoutControlItem1.Text = "Customer";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtOpBalAmt;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(231, 26);
            this.layoutControlItem3.Text = "Opening Balance";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.memoNarration;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(606, 91);
            this.layoutControlItem4.Text = "Narration";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(99, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(231, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(375, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(231, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(375, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(606, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 194);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 169);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(606, 25);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // customerOpeningBalanceEditListModelBindingSource
            // 
            this.customerOpeningBalanceEditListModelBindingSource.DataSource = typeof(Alit.Marker.Model.Customer.CustomerOpeningBalanceViewModel);
            // 
            // frmCustomerOpeningBalance
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 278);
            this.FirstControl = this.layoutControl1;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCustomerOpeningBalance.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerOpeningBalance";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Opening Balance";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).EndInit();
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoNarration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpBalAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOpeningBalanceEditListModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private Alit.WinformControls.MemoEdit memoNarration;
        private Alit.WinformControls.TextEdit txtOpBalAmt;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource customerOpeningBalanceEditListModelBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private Alit.WinformControls.TextEdit txtCustomerName;
        private Alit.WinformControls.TextEdit txtOpeningBalanceDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}