using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Template
{
    public abstract class MultiSelectLookupEditListTemplate : Alit.WinformControls.MultiSelectLookupEdit
    {
        protected virtual IMultiSelectLookupListDAL DALObject { get; set; }
        protected virtual IEnumerable<IMultiSelectLookupListViewModel> dsLookup { get; set; }

        EditorButton ButtonComboBox;
        bool ShowComboBoxBttuon_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowComboBoxBttuon
        {
            get
            {
                return ShowComboBoxBttuon_;
            }
            set
            {
                ShowComboBoxBttuon_ = value;
                ButtonComboBox.Visible = value;
            }
        }

        EditorButton ButtonSearch;
        bool ShowSearchBttuon_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowSearchBttuon
        {
            get
            {
                return ShowSearchBttuon_;
            }
            set
            {
                ShowSearchBttuon_ = value;
                ButtonSearch.Visible = value;
            }
        }

        EditorButton ButtonAddNew;
        bool ShowAddNewBttuon_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowAddNewBttuon
        {
            get
            {
                return ShowAddNewBttuon_;
            }
            set
            {
                ShowAddNewBttuon_ = value;
                ButtonAddNew.Visible = value;
            }
        }

        EditorButton ButtonEdit;
        bool ShowEditBttuon_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowEditBttuon
        {
            get
            {
                return ShowEditBttuon_;
            }
            set
            {
                ShowEditBttuon_ = value;
                ButtonEdit.Visible = value;
            }
        }

        EditorButton ButtonSelect;
        bool ShowSelectButton_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowSelectButton
        {
            get
            {
                return ShowSelectButton_;
            }
            set
            {
                ShowSelectButton_ = value;
                ButtonSelect.Visible = value;
            }
        }

        EditorButton ButtonReload;
        bool ShowReloadBttuon_ = true;
        [DefaultValue(true)]
        protected virtual bool ShowReloadBttuon
        {
            get
            {
                return ShowReloadBttuon_;
            }
            set
            {
                ShowReloadBttuon_ = value;
                ButtonReload.Visible = value;
            }
        }
        

        [DefaultValue(false)]
        protected virtual bool ReloadDataSourceAfterSaving { get; set; }

        public MultiSelectLookupEditListTemplate()
        {
             ReloadButtons();
          
        }
        
        private void ReloadButtons()
        {
            this.Properties.Buttons.Clear();

            ButtonComboBox = new EditorButton(ButtonPredefines.Combo);
            this.Properties.Buttons.Add(ButtonComboBox);

            //ButtonSearch = new EditorButton(ButtonPredefines.Search);
            //this.Properties.Buttons.Add(ButtonSearch);

            ButtonAddNew = new EditorButton(ButtonPredefines.Plus);
            this.Properties.Buttons.Add(ButtonAddNew);

            //ButtonEdit = new EditorButton(ButtonPredefines.Up);
            //this.Properties.Buttons.Add(ButtonEdit);

            ButtonSelect = new EditorButton(ButtonPredefines.OK);
            this.Properties.Buttons.Add(ButtonSelect);

            ButtonReload = new EditorButton(ButtonPredefines.Redo);
            this.Properties.Buttons.Add(ButtonReload);         

            DALObject = GetDALObject();
            AssignFormatProperties();
            PopulateColumns();
        }

        protected abstract IMultiSelectLookupListDAL GetDALObject();

        protected virtual void AssignFormatProperties()
        {
        }

        protected virtual void PopulateColumns()
        {
        }

        protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            switch (buttonInfo.Button.Kind)
            {
                case ButtonPredefines.Plus:
                    AddNewRecord();
                    break;
                //case ButtonPredefines.Up:
                //    EditRecord();
                //    break;
                //case ButtonPredefines.Search:
                //    ShowSearchWindow();
                //    break;
                case ButtonPredefines.OK:
                    ClosePopup();
                    break;
                case DevExpress.XtraEditors.Controls.ButtonPredefines.Redo:
                    ReloadDataSource();
                    break;                
            }

            base.OnClickButton(buttonInfo);
        }

        frmCRUDTemplate ParentCRUDForm_;
        [DisplayName("Parent CRUD Form")]
        [DefaultValue(null)]
        public frmCRUDTemplate ParentCRUDForm
        {
            get
            {
                return ParentCRUDForm_;
            }
            set
            {
                // remove events 
                if (ParentCRUDForm_ != null)
                {
                }
                ParentCRUDForm_ = value;

                //attach events 
                if (ParentCRUDForm_ != null)
                {
                    ParentCRUDForm_.LoadLookupDataSource += ParentCRUDForm__LoadLookupDataSource;
                    ParentCRUDForm_.AssignLookupDataSource += ParentCRUDForm__AssignLookupDataSource;
                    ParentCRUDForm_.AfterSaving += ParentCRUDForm__AfterSaving;
                }
            }
        }


        protected override void OnParentChanged(EventArgs e)
        {
            var form = this.FindForm();
            if (form != null && form is frmCRUDTemplate)
            {
                ParentCRUDForm = (frmCRUDTemplate)form;
            }
            base.OnParentChanged(e);
        }

        private void ParentCRUDForm__LoadLookupDataSource(frmCRUDTemplate CRUDForm)
        {
            dsLookup = DALObject.GetMultiSelectLookupList();
        }

        protected override void OnPopupShown()
        {          
            base.OnPopupShown();
        }

        private void ParentCRUDForm__AssignLookupDataSource(frmCRUDTemplate CRUDForm)
        {
            ReloadButtons();
            Properties.DataSource = dsLookup;
            UpdateDisplayText();
        }

        private void ParentCRUDForm__AfterSaving(frmCRUDTemplate CRUDForm, Model.Template.SavingParemeter Paras)
        {
            if (ReloadDataSourceAfterSaving) { ReloadDataSource(); }
        }

        public void ReloadDataSource()
        {
            dsLookup = DALObject.GetMultiSelectLookupList();
            Properties.DataSource = dsLookup;
            UpdateDisplayText();
        }

        public abstract Type CrudFormType { get; }

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
            else
            {
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
                    ReloadDataSource();
                    if (newFrm.SaveResult != null
                        && newFrm.SaveResult.ExecutionResult == eExecutionResult.CommitedSucessfuly
                        && newFrm.SaveResult.PrimeKeyValue != 0)
                    {
                        this.EditValue = newFrm.SaveResult.PrimeKeyValue;
                    }
                }
            }
        }

        protected virtual void AfterAddingRecord(SavingResult SavingResult)
        {
        }

        #endregion

        #region Editing
        protected virtual void EditRecord()
        {
            var SelectedRecord = (ILookupListViewModel)this.GetSelectedDataRow();
            if (SelectedRecord == null)
            {
                return;
            }
            if (CrudFormType == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Can not edit. CrudFormType was not implemented.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                var CRUDMTemplateDefaultPara = new CRUDMTemplateParas()
                {
                    FormDefaultUI = eFormCurrentUI.Edit,
                    EditingRecord = (IDashboardViewModel)SelectedRecord
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

                newFrm.EditingRecord = (IDashboardViewModel)SelectedRecord;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.StartPosition = FormStartPosition.CenterScreen;

                if (newFrm.ShowDialog(this) == DialogResult.OK)
                {
                    AfterEditRecord(newFrm.SaveResult);
                    ReloadDataSource();
                    if (newFrm.SaveResult != null
                        && newFrm.SaveResult.ExecutionResult == eExecutionResult.CommitedSucessfuly
                        && newFrm.SaveResult.PrimeKeyValue != 0)
                    {
                        this.EditValue = newFrm.SaveResult.PrimeKeyValue;
                    }
                }
            }
        }

        protected virtual void AfterEditRecord(SavingResult SavingResult)
        {
        }
        #endregion

        //private void ShowSearchWindow()
        //{
        //    using (frmSearchWindow frmsearch = new frmSearchWindow(dsLookup))
        //    {
        //        if (frmsearch.ShowDialog() == DialogResult.OK)
        //        {
        //            if (frmsearch.SelectedRecord != null)
        //            {
        //                this.EditValue = frmsearch.SelectedRecord.PrimeKeyID;
        //            }
        //        }
        //    }
        //}

        public new List<long> GetSelectedValues()
        {
            if (dsLookup != null)
            {
                return dsLookup.Where(r => r.Selected).Select(r => r.PrimeKeyID).ToList();
            }
            else
            {
                return null;
            }
        }

        public override void SelectAllRows()
        {
            if (dsLookup != null)
            {
                foreach (var r in dsLookup)
                {
                    r.Selected = true;
                }
            }
            else
            {
                base.SelectAllRows();
            }
            RefreshEditValue();
            Refresh();
            UpdateDisplayText();
        }

        public override void DeselectAllRows()
        {
            if (dsLookup != null)
            {
                foreach (var r in dsLookup)
                {
                    r.Selected = false;
                }
            }
            else
            {
                base.DeselectAllRows();
            }
            RefreshEditValue();
            Refresh();
            UpdateDisplayText();
        }

        /// <summary>
        /// Select/Deselect row based on valemember's value
        /// </summary>
        /// <param name="Value">ValueMember Column's value</param>
        /// <param name="Selected">true/false</param>
        public void SelectRow(int PrimeKeyID, bool Selected)
        {
            if(dsLookup != null)
            {
                var Row = dsLookup.FirstOrDefault(r => r.PrimeKeyID == PrimeKeyID);
                if(Row != null)
                {
                    Row.Selected = Selected;
                }
            }
            else
            {
                base.SelectRow(PrimeKeyID, Selected);
            }
        }

        public void SelectRow(List<int> SelectedValues)
        {
            SelectRow(SelectedValues, true);
        }

        public void SelectRow(List<int> SelectedValues, bool Selected)
        {
            if (dsLookup == null) { return; }
            foreach (var r in dsLookup)
            {
                r.Selected = false;
            }

            if (SelectedValues != null)
            {
                foreach (var SelectedID in SelectedValues)
                {
                    var row = dsLookup.FirstOrDefault(rr => rr.PrimeKeyID == SelectedID);
                    if (row != null)
                    {
                        row.Selected = Selected;
                    }
                }
            }

            UpdateDisplayText();
        }

        public override string GetDisplayText()
        {
            if(dsLookup != null)
            {
                var SelectedRows = dsLookup.Where(r => r.Selected);
                if(SelectedRows.Count() == 0)
                {
                    return null;
                }

                var DisplayMemberPropInfo = SelectedRows.First().GetType().GetProperties().FirstOrDefault(r => r.Name == this.Properties.DisplayMember);
                if(DisplayMemberPropInfo == null)
                {
                    return null;
                }
                return string.Join(", ", SelectedRows.Select(r => DisplayMemberPropInfo.GetValue(r)?.ToString()).Where(r => r != null));
            }
            else
            {
                return base.GetDisplayText();
            }
        }
    }
}
