namespace Alit.Marker.WinForm.ERP.Masters.Transport
{
    partial class frmTransportGridGRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransportGridGRUD));
            this.gcTransport = new DevExpress.XtraGrid.GridControl();
            this.gvTransport = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.Appearance.FontSizeDelta = 10;
            this.lblFormCaption.Appearance.Options.UseFont = true;
            this.lblFormCaption.Appearance.Options.UseTextOptions = true;
            this.lblFormCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFormCaption.Location = new System.Drawing.Point(0, 64);
            this.lblFormCaption.Size = new System.Drawing.Size(853, 37);
            this.lblFormCaption.Text = "Transport";
            // 
            // btnCrudGridExportTo
            // 
            this.btnCrudGridExportTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCrudGridExportTo.ImageOptions.SvgImage")));
            this.btnCrudGridExportTo.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            // 
            // gcTransport
            // 
            this.gcTransport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTransport.Location = new System.Drawing.Point(0, 101);
            this.gcTransport.MainView = this.gvTransport;
            this.gcTransport.MenuManager = this.barManager1;
            this.gcTransport.Name = "gcTransport";
            this.gcTransport.Size = new System.Drawing.Size(853, 315);
            this.gcTransport.TabIndex = 7;
            this.gcTransport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTransport});
            // 
            // gvTransport
            // 
            this.gvTransport.GridControl = this.gcTransport;
            this.gvTransport.Name = "gvTransport";
            this.gvTransport.OptionsView.ShowGroupPanel = false;
            // 
            // frmTransportGridGRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 441);
            this.Controls.Add(this.gcTransport);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmTransportGridGRUD.IconOptions.Icon")));
            this.Name = "frmTransportGridGRUD";
            this.Text = "Transport";
            this.Controls.SetChildIndex(this.lblFormCaption, 0);
            this.Controls.SetChildIndex(this.gcTransport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTransport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransport;
    }
}