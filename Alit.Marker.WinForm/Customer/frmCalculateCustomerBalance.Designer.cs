namespace Alit.Marker.WinForm.Customer
{
    partial class frmCalculateCustomerBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculateCustomerBalance));
            this.btnCalculateBalance = new DevExpress.XtraEditors.SimpleButton();
            this.progressbar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lblWaitMessage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressbar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblWaitMessage);
            this.panelContent.Controls.Add(this.progressbar);
            this.panelContent.Controls.Add(this.btnCalculateBalance);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelContent.Size = new System.Drawing.Size(240, 177);
            // 
            // btnCalculateBalance
            // 
            this.btnCalculateBalance.Location = new System.Drawing.Point(14, 15);
            this.btnCalculateBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCalculateBalance.Name = "btnCalculateBalance";
            this.btnCalculateBalance.Size = new System.Drawing.Size(212, 76);
            this.btnCalculateBalance.TabIndex = 0;
            this.btnCalculateBalance.Text = "Calculate Customer Balance Now";
            this.btnCalculateBalance.Click += new System.EventHandler(this.btnCalculateBalance_Click);
            // 
            // progressbar
            // 
            this.progressbar.EditValue = 100;
            this.progressbar.Location = new System.Drawing.Point(15, 100);
            this.progressbar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(211, 22);
            this.progressbar.TabIndex = 1;
            // 
            // lblWaitMessage
            // 
            this.lblWaitMessage.Appearance.Options.UseTextOptions = true;
            this.lblWaitMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblWaitMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblWaitMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWaitMessage.Location = new System.Drawing.Point(15, 130);
            this.lblWaitMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblWaitMessage.Name = "lblWaitMessage";
            this.lblWaitMessage.Size = new System.Drawing.Size(211, 89);
            this.lblWaitMessage.TabIndex = 2;
            this.lblWaitMessage.Text = "Please wait while calculating customer balances";
            // 
            // frmCalculateCustomerBalance
            // 
            this.AllowSave = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 213);
            this.FirstControl = this.progressbar;
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmCalculateCustomerBalance.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmCalculateCustomerBalance";
            this.Text = "Calculate Customer Balance";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressbar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCalculateBalance;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressbar;
        private DevExpress.XtraEditors.LabelControl lblWaitMessage;
    }
}