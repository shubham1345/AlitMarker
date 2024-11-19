namespace Alit.Marker.WinForm.Customer
{
    partial class ucCustomerSelectionOld
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.txtGSTNo = new Alit.WinformControls.TextEdit();
            this.txtBalance = new Alit.WinformControls.TextEdit();
            this.lookupListCustomer1 = new Alit.Marker.WinForm.Customer.LookupEditCustomer();
            this.txtCustomerNo = new Alit.WinformControls.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupListCustomer1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtGSTNo);
            this.myLayoutControl1.Controls.Add(this.txtBalance);
            this.myLayoutControl1.Controls.Add(this.lookupListCustomer1);
            this.myLayoutControl1.Controls.Add(this.txtCustomerNo);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(844, 26);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.EnterMoveNextControl = true;
            this.txtGSTNo.Location = new System.Drawing.Point(692, 2);
            this.txtGSTNo.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtGSTNo.MinimumSize = new System.Drawing.Size(150, 0);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Properties.ReadOnly = true;
            this.txtGSTNo.Size = new System.Drawing.Size(150, 22);
            this.txtGSTNo.StyleController = this.myLayoutControl1;
            this.txtGSTNo.TabIndex = 7;
            this.txtGSTNo.TabStop = false;
            // 
            // txtBalance
            // 
            this.txtBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBalance.EnterMoveNextControl = true;
            this.txtBalance.Location = new System.Drawing.Point(558, 2);
            this.txtBalance.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtBalance.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBalance.Properties.Mask.EditMask = "n2";
            this.txtBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBalance.Properties.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(75, 22);
            this.txtBalance.StyleController = this.myLayoutControl1;
            this.txtBalance.TabIndex = 6;
            this.txtBalance.TabStop = false;
            // 
            // lookupListCustomer1
            // 
            this.lookupListCustomer1.EnterMoveNextControl = true;
            this.lookupListCustomer1.Location = new System.Drawing.Point(192, 2);
            this.lookupListCustomer1.Name = "lookupListCustomer1";
            this.lookupListCustomer1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lookupListCustomer1.Properties.DisplayMember = "CustomerName";
            this.lookupListCustomer1.Properties.DropDownRows = 15;
            this.lookupListCustomer1.Properties.ImmediatePopup = true;
            this.lookupListCustomer1.Properties.NullText = "Select Customer";
            this.lookupListCustomer1.Properties.PopupWidth = 1000;
            this.lookupListCustomer1.Properties.ValueMember = "CustomerID";
            this.lookupListCustomer1.Size = new System.Drawing.Size(310, 22);
            this.lookupListCustomer1.StyleController = this.myLayoutControl1;
            this.lookupListCustomer1.TabIndex = 5;
            this.lookupListCustomer1.EditValueChanged += new System.EventHandler(this.lookupCustomer_EditValueChanged);
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.EditValue = ((long)(0));
            this.txtCustomerNo.EnterMoveNextControl = true;
            this.txtCustomerNo.Location = new System.Drawing.Point(87, 2);
            this.txtCustomerNo.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtCustomerNo.MinimumSize = new System.Drawing.Size(50, 0);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCustomerNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCustomerNo.Properties.Mask.EditMask = "n0";
            this.txtCustomerNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCustomerNo.Size = new System.Drawing.Size(62, 22);
            this.txtCustomerNo.StyleController = this.myLayoutControl1;
            this.txtCustomerNo.TabIndex = 4;
            this.txtCustomerNo.EditValueChanged += new System.EventHandler(this.txtCustomerNo_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(844, 26);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(151, 26);
            this.layoutControlItem1.Text = "Customer No.";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookupListCustomer1;
            this.layoutControlItem2.Location = new System.Drawing.Point(151, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(353, 26);
            this.layoutControlItem2.Text = "Name";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(34, 16);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtBalance;
            this.layoutControlItem3.Location = new System.Drawing.Point(504, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(131, 26);
            this.layoutControlItem3.Text = "Balance";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(47, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtGSTNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(635, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem4.Text = "GST No.";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // ucCustomerSelectionOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myLayoutControl1);
            this.Name = "ucCustomerSelectionOld";
            this.Size = new System.Drawing.Size(844, 26);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupListCustomer1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private WinformControls.TextEdit txtCustomerNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private LookupEditCustomer lookupListCustomer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private WinformControls.TextEdit txtBalance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private WinformControls.TextEdit txtGSTNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
