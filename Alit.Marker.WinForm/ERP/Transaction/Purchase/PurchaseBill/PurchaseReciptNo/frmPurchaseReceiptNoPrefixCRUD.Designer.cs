namespace Alit.Marker.WinForm.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo
{
    partial class frmPurchaseReceiptNoPrefixCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseReceiptNoPrefixCRUD));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.txtPurchaseReceiptNoPrefix = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBase1)).BeginInit();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseReceiptNoPrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.Size = new System.Drawing.Size(676, 126);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Location = new System.Drawing.Point(0, 26);
            this.panelContent.Size = new System.Drawing.Size(676, 66);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtPurchaseReceiptNoPrefix);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(672, 62);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtPurchaseReceiptNoPrefix
            // 
            this.txtPurchaseReceiptNoPrefix.EnterMoveNextControl = true;
            this.txtPurchaseReceiptNoPrefix.Location = new System.Drawing.Point(150, 12);
            this.txtPurchaseReceiptNoPrefix.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtPurchaseReceiptNoPrefix.MenuManager = this.barManager1;
            this.txtPurchaseReceiptNoPrefix.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtPurchaseReceiptNoPrefix.Name = "txtPurchaseReceiptNoPrefix";
            this.txtPurchaseReceiptNoPrefix.Properties.MaxLength = 50;
            this.txtPurchaseReceiptNoPrefix.Size = new System.Drawing.Size(500, 22);
            this.txtPurchaseReceiptNoPrefix.StyleController = this.layoutControl1;
            this.txtPurchaseReceiptNoPrefix.TabIndex = 4;
            this.txtPurchaseReceiptNoPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrefixName_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(672, 62);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtPurchaseReceiptNoPrefix;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(642, 26);
            this.layoutControlItem1.Text = "Purchase Invoice Prefix";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(135, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(652, 16);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(642, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPurchaseReceiptNoPrefixCRUD
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 126);
            this.FirstControl = this.layoutControl1;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmPurchaseReceiptNoPrefixCRUD.IconOptions.Icon")));
            this.Name = "frmPurchaseReceiptNoPrefixCRUD";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Purchase Receipt No Prefix";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseReceiptNoPrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private Alit.WinformControls.TextEdit txtPurchaseReceiptNoPrefix;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}