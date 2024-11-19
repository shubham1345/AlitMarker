namespace Alit.Marker.WinForm.Settings.Compnay
{
    partial class frmCompanySelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanySelection));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.LookupFinPeriod = new Alit.WinformControls.LookUpEdit();
            this.LookUpCompany = new Alit.WinformControls.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFinPeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LookupFinPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFinPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(622, 91);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.LookupFinPeriod);
            this.myLayoutControl1.Controls.Add(this.LookUpCompany);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(618, 87);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // LookupFinPeriod
            // 
            this.LookupFinPeriod.EnterMoveNextControl = true;
            this.LookupFinPeriod.Location = new System.Drawing.Point(108, 38);
            this.LookupFinPeriod.MaximumSize = new System.Drawing.Size(500, 0);
            this.LookupFinPeriod.MinimumSize = new System.Drawing.Size(100, 0);
            this.LookupFinPeriod.Name = "LookupFinPeriod";
            this.LookupFinPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookupFinPeriod.Properties.NullText = "Select";
            this.LookupFinPeriod.Size = new System.Drawing.Size(487, 22);
            this.LookupFinPeriod.StyleController = this.myLayoutControl1;
            this.LookupFinPeriod.TabIndex = 5;
            // 
            // LookUpCompany
            // 
            this.LookUpCompany.EnterMoveNextControl = true;
            this.LookUpCompany.Location = new System.Drawing.Point(108, 12);
            this.LookUpCompany.MaximumSize = new System.Drawing.Size(500, 0);
            this.LookUpCompany.MinimumSize = new System.Drawing.Size(100, 0);
            this.LookUpCompany.Name = "LookUpCompany";
            this.LookUpCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpCompany.Properties.NullText = "Select";
            this.LookUpCompany.Size = new System.Drawing.Size(487, 22);
            this.LookUpCompany.StyleController = this.myLayoutControl1;
            this.LookUpCompany.TabIndex = 4;
            this.LookUpCompany.EditValueChanged += new System.EventHandler(this.LookUpCompany_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciCompany,
            this.lciFinPeriod,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(618, 87);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(587, 15);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciCompany
            // 
            this.lciCompany.Control = this.LookUpCompany;
            this.lciCompany.Location = new System.Drawing.Point(0, 0);
            this.lciCompany.Name = "lciCompany";
            this.lciCompany.Size = new System.Drawing.Size(587, 26);
            this.lciCompany.Text = "Company";
            this.lciCompany.TextSize = new System.Drawing.Size(93, 16);
            // 
            // lciFinPeriod
            // 
            this.lciFinPeriod.Control = this.LookupFinPeriod;
            this.lciFinPeriod.Location = new System.Drawing.Point(0, 26);
            this.lciFinPeriod.Name = "lciFinPeriod";
            this.lciFinPeriod.Size = new System.Drawing.Size(587, 26);
            this.lciFinPeriod.Text = "Financial Period";
            this.lciFinPeriod.TextSize = new System.Drawing.Size(93, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(587, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(11, 67);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmCompanySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 127);
            this.FirstControl = this.myLayoutControl1;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCompanySelection.IconOptions.Icon")));
            this.Name = "frmCompanySelection";
            this.Text = "Company Selection";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LookupFinPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFinPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private WinformControls.LookUpEdit LookUpCompany;
        private DevExpress.XtraLayout.LayoutControlItem lciCompany;
        private WinformControls.LookUpEdit LookupFinPeriod;
        private DevExpress.XtraLayout.LayoutControlItem lciFinPeriod;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}