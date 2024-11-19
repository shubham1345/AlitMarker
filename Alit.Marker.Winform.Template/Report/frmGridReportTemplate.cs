using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.IO;
using System.Xml;
using DevExpress.XtraGrid.Views.BandedGrid;
using Alit.Marker.Model;
using Alit.Marker.Model.Users;
using Alit.Marker.Model.Template.Report;
using Alit.Marker.DAL.Template.Report;
using Alit.Marker.Model.Users.UserGroup;

namespace Alit.Marker.WinForm.Template.Report
{
    public partial class frmGridReportTemplate : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Base Form
        int MenuID_;
        public int MenuOptionID
        {
            get
            {
                return MenuID_;
            }
            set
            {
                if (MenuID_ != value)
                {
                    MenuID_ = value;

                    //DAL.Users.UserGroupDAL UGDALObj = new DAL.Users.UserGroupDAL();
                    var perm = CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuID_);
                    if (perm != null)
                    {
                        UserMenuPermission = perm;
                    }
                    else
                    {
                        UserMenuPermission = new Alit.Marker.Model.Users.UserGroup.MenuOptionPermissionViewModel()
                        {
                            MenuOptionID = MenuID_,
                            CanAdd = true,
                            CanDelete = true,
                            CanEdit = true,
                            CanView = true,
                            CanPrint = true,
                        };
                    }
                    if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                    {
                        UserMenuPermission.CanAdd = true;
                        UserMenuPermission.CanEdit = true;
                        UserMenuPermission.CanDelete = true;
                        UserMenuPermission.CanPrint = true;
                    }
                }
            }
        }

        public MenuOptionPermissionViewModel UserMenuPermission { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            MemoryManagement.FlushMemory();
        }

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMain;

        public void ShowWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.splashScreenManagerMain = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(frmWait), true, true, true);
                this.splashScreenManagerMain.ShowWaitForm();
            }
        }

        public void CloseWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                if (this.splashScreenManagerMain == null) return;
                this.splashScreenManagerMain.CloseWaitForm();
                this.splashScreenManagerMain.Dispose();
                this.splashScreenManagerMain = null;
            }
        }

        #endregion

        #region Report Grid Control and Datasource
        public IReportDAL ReportDALObj { get; set; }

        public IEnumerable<IReportViewModel> ReportDataSource { get; set; }

        GridControl ReportGridControl_;
        public GridControl ReportGridControl
        {
            get { return ReportGridControl_; }
            set
            {
                if (ReportGridControl_ != value)
                {
                    ReportGridControl_ = value;

                    Font RegularFont = new Font("Arial", 10, FontStyle.Regular);
                    Font BoldFont = new Font("Arial", 10, FontStyle.Bold);
                    foreach (GridView view in ReportGridControl_.ViewCollection.OfType<GridView>())
                    {
                        view.OptionsBehavior.Editable = false;
                        view.OptionsBehavior.FocusLeaveOnTab = true;
                        view.OptionsNavigation.EnterMoveNextColumn = true;
                        view.OptionsNavigation.UseTabKey = false;
                        view.Appearance.FocusedCell.BackColor = view.Appearance.SelectedRow.BackColor;
                        view.Appearance.FocusedCell.ForeColor = view.Appearance.SelectedRow.ForeColor;
                        view.ShowFindPanel();
                        view.OptionsView.ShowAutoFilterRow = true;
                        view.OptionsBehavior.AutoExpandAllGroups = true;
                        view.OptionsSelection.MultiSelect = true;
                        view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                        view.OptionsSelection.EnableAppearanceFocusedCell = false;
                        view.OptionsSelection.EnableAppearanceHideSelection = false;

                        view.OptionsPrint.ExpandAllDetails = true;
                        view.OptionsPrint.ExpandAllGroups = true;
                        view.OptionsPrint.PrintDetails = true;

                        view.AppearancePrint.Row.Font = RegularFont;
                        view.AppearancePrint.HeaderPanel.Font = BoldFont;
                        view.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        view.AppearancePrint.FooterPanel.Font = BoldFont;
                        view.AppearancePrint.GroupRow.Font = BoldFont;
                        view.AppearancePrint.GroupFooter.Font = BoldFont;

                        view.Appearance.FooterPanel.Font = BoldFont;

                        view.Appearance.ViewCaption.Font = BoldFont;

                        if (view is AdvBandedGridView)
                        {
                            var abView = (AdvBandedGridView)view;
                            abView.AppearancePrint.BandPanel.Font = BoldFont;
                        }
                    }
                }
            }
        }

        GridView ReportGridView_;
        public GridView ReportGridView
        {
            get { return ReportGridView_; }
            set
            {
                if (ReportGridView_ != value)
                {
                    if (ReportGridView_ != null)
                    {
                        ReportGridView_.FocusedRowChanged -= gvReportData_FocusedRowChanged;
                    }

                    ReportGridView_ = value;

                    if (ReportGridView_ != null)
                    {
                        ReportGridView_.FocusedRowChanged += gvReportData_FocusedRowChanged;
                    }
                }
            }
        }

        bool ShowDefaultFilter_ = false;
        /// <summary>
        /// Shwo default filter group box
        /// </summary>
        [DefaultValue(false)]
        public bool ShowDefaultFilter
        {
            get
            {
                return ShowDefaultFilter_;
            }
            set
            {
                ShowDefaultFilter_ = value;
                if (ShowDefaultFilter_)
                {
                    lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcTitle.Height = 61;
                }
                else
                {
                    lcgDefaultFilterGroupBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcTitle.Height = 45;
                }
            }
        }

        #endregion


        #region fields
        Dictionary<string, MemoryStream> ReportGridViewDefaultLayoutStreams;
        #endregion

        #region Contructor & destructure

        public frmGridReportTemplate()
        {
            ReportGridViewDefaultLayoutStreams = new Dictionary<string, MemoryStream>();
            //--
            InitializeComponent();
            lblFormCaption.Text = this.Text;

            ShowWaitForm();
        }

        ~frmGridReportTemplate()
        {
            foreach (var stream in ReportGridViewDefaultLayoutStreams)
            {
                stream.Value.Close();
                stream.Value.Dispose();
            }
        }
        #endregion

        #region Parent Overriden Methods
        protected override void OnTextChanged(EventArgs e)
        {
            lblFormCaption.Text = this.Text;
            base.OnTextChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            lblFormCaption.Text = this.Text;

            if (Template.CommonPropperties.IsRunTime)
            {
                this.AcquireMaximumScreensize();
            }

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                backgroundWorkerLoadInitialValues.RunWorkerAsync();
            }
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveReportGridLayout();
            base.OnClosing(e);
        }
        #endregion

        #region Events
        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadFormValues();
            LoadLookupDataSource();
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //while (!this.IsHandleCreated) { }
            this.Invoke((MethodInvoker)delegate
            {
                AssignLookupDataSource();
                AssignFormValues();

                ReloadReportData();

                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in ReportGridControl.Views)
                {
                    MemoryStream stream = new MemoryStream();
                    view.SaveLayoutToStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    ReportGridViewDefaultLayoutStreams.Add(view.Name, stream);
                }

                RestoreReportGridLayout();
                CloseWaitForm();
            });
        }

        #region Grid View
        private void gvReportData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ResetRowView(ReportGridView.GetFocusedRow());
        }

        private void btnResetReportGridLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ReportGridControl != null)
            {
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in ReportGridControl.Views)
                {
                    if (ReportGridViewDefaultLayoutStreams.ContainsKey(view.Name))
                    {
                        MemoryStream stream = ReportGridViewDefaultLayoutStreams[view.Name];
                        view.RestoreLayoutFromStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                    }
                }
            }
        }
        #endregion

        #region CRUD Operation events
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReloadReportData();
        }

        public void ExecuteReloadReportData() { ExecuteReloadReportData(false); }
        public void ExecuteReloadReportData(bool SkipFormValidation)
        {
            if (!SkipFormValidation && !ProcessValidationFormControls())
            {
                //if (FirstControl != null && FirstControl.CanFocus)
                //{
                //    FirstControl.Focus();
                //}
                return;
            }

            if (!SkipFormValidation && !ValidateBeforeGenerateReportDataSource())
            {
                // it's implementing class responsibiliy to set focus on appropriate control.
                return;
            }

            ReloadReportData();
        }

        public bool ProcessValidationFormControls()
        {
            WinForm.Template.frmCRUDTemplate.CallValidatingEvent(this);

            string ErrorText = ErrorProvider.GetAllErrorText();
            if (!String.IsNullOrEmpty(ErrorText))
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not generate report. Please fix following errors:\r\n\r\n" + ErrorText,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //if (ErrorProvider.ErrorList != null && ErrorProvider.ErrorList.Count > 0)
                //{
                //    SetFocusOnFirstControl();
                //}
                return false;
            }
            return true;
        }

        #endregion

        #region Report Print & Export
        private void btnReportPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportPrint();
        }

        private void btnReportPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportPrintPreview();
        }

        private void btnReportExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToExcel();
        }

        private void btnReportExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToPDF();
        }

        private void btnReportExportToWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToWord();
        }

        private void btnReportExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToCSV();
        }

        private void btnReportExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToText();
        }

        private void btnReportExportToImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteReportExportToImage();
        }
        #endregion


        private void btnCloseForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Virtual Methods

        #region form loading
        protected virtual void LoadLookupDataSource() { }

        protected virtual void AssignLookupDataSource() { }

        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void LoadFormValues() { }

        protected virtual void AssignFormValues() { }
        #endregion

        #region Reload Data 

        public virtual void ReloadReportData(int? newPrimeKeyID = null)
        {
            if (ReportGridControl != null && ReportGridView != null)
            {
                long? LastFocusedRowPrimeKeyID = null;
                if (newPrimeKeyID != null)
                {
                    LastFocusedRowPrimeKeyID = newPrimeKeyID;
                }
                else
                {
                    var Row = ReportGridView.GetFocusedRow();
                    if (Row is IReportViewModel)
                    {
                        LastFocusedRowPrimeKeyID = ((IReportViewModel)ReportGridView.GetFocusedRow()).PrimeKeyID;
                    }
                }

                ReportDataSource = GetReportDataSource(GetReportDataSourceFilterParas());
                ReportGridControl.DataSource = ReportDataSource;
                FormatReportGridView(ReportGridView);

                if (LastFocusedRowPrimeKeyID != null && ReportDataSource != null)
                {
                    int NewDataSourceRowIndex = ReportDataSource.ToList().FindIndex(r => r.PrimeKeyID == LastFocusedRowPrimeKeyID);

                    ReportGridView.FocusedRowHandle = ReportGridView.GetRowHandle(NewDataSourceRowIndex);

                    ReportGridView.ClearSelection();
                    ReportGridView.SelectRange(ReportGridView.FocusedRowHandle, ReportGridView.FocusedRowHandle);
                }

                ResetRowView(ReportGridView.GetFocusedRow());
            }
        }

        protected virtual bool ValidateBeforeGenerateReportDataSource()
        {
            return true;
        }

        protected virtual IEnumerable<IReportViewModel> GetReportDataSource(object[] FilterParas)
        {
            if (ReportDALObj != null)
            {
                return ReportDALObj.GetReportData(FilterParas);
            }
            else
            {
                return null;
            }
        }

        protected virtual object[] GetReportDataSourceFilterParas()
        {
            return null;
        }

        protected virtual void FormatReportGridView(GridView ReportGridView)
        {
        }

        protected virtual void ResetRowView(object EditingRecord)
        {
            if (EditingRecord == null)
            {
                lblRecordNo.Caption = $"0 of " + ReportGridView.RowCount;
            }
            else
            {
                lblRecordNo.Caption = $"{ReportGridView.GetVisibleIndex(ReportGridView.FocusedRowHandle) + 1} of " + ReportGridView.RowCount;
            }
        }

        protected virtual void RestoreReportGridLayout()
        {
            // restore dashbaord grid layout
            foreach (DevExpress.XtraGrid.Views.Base.BaseView view in ReportGridControl.Views)
            {
                string filename = $@"{CommonPropperties.ReportGridLayoutFolder}\{this.Text}{view.Name}.layout";
                if (System.IO.File.Exists(filename))
                {
                    try
                    {
                        view.RestoreLayoutFromXml(filename);
                    }
                    catch (Exception ex)
                    {
                        ex = DAL.CommonFunctions.GetFinalError(ex);
                        MessageBox.Show(ex.Message);
                    }
                    //catch (XmlException) { }
                    //catch (DirectoryNotFoundException) { }
                    //catch (FileNotFoundException) { }
                }
            }
        }

        protected virtual void SaveReportGridLayout()
        {
            if (ReportGridControl != null)
            {
                string Directory = $@"{CommonPropperties.ReportGridLayoutFolder}\";
                if (!System.IO.Directory.Exists(Directory))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(Directory);
                    }
                    catch (Exception)
                    { }
                }
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in ReportGridControl.Views)
                {
                    string filename = $@"{CommonPropperties.ReportGridLayoutFolder}\{this.Text}{view.Name}.layout";

                    view.SaveLayoutToXml(filename);
                }
            }
        }
        #endregion

        #region Report Print & Export

        protected virtual GeneralizeReportGeneratorParameters GenerateReportPrintParas()
        {
            return new GeneralizeReportGeneratorParameters(ReportGridControl)
            {
                PageHeaderLine1 = this.Text,
                PageHeaderLine2 = ReportGridView.GetFilterDisplayText(ReportGridView.ActiveFilter),
                Landscape = true,
            };
        }


        public virtual void ExecuteReportPrintPreview()
        {
            if (ReportGridControl != null)
            {
                ReportPrintPreview(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportPrintPreview(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.PrintPreview();
                }
            }
        }


        public virtual void ExecuteReportPrint()
        {
            if (ReportGridControl != null)
            {
                ReportPrint(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportPrint(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                {
                    ReportGenerator.Print();
                }
            }
        }


        public virtual void ExecuteReportExportToExcel()
        {
            if (ReportGridControl != null)
            {
                ReportExportToExcel(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToExcel(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel|*.xlsx";
                sfd.FileName = this.Text + ".xlsx";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToExcel(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteReportExportToPDF()
        {
            if (ReportGridControl != null)
            {
                ReportExportToPDF(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToPDF(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf|*.pdf";
                sfd.FileName = this.Text + ".pdf";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToPDF(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteReportExportToWord()
        {
            if (ReportGridControl != null)
            {
                ReportExportToWord(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToWord(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word|*.docx";
                sfd.FileName = this.Text + ".docx";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToWord(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteReportExportToCSV()
        {
            if (ReportGridControl != null)
            {
                ReportExportToCSV(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToCSV(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Csv|*.csv";
                sfd.FileName = this.Text + ".csv";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToCSV(sfd.FileName);
                    }

                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteReportExportToText()
        {
            if (ReportGridControl != null)
            {
                ReportExportToText(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToText(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text|*.txt";
                sfd.FileName = this.Text + ".txt";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToText(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }


        public virtual void ExecuteReportExportToImage()
        {
            if (ReportGridControl != null)
            {
                ReportExportToImage(GenerateReportPrintParas());
            }
        }
        protected virtual void ReportExportToImage(GeneralizeReportGeneratorParameters printParas)
        {
            if (printParas != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Png Image|*.png";
                sfd.FileName = this.Text + ".png";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (GeneralizeReportGenerator ReportGenerator = new GeneralizeReportGenerator(printParas))
                    {
                        ReportGenerator.ExportToImage(sfd.FileName);
                    }
                    if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}