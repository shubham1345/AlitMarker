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
using System.Runtime.InteropServices;
using System.Reflection;
using Alit.Marker.Model.Template;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Template
{
    public partial class frmSearchWindowTemplate : frmBaseTemplate
    {
        public Type CrudFormType { get; private set; }

        bool AllowSelect_ = true;
        [DefaultValue(true)]
        [Description("Allow Save Button to be visible")]
        public bool AllowSelect
        {
            get
            {
                return AllowSelect_;
            }
            set
            {
                if (value != AllowSelect_)
                {
                    AllowSelect_ = value;
                    if (btnSelect != null)
                    {
                        btnSelect.Visibility =
                            (AllowSelect_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowRefresh_ = false;
        [DefaultValue(false)]
        [Description("Allow Refresh Button to be visible")]
        public bool AllowRefresh
        {
            get
            {
                return AllowRefresh_;
            }
            set
            {
                if (value != AllowRefresh_)
                {
                    AllowRefresh_ = value;
                    if (btnRefresh != null)
                    {
                        btnRefresh.Visibility =
                            (AllowRefresh_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowExit_ = true;
        [DefaultValue(true)]
        [Description("Allow Exit Button to be visible")]
        public bool AllowExit
        {
            get
            {
                return AllowExit_;
            }
            set
            {
                if (value != AllowExit_)
                {
                    AllowExit_ = value;
                    if (btnExit != null)
                    {
                        btnExit.Visibility =
                            (AllowExit_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);
                    }
                }
            }
        }

        bool AllowFilterPanel_ = true;
        [DefaultValue(true)]
        [Description("Allow to visible filter panel")]
        public bool AllowFilterPanel
        {
            get
            {
                return AllowFilterPanel_;
            }
            set
            {
                if (value != AllowFilterPanel_)
                {
                    AllowFilterPanel_ = value;
                    if (btnFilter != null)
                    {
                        btnFilter.Visibility =
                            (AllowFilterPanel_ ?
                            DevExpress.XtraBars.BarItemVisibility.Always :
                            DevExpress.XtraBars.BarItemVisibility.Never);

                        dockPanelFilter.Visibility = (AllowFilterPanel_ ? DevExpress.XtraBars.Docking.DockVisibility.Visible : DevExpress.XtraBars.Docking.DockVisibility.Hidden);
                    }
                }
            }
        }


        private Control FirstControl_;
        [DefaultValue(null)]
        public Control FirstControl
        {
            get
            {
                if (FirstControl_ == null)
                {
                    FirstControl_ = this.panelContent.Controls.Cast<Control>().FirstOrDefault(r => r.Enabled && r.CanFocus);
                }
                return FirstControl_;
            }
            set
            {
                FirstControl_ = value;
            }
        }

        string SaveButtonCaption_;
        public string SaveButtonCaption
        {
            get { return SaveButtonCaption_; }
            set
            {
                if (SaveButtonCaption_ != value)
                {
                    SaveButtonCaption_ = value;
                    btnSelect.Caption = SaveButtonCaption_;
                }
            }
        }

        string ExitButtonCaption_;
        public string ExitButtonCaption
        {
            get { return ExitButtonCaption_; }
            set
            {
                if (ExitButtonCaption_ != value)
                {
                    ExitButtonCaption_ = value;
                    btnExit.Caption = ExitButtonCaption_;
                }
            }
        }

        [Description("Selected Record. Value will be assign when user selects a record.")]
        [DefaultValue(null)]
        public ILookupListViewModel SelectedRecord { get; set; }

        /// <summary>
        /// row to be focused by default
        /// </summary>
        ILookupListViewModel DefaultFocusedRow;

        #region Search Grid Control and Datasource
        public DAL.Template.ILookupListDAL LookupDALObj { get; set; }

        IEnumerable<ILookupListViewModel> _LookupDataSource;
        public IEnumerable<ILookupListViewModel> LookupDataSource
        {
            get
            {
                return _LookupDataSource;
            }
            set
            {
                _LookupDataSource = value;
                if (SearchGridView != null)
                {
                    SearchGridView.GridControl.DataSource = _LookupDataSource;
                    FormatSearchGridView(SearchGridView);
                    ResetRowView(SearchGridView.GetFocusedRow());
                }
            }
        }

        [Description("True : if user add, edit, or deletes records from the given data source.")]
        [DefaultValue(false)]
        public bool LookupDataSourceHasChanges { get; private set; }

        GridControl SearchGridControl_;
        public GridControl SearchGridControl
        {
            get { return SearchGridControl_; }
            set
            {
                if (SearchGridControl_ != value)
                {
                    SearchGridControl_ = value;
                }
            }
        }

        GridView SearchGridView_;
        public GridView SearchGridView
        {
            get { return SearchGridView_; }
            set
            {
                if (SearchGridView_ != value)
                {
                    if (SearchGridView_ != null)
                    {
                        SearchGridView_.FocusedRowChanged -= gvSearchData_FocusedRowChanged;
                        SearchGridView_.RowCellClick -= SearchGridView_RowCellClick;
                    }

                    SearchGridView_ = value;

                    if (SearchGridView_ != null)
                    {
                        SearchGridView_.FocusedRowChanged += gvSearchData_FocusedRowChanged;
                        SearchGridView_.RowCellClick += SearchGridView_RowCellClick;
                        SearchGridView_.KeyDown += SearchGridView__KeyDown;

                        SearchGridView_.OptionsBehavior.Editable = false;
                        SearchGridView_.OptionsBehavior.FocusLeaveOnTab = true;
                        SearchGridView_.OptionsNavigation.EnterMoveNextColumn = true;
                        SearchGridView_.OptionsNavigation.UseTabKey = false;
                        SearchGridView_.Appearance.FocusedCell.BackColor = SearchGridView_.Appearance.SelectedRow.BackColor;
                        SearchGridView_.Appearance.FocusedCell.ForeColor = SearchGridView_.Appearance.SelectedRow.ForeColor;
                        SearchGridView_.ShowFindPanel();
                        SearchGridView_.OptionsView.ShowAutoFilterRow = true;
                        SearchGridView_.OptionsBehavior.AutoExpandAllGroups = true;
                        SearchGridView_.OptionsSelection.MultiSelect = true;
                        SearchGridView_.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                        SearchGridView_.OptionsSelection.EnableAppearanceFocusedCell = false;
                        SearchGridView_.OptionsSelection.EnableAppearanceHideSelection = false;
                        SearchGridView_.OptionsDetail.DetailMode = DetailMode.Embedded;

                        Font RegularFont = new Font("Arial", 10, FontStyle.Regular);
                        Font BoldFont = new Font("Arial", 10, FontStyle.Bold);
                        SearchGridView_.AppearancePrint.Row.Font = RegularFont;
                        SearchGridView_.AppearancePrint.HeaderPanel.Font = BoldFont;
                        SearchGridView_.AppearancePrint.GroupFooter.Font = BoldFont;
                        SearchGridView_.AppearancePrint.GroupFooter.Font = BoldFont;
                        SearchGridView_.Appearance.FooterPanel.Font = BoldFont;
                        SearchGridView_.Appearance.GroupRow.Font = BoldFont;
                        SearchGridView_.Appearance.ViewCaption.Font = BoldFont;

                        // to synchronize grid view layout with Search buttons and settings and properties
                        ShowDetailView = ShowDetailView;

                        //--
                        SearchGridView_.GridControl.DataSource = LookupDataSource;
                        if (DefaultFocusedRow != null)
                        {
                            SearchGridView_.FocusedRowHandle = SearchGridView_.GetRowHandle(LookupDataSource.ToList().IndexOf(DefaultFocusedRow));
                            SearchGridView_.ClearSelection();
                            SearchGridView_.SelectRange(SearchGridView_.FocusedRowHandle, SearchGridView_.FocusedRowHandle);
                        }
                        //--
                        if (SearchGridView_.Columns.Count <= 1)
                        {
                            AllowFilterPanel = false;
                        }
                        else
                        {
                            filteringUIContext1.Client = SearchGridView;
                            filteringUIContext1.RetrieveFields();
                        }

                    }
                }
            }
        }

        bool ShowAutoFilter_ = false;
        /// <summary>
        /// Shwo default filter group box
        /// </summary>
        [DefaultValue(false)]
        public bool ShowAutoFilter
        {
            get
            {
                return ShowAutoFilter_;
            }
            set
            {
                ShowAutoFilter_ = value;
                if (ShowAutoFilter_)
                {
                    dockPanelFilter.ShowSliding();
                }
                else
                {
                    dockPanelFilter.HideSliding();
                }
            }
        }


        bool ShowGridViewDetailOptions_ = false;
        [DefaultValue(false)]
        [Description("If Search grid control contains shows multi level grid views (detail view) then assign true to show detail view relation buttons like show detail, expand and collaps buttons")]
        public bool ShowGridViewDetailOptions
        {
            get
            {
                return ShowGridViewDetailOptions_;
            }
            set
            {
                ShowGridViewDetailOptions_ = value;
                if (ShowGridViewDetailOptions_)
                {
                    btnShowDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnExpandAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnCollapsAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnShowDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnExpandAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnCollapsAllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        bool ShowDetailView_ = false;
        [Description("true : Show detail view, If Search grid control contains shows multi level grid views (detail view).")]
        [DefaultValue(false)]
        public bool ShowDetailView
        {
            get { return ShowDetailView_; }
            set
            {
                ShowDetailView_ = value;
                if (SearchGridView != null)
                {
                    btnShowDetails.DownChanged -= btnShowDetails_DownChanged;
                    btnShowDetails.Down = ShowDetailView_;
                    SearchGridView.OptionsDetail.EnableMasterViewMode = ShowDetailView_;
                    SearchGridView.OptionsPrint.PrintDetails = ShowDetailView_;
                    SearchGridView.OptionsPrint.ExpandAllDetails = ShowDetailView_;
                    btnShowDetails.DownChanged += btnShowDetails_DownChanged;
                }
            }
        }

        #endregion

        #region constructor & Form Loading

        protected frmSearchWindowTemplate() : this(null, null, null, null, null) { }

        protected frmSearchWindowTemplate(Type crudFormType, ILookupListDAL lookupDALObj, IEnumerable<ILookupListViewModel> dsLookup, ILookupListViewModel defaultFocusedRow, string WindowCaption)
        {
            InitializeComponent();

            CrudFormType = crudFormType;
            LookupDALObj = lookupDALObj;
            LookupDataSource = dsLookup;
            DefaultFocusedRow = defaultFocusedRow;

            SaveButtonCaption_ = btnSelect.Caption;
            ExitButtonCaption_ = btnExit.Caption;

            ShowWaitForm();

            btnSetSaveFocus.Size = Size.Empty;
            btnSetExitFocus.Size = Size.Empty;
            this.Text = WindowCaption;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (FirstControl != null) FirstControl.Focus();

            base.OnLoad(e);
            backgroundWorkerLoadInitialValues.RunWorkerAsync();
        }

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            OnLoadFormValues();
            OnLoadLookupDataSource();
        }

        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OnAssignLookupDataSource();
                OnAssignFormValues();
                CloseWaitForm();
                SetFocusOnFirstControl();
            });
        }

        public void ResetFormView()
        {
            OnClearValues();
            this.ErrorProvider.Clear();
            if (FirstControl != null) FirstControl.Focus();
        }

        #endregion


        /// <summary>
        /// Re-execute validation of all controls on form and show validation error message of all controls in one message, if any.
        /// </summary>
        /// <returns>false = has error, true = no error</returns>
        public bool ProcessValidationFormControls()
        {
            frmCRUDTemplate.CallValidatingEvent(this);

            string ErrorText = ErrorProvider.GetAllErrorText();
            if (!String.IsNullOrEmpty(ErrorText))
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not continue. Please fix following errors:\r\n\r\n" + ErrorText,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ErrorProvider.ErrorList != null && ErrorProvider.ErrorList.Count > 0)
                {
                    SetFocusOnFirstControl();
                }
                return false;
            }
            return true;
        }

        #region Virtual Methods

        public delegate bool ValidateBeforeSaveEventHandler(frmSearchWindowTemplate SearchWindow);
        public event ValidateBeforeSaveEventHandler ValidateBeforeSelect;
        protected virtual bool OnValidateBeforeSelect()
        {
            return ValidateBeforeSelect?.Invoke(this) ?? true;
        }

        public delegate ILookupListViewModel SelectRecordEventHandler(frmSearchWindowTemplate SearchWindow);
        public event SelectRecordEventHandler SelectRecord;
        protected virtual ILookupListViewModel OnSelectRecord()
        {
            var record = SelectRecord?.Invoke(this);
            if (record == null)
            {
                record = SearchGridView?.GetFocusedRow() as ILookupListViewModel;
            }
            return record;
        }

        public delegate bool AfterSelectRecordEventHandler(frmSearchWindowTemplate SearchWindow);
        public event AfterSelectRecordEventHandler AfterSelectRecord;

        /// <summary>
        /// Performs commands on search window after selecting record.
        /// </summary>
        /// <returns>false : to prevent the window to be closed.</returns>
        protected virtual bool OnAfterSelectRecord()
        {
            return AfterSelectRecord?.Invoke(this) ?? true;
        }

        public delegate void SearchWindowEventHandler(frmSearchWindowTemplate CRUDForm);
        public event SearchWindowEventHandler BeforeClearValues;
        public event SearchWindowEventHandler AfterClearValues;
        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        protected virtual void OnClearValues()
        {
            BeforeClearValues?.Invoke(this);
            frmCRUDTemplate.ClearValues(panelContent);
            AfterClearValues?.Invoke(this);
        }

        public event SearchWindowEventHandler InitializeDefaultValues;
        protected virtual void OnInitializeDefaultValues() { InitializeDefaultValues?.Invoke(this); }

        public event SearchWindowEventHandler LoadLookupDataSource;
        protected virtual void OnLoadLookupDataSource() { LoadLookupDataSource?.Invoke(this); }

        public event SearchWindowEventHandler AssignLookupDataSource;
        protected virtual void OnAssignLookupDataSource() { AssignLookupDataSource?.Invoke(this); }

        public event SearchWindowEventHandler LoadFormValues;
        /// <summary>
        /// Load/generate values that takes time to process like generating invoice number. 
        /// </summary>
        protected virtual void OnLoadFormValues() { LoadFormValues?.Invoke(this); }

        public event SearchWindowEventHandler AssignFormValues;
        protected virtual void OnAssignFormValues() { AssignFormValues?.Invoke(this); }

        #endregion

        #region Action Methods

        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PerformSelection();
        }

        public void PerformSelection()
        {
            if (!ProcessValidationFormControls())
            {
                if (FirstControl != null && FirstControl.CanFocus)
                {
                    FirstControl.Focus();
                }
                return;
            }

            if (!OnValidateBeforeSelect())
            {
                // it's implementing class responsibiliy to set focus on appropriate control.
                return;
            }

            SavingParemeter savingParas = new SavingParemeter();
            savingParas.SavingInterface = SavingParemeter.eSavingInterface.AddNew;

            //
            //ShowWaitForm();
            SelectedRecord = OnSelectRecord();
            //CloseWaitForm();
            //
            //--
            if (OnAfterSelectRecord())
            {
                if (SelectedRecord != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (MessageBox.Show("No record was selected. Do you want to continue?", "Search", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            //--
            //if (savingParas.SavingResult != null && savingParas.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            //{
            //    ResetFormView();
            //}
            FirstControl.Focus();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region CRUD Operations
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadSearchData();
        }
        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNewRecord();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditRecord();
        }
        #endregion

        public void SetFocusOnFirstControl()
        {
            if (FirstControl != null)
            {
                FirstControl.Focus();
            }
            else
            {
                panelContent.Focus();
                SendKeys.SendWait("{Tab}");
            }
        }

        private void btnSetSaveFocus_Enter(object sender, EventArgs e)
        {
            btnSelect.Links[0].Focus();
        }

        private void btnSetExitFocus_Click(object sender, EventArgs e)
        {
            btnExit.Links[0].Focus();
        }
        #endregion

        #region Grid View Methods
        private void gvSearchData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ResetRowView(SearchGridView.GetFocusedRow());
        }

        private void SearchGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Clicks > 1)
            {
                PerformSelection();
            }
        }

        private void SearchGridView__KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && e.Control)
            {
                PerformSelection();
            }
        }


        protected virtual void ResetRowView(object FocusedRecord)
        {
            if (FocusedRecord == null)
            {
                lblRecordNo.Caption = $"0 of {SearchGridView.RowCount} Rows";
            }
            else
            {
                lblRecordNo.Caption = $"{SearchGridView.GetVisibleIndex(SearchGridView.FocusedRowHandle) + 1} of {SearchGridView.RowCount} Rows";
            }
        }


        protected virtual void RestoreSearchGridLayout()
        {
            // restore dashbaord grid layout
            foreach (DevExpress.XtraGrid.Views.Base.BaseView view in SearchGridControl.Views)
            {
                string filename = $@"{CommonPropperties.SearchGridLayoutFolder}\{this.Text}{view.Name}.layout";
                if (System.IO.File.Exists(filename))
                {
                    try
                    {
                        view.RestoreLayoutFromXml(filename);
                        var gridView = view as GridView;
                        if (gridView != null)
                        {
                            ShowDetailView = gridView.OptionsDetail.EnableMasterViewMode;
                        }
                    }
                    catch (Exception ex)
                    {
                        ex = DAL.CommonFunctions.GetFinalError(ex);
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        protected virtual void SaveSearchGridLayout()
        {
            if (SearchGridControl != null)
            {
                string Directory = $@"{CommonPropperties.SearchGridLayoutFolder}\";
                if (!System.IO.Directory.Exists(Directory))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(Directory);
                    }
                    catch
                    {
                        //If there is any exception thrown while creating directory, it may be due to lack of permission on file system.
                        // this error is not required to be shown on UI
                    }
                }
                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in SearchGridControl.Views)
                {
                    string filename = $@"{CommonPropperties.SearchGridLayoutFolder}\{this.Text}{view.Name}.layout";

                    view.SaveLayoutToXml(filename);
                }
            }
        }

        #region Grid View - Master-Detail, Expand/Collaps
        private void btnShowDetails_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowDetailView = btnShowDetails.Down;
        }


        private void btnExpandAllDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView View = SearchGridView;
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                {
                    View.SetMasterRowExpanded(rHandle, true);
                }
            }
            finally
            {
                View.EndUpdate();
            }
        }

        private void btnCollapsAllDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchGridView.CollapseAllDetails();
        }

        #endregion


        #region Reload Data 

        public virtual void ReloadSearchData(long? newPrimeKeyID = null)
        {
            if (SearchGridControl != null && SearchGridView != null)
            {
                long? LastFocusedRowPrimeKeyID = null;
                if (newPrimeKeyID != null)
                {
                    LastFocusedRowPrimeKeyID = newPrimeKeyID;
                }
                else
                {
                    var Row = SearchGridView.GetFocusedRow();
                    if (Row is ILookupListViewModel)
                    {
                        LastFocusedRowPrimeKeyID = ((ILookupListViewModel)SearchGridView.GetFocusedRow()).PrimeKeyID;
                    }
                }

                LookupDataSource = GetSearchDataSource(GetSearchDataSourceFilterParas());
                SearchGridControl.DataSource = LookupDataSource;
                FormatSearchGridView(SearchGridView);
                LookupDataSourceHasChanges = true;

                if (LastFocusedRowPrimeKeyID != null && LookupDataSource != null)
                {
                    int NewDataSourceRowIndex = LookupDataSource.ToList().FindIndex(r => r.PrimeKeyID == LastFocusedRowPrimeKeyID);

                    SearchGridView.FocusedRowHandle = SearchGridView.GetRowHandle(NewDataSourceRowIndex);

                    SearchGridView.ClearSelection();
                    SearchGridView.SelectRange(SearchGridView.FocusedRowHandle, SearchGridView.FocusedRowHandle);
                }

                ResetRowView(SearchGridView.GetFocusedRow());
            }
        }

        protected virtual IEnumerable<ILookupListViewModel> GetSearchDataSource(object[] FilterParas)
        {
            if (LookupDALObj == null)
            {
                LookupDALObj = GetLookupListDALObj();
            }
            if (LookupDALObj != null)
            {
                return LookupDALObj.GetLookupList(FilterParas);
            }
            else
            {
                return null;
            }
        }

        protected virtual object[] GetSearchDataSourceFilterParas()
        {
            return null;
        }

        protected virtual void FormatSearchGridView(GridView SearchGridView)
        {
            if (SearchGridView.Columns.Any(r => r.FieldName == "RecordState"))
            {
                SearchGridView.Columns["RecordState"].MaxWidth = 100;
                SearchGridView.Columns["RecordState"].MinWidth = 75;

                SearchGridView.Columns["RecordState"].AppearanceCell.FontSizeDelta = -1;
                SearchGridView.Columns["RecordState"].AppearanceCell.BackColor = Color.WhiteSmoke;
            }
        }

        protected virtual ILookupListDAL GetLookupListDALObj() { return null; }
        #endregion

        #endregion

        #region Filter Pancel
        private void dockPanelFilter_ClosedPanel(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            btnFilter.Down = false;
        }

        private void btnFilter_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnFilter.Down)
            {
                dockPanelFilter.ShowSliding();
            }
            else
            {
                dockPanelFilter.HideSliding();
            }
        }
        #endregion

        #region Add new 
        protected virtual object[] GetAddNewFormParameters()
        {
            return null;
        }

        protected virtual void AddNewRecord()
        {
            if (CrudFormType == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not add new records. CrudFormType was not implemented.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var CRUDMTemplateDefaultPara = new CRUDMTemplateParas() { FormDefaultUI = eFormCurrentUI.NewEntry };
            object[] CrudFormParas = null;
            object[] CustomParas = GetAddNewFormParameters();
            if (CustomParas != null)
            {
                var list = new List<object> { CRUDMTemplateDefaultPara };
                list.AddRange(CustomParas);
                CrudFormParas = list.ToArray();
            }
            else
            {
                CrudFormParas = new object[] { CRUDMTemplateDefaultPara };
            }
            frmCRUDTemplate newFrm = (frmCRUDTemplate)Activator.CreateInstance(CrudFormType, CrudFormParas);
            newFrm.WindowState = FormWindowState.Normal;
            newFrm.StartPosition = FormStartPosition.CenterScreen;

            if (newFrm.ShowDialog(this) == DialogResult.OK)
            {
                AfterAddingRecord(newFrm.SaveResult);
                ReloadSearchData(newFrm.SaveResult?.PrimeKeyValue);
                //if (newFrm.SaveResult != null
                //    && newFrm.SaveResult.ExecutionResult == eExecutionResult.CommitedSucessfuly
                //    && newFrm.SaveResult.PrimeKeyValue != 0)
                //{
                //    this.EditValue = newFrm.SaveResult.PrimeKeyValue;
                //}
            }
        }

        protected virtual void AfterAddingRecord(SavingResult SavingResult)
        {
        }

        #endregion

        #region Editing
        protected virtual void EditRecord()
        {
            if (CrudFormType == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not edit. CrudFormType was not implemented.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var FocusedRecord = (ILookupListViewModel)SearchGridView.GetFocusedRow();
            if (FocusedRecord == null)
            {
                return;
            }
            var CRUDMTemplateDefaultPara = new CRUDMTemplateParas()
            {
                FormDefaultUI = eFormCurrentUI.Edit,
                EditingRecord = (IDashboardViewModel)FocusedRecord
            };
            object[] CrudFormParas = null;
            object[] CustomParas = GetAddNewFormParameters();
            if (CustomParas != null)
            {
                var list = new List<object> { CRUDMTemplateDefaultPara };
                list.AddRange(CustomParas);
                CrudFormParas = list.ToArray();
            }
            else
            {
                CrudFormParas = new object[] { CRUDMTemplateDefaultPara };
            }

            frmCRUDTemplate newFrm = (frmCRUDTemplate)Activator.CreateInstance(CrudFormType, CrudFormParas);

            newFrm.EditingRecord = (IDashboardViewModel)FocusedRecord;
            newFrm.WindowState = FormWindowState.Normal;
            newFrm.StartPosition = FormStartPosition.CenterScreen;

            if (newFrm.ShowDialog(this) == DialogResult.OK)
            {
                AfterEditRecord(newFrm.SaveResult);
                ReloadSearchData(newFrm.SaveResult?.PrimeKeyValue);
            }
        }

        protected virtual void AfterEditRecord(SavingResult SavingResult)
        {
        }
        #endregion

        private void btnFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockPanelFilter.Visibility = (btnFilter.Down ? DevExpress.XtraBars.Docking.DockVisibility.Visible : DevExpress.XtraBars.Docking.DockVisibility.Hidden);
        }

        private void dockPanelFilter_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            btnFilter.Down = (dockPanelFilter.Visibility != DevExpress.XtraBars.Docking.DockVisibility.Hidden);
        }
    }
}