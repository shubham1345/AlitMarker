using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Template
{
    public abstract class LookupEditListTemplate : Alit.WinformControls.LookUpEdit
    {
        protected virtual ILookupListDAL DALObject { get; set; }
        protected virtual IEnumerable<Model.Template.ILookupListViewModel> dsLookup { get; set; }

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

        //EditorButton ButtonAddNew;
        //bool ShowAddNewBttuon_ = true;
        //[DefaultValue(true)]
        //protected virtual bool ShowAddNewBttuon
        //{
        //    get
        //    {
        //        return ShowAddNewBttuon_;
        //    }
        //    set
        //    {
        //        ShowAddNewBttuon_ = value;
        //        ButtonAddNew.Visible = value;
        //    }
        //}

        //EditorButton ButtonEdit;
        //bool ShowEditBttuon_ = true;
        //[DefaultValue(true)]
        //protected virtual bool ShowEditBttuon
        //{
        //    get
        //    {
        //        return ShowEditBttuon_;
        //    }
        //    set
        //    {
        //        ShowEditBttuon_ = value;
        //        ButtonEdit.Visible = value;
        //    }
        //}

        //EditorButton ButtonReload;
        //bool ShowReloadBttuon_ = true;
        //[DefaultValue(true)]
        //protected virtual bool ShowReloadBttuon
        //{
        //    get
        //    {
        //        return ShowReloadBttuon_;
        //    }
        //    set
        //    {
        //        ShowReloadBttuon_ = value;
        //        ButtonReload.Visible = value;
        //    }
        //}

        [DefaultValue(false)]
        protected virtual bool ReloadDataSourceAfterSaving { get; set; }

        [DefaultValue(null)]
        public string SearchWindowCaption { get; set; }

        protected LookupEditListTemplate()
        {
            ButtonComboBox = new EditorButton(ButtonPredefines.Combo);
            this.Properties.Buttons.Add(ButtonComboBox);

            ButtonSearch = new EditorButton(ButtonPredefines.Search);
            ButtonSearch.Shortcut = new DevExpress.Utils.KeyShortcut(Keys.Control | Keys.F);
            this.Properties.Buttons.Add(ButtonSearch);

            //ButtonAddNew = new EditorButton(ButtonPredefines.Plus);
            //this.Properties.Buttons.Add(ButtonAddNew);

            //ButtonEdit = new EditorButton(ButtonPredefines.Up);
            //this.Properties.Buttons.Add(ButtonEdit);

            //ButtonReload = new EditorButton(ButtonPredefines.Redo);
            //this.Properties.Buttons.Add(ButtonReload);

            DALObject = GetDALObject();
            AssignFormatProperties();
            PopulateColumns();
        }

        protected override void OnLoaded()
        {
            if (!this.Properties.Buttons.Any(r => r.Kind == ButtonPredefines.Search))
            {
                this.Properties.Buttons.Add(ButtonSearch);
            }
            else
            {
                ButtonSearch = this.Properties.Buttons.FirstOrDefault(r => r.Kind == ButtonPredefines.Search);
                if (ButtonSearch != null)
                {
                    ButtonSearch.Shortcut = new DevExpress.Utils.KeyShortcut(Keys.Control | Keys.F);
                }
            }
            base.OnLoaded();
        }

        protected abstract ILookupListDAL GetDALObject();

        protected virtual void AssignFormatProperties()
        {
            //this.Properties.DisplayMember = "CustomerName";
            //this.Properties.ValueMember = "CustomerID";
            //this.Properties.DropDownRows = 15;
            //this.Properties.ImmediatePopup = true;
            //this.Properties.NullText = "Select Customer";
            //this.Properties.PopupWidth = 1000;
            //--        
        }

        protected virtual void PopulateColumns()
        {
        }

        protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            switch (buttonInfo.Button.Kind)
            {
                //case ButtonPredefines.Plus:
                //    AddNewRecord();
                //    break;
                //case ButtonPredefines.Up:
                //    EditRecord();
                //    break;
                case ButtonPredefines.Search:
                    ShowSearchWindow();
                    break;
                case ButtonPredefines.Redo:
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
                //// remove events 
                if (ParentCRUDForm_ != null)
                {
                    ParentCRUDForm_.LoadLookupDataSource -= ParentCRUDForm_LoadLookupDataSource;
                    ParentCRUDForm_.AssignLookupDataSource -= ParentCRUDForm_AssignLookupDataSource;
                    ParentCRUDForm_.AfterSaving -= ParentCRUDForm_AfterSaving;
                }

                ParentCRUDForm_ = value;

                //attach events 
                if (ParentCRUDForm_ != null)
                {
                    ParentCRUDForm_.LoadLookupDataSource += ParentCRUDForm_LoadLookupDataSource;
                    ParentCRUDForm_.AssignLookupDataSource += ParentCRUDForm_AssignLookupDataSource;
                    ParentCRUDForm_.AfterSaving += ParentCRUDForm_AfterSaving;
                }
            }
        }


        protected override void OnParentChanged(EventArgs e)
        {
            // the below casting method prevent exception to be thrown if the casting object is null.
            ParentCRUDForm = this.FindForm() as frmCRUDTemplate;
            base.OnParentChanged(e);
        }

        protected virtual IEnumerable<ILookupListViewModel> GetLookupList()
        {
            if (DALObject != null)
            {
                return DALObject.GetLookupList(GetLookupListFilterParas());
            }
            else
            {
                // can not initliaze empty collection.
                return null;
            }
        }

        protected virtual object[] GetLookupListFilterParas()
        {
            return null;
        }

        private void ParentCRUDForm_LoadLookupDataSource(frmCRUDTemplate CRUDForm)
        {
            dsLookup = GetLookupList();
        }

        private void ParentCRUDForm_AssignLookupDataSource(frmCRUDTemplate CRUDForm)
        {
            Properties.DataSource = dsLookup;
        }

        public virtual void LoadDataSource()
        {
            dsLookup = DALObject.GetLookupList(GetLookupListFilterParas());
        }

        public virtual void AssignDataSource()
        {
            Properties.DataSource = dsLookup;
        }

        private void ParentCRUDForm_AfterSaving(frmCRUDTemplate CRUDForm, Model.Template.SavingParemeter Paras)
        {
            if (ReloadDataSourceAfterSaving) { ReloadDataSource(); }
        }

        public void ReloadDataSource()
        {
            dsLookup = DALObject.GetLookupList(GetLookupListFilterParas());
            Properties.DataSource = dsLookup;
        }

        public abstract Type CrudFormType { get; }

        protected virtual void ShowSearchWindow()
        {
            string windowCaption = SearchWindowCaption;
            if (String.IsNullOrWhiteSpace(windowCaption))
            {
                windowCaption = ((LayoutControl)this.Parent).Items.OfType<LayoutControlItem>().FirstOrDefault(r => r.Control == this)?.Text;
            }

            using (frmDefaultSearchWindow frmsearch = new frmDefaultSearchWindow(CrudFormType, DALObject, dsLookup, this.GetSelectedDataRow() as ILookupListViewModel, windowCaption))
            {
                if (frmsearch.ShowDialog() == DialogResult.OK && frmsearch.SelectedRecord != null)
                {
                    if (frmsearch.LookupDataSourceHasChanges)
                    {
                        this.Properties.DataSource = dsLookup = frmsearch.LookupDataSource;
                    }
                    this.EditValue = frmsearch.SelectedRecord?.PrimeKeyID;
                }
            }
        }
    }
}
