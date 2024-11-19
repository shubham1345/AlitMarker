using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public class MultiSelectLookupEdit : GridLookUpEdit
    {
       
        private GridView fPropertiesView;

        public MultiSelectLookupEdit()
        {
            this.EnterMoveNextControl = true;
            this.CustomDisplayText += multiSelectLookupEdit_CustomDisplayText;
            this.CloseUp += MultiSelectLookupEdit_CloseUp;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            // if you want keyboard interface for selection in grid. uncomment below line
            this.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoComplete;

            // to able keyboard interface comment below line
            this.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;

            if (this.Properties.PopupView is GridView)
            {
                this.Properties.View.KeyDown += GridView_KeyDown;
                this.Properties.View.OptionsSelection.MultiSelect = true;
                this.Properties.View.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
                this.Properties.View.OptionsSelection.CheckBoxSelectorField = "Selected";
                this.Properties.View.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                this.Properties.View.OptionsView.ShowIndicator = false;
                this.Properties.View.OptionsBehavior.Editable = true;
                this.Properties.View.OptionsBehavior.ReadOnly = false;
            }
        }

        private void MultiSelectLookupEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            UpdateDisplayText();
        }

        private void multiSelectLookupEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = GetDisplayText();
        }

        /// grid view doesn't allow keyboard intereface that's why this code is not required. 
        /// May be later deveexpress allow keyboard interface then we will select
        private void GridView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {

                if (this.Properties.View.GetFocusedRow() != null)
                {
                    bool Selected = false;
                    var SelectorValue = this.Properties.View.GetFocusedRowCellValue(this.Properties.View.OptionsSelection.CheckBoxSelectorField);
                    if (SelectorValue != null && SelectorValue is bool)
                    {
                        Selected = (bool)SelectorValue;
                    }
                    this.Properties.View.SetFocusedRowCellValue(this.Properties.View.OptionsSelection.CheckBoxSelectorField, !Selected);
                    this.Properties.View.UpdateCurrentRow();
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        public virtual int GetRowCount()
        {
            int RowCount = 0;
            if (this.Properties.View.DataSource != null)
            {
                if (this.Properties.View.DataSource is BindingSource)
                {
                    RowCount = ((BindingSource)this.Properties.View.DataSource).Count;
                }
                else if (this.Properties.View.DataSource is System.Collections.ICollection)
                {
                    RowCount = ((System.Collections.ICollection)this.Properties.View.DataSource).Count;
                }
            }
            else
            {
                RowCount = this.Properties.View.DataRowCount;
            }
            return RowCount;
        }

        /// <summary>
        /// Get text to display in textedit container
        /// </summary>
        /// <returns></returns>
        public virtual string GetDisplayText()
        {
            string displayText = "";

            int RowCount = GetRowCount();
            for (int i = 0; i < RowCount; i++)
            {
                var SelectValue = this.Properties.View.GetListSourceRowCellValue(i, Properties.View.OptionsSelection.CheckBoxSelectorField);

                if (SelectValue != null && SelectValue is bool && (bool)SelectValue)
                {
                    var DisplayValue = this.Properties.View.GetListSourceRowCellValue(i, Properties.DisplayMember);
                    if (DisplayValue != null)
                    {
                        var DisplayText = DisplayValue.ToString();
                        if (!String.IsNullOrWhiteSpace(DisplayText))
                        {
                            displayText += (!String.IsNullOrWhiteSpace(displayText) ? ", " : "") + DisplayText;
                        }
                    }
                }
            }
            return displayText;
        }

        public new void UpdateDisplayText()
        {
            this.Text = GetDisplayText();
            base.UpdateDisplayText();
        }

        /// <summary>
        /// Get values of ValueMember columns for all selected rows.
        /// </summary>
        /// <returns></returns>
        public virtual List<object> GetSelectedValues()
        {
            int RowCount = GetRowCount();

            List<object> SelectedValues = new List<object>();
            for (int i = 0; i < RowCount; i++)
            {
                var SelectValue = this.Properties.View.GetListSourceRowCellValue(i, Properties.View.OptionsSelection.CheckBoxSelectorField);

                if (SelectValue != null && SelectValue is bool && (bool)SelectValue)
                {
                    var Value = this.Properties.View.GetListSourceRowCellValue(i, Properties.ValueMember);
                    if (Value != null)
                    {
                        SelectedValues.Add(Value);
                    }
                }
            }
            return SelectedValues;
        }

        /// <summary>
        /// Select/Deselect row based on valemember's value
        /// </summary>
        /// <param name="Value">ValueMember Column's value</param>
        public virtual void SelectRow(object Value)
        {
            SelectRow(Value, true);
        }

        /// <summary>
        /// Select/Deselect row based on valemember's value
        /// </summary>
        /// <param name="Value">ValueMember Column's value</param>
        /// <param name="Selected">true/false</param>
        public virtual void SelectRow(object Value, bool Selected)
        {
            if (Value != null)
            {
                int RowCount = GetRowCount();
                int RowIndex = -1;
                for (int i = 0; i < RowCount; i++)
                {
                    var CurrentValue = this.Properties.View.GetListSourceRowCellValue(i, Properties.ValueMember);
                    if (CurrentValue != null && CurrentValue == Value)
                    {
                        RowIndex = i;
                        break;
                    }
                }
                if (RowIndex == -1) { return; }

                int rh = this.Properties.View.GetRowHandle(RowIndex);
                this.Properties.View.SetRowCellValue(rh, this.Properties.View.OptionsSelection.CheckBoxSelectorField, Selected);
                UpdateDisplayText();
            }
        }

        /// <summary>
        /// Mark rows selected based on given values of ValueMember column
        /// </summary>
        public virtual void SelectRow(List<object> Values)
        {
            SelectRow(Values, true);
        }

        /// <summary>
        /// Mark rows selected based on given values of ValueMember column
        /// </summary>
        /// <param name="Values"></param>
        /// <param name="Selected"></param>
        public virtual void SelectRow(List<object> Values, bool Selected)
        {
            int RowCount = GetRowCount();

            for (int i = 0; i < RowCount; i++)
            {
                var Value = this.Properties.View.GetListSourceRowCellValue(i, Properties.ValueMember);
                if (Value != null && Values.Contains(Value))
                {
                    int rh = this.Properties.View.GetRowHandle(i);
                    this.Properties.View.SetRowCellValue(rh, this.Properties.View.OptionsSelection.CheckBoxSelectorField, Selected);
                }
            }
            RefreshEditValue();
            Refresh();
            UpdateDisplayText();
        }

        public virtual void SelectAllRows()
        {
            int RowCount = GetRowCount();

            for (int i = 0; i < RowCount; i++)
            {
                var Value = this.Properties.View.GetListSourceRowCellValue(i, Properties.ValueMember);
                if (Value != null)
                {
                    int rh = this.Properties.View.GetRowHandle(i);
                    this.Properties.View.SetRowCellValue(rh, this.Properties.View.OptionsSelection.CheckBoxSelectorField, true);
                }
            }
            RefreshEditValue();
            Refresh();
            UpdateDisplayText();
        }

        public virtual void DeselectAllRows()
        {
            int RowCount = GetRowCount();

            for (int i = 0; i < RowCount; i++)
            {
                var Value = this.Properties.View.GetListSourceRowCellValue(i, Properties.ValueMember);
                if (Value != null)
                {
                    int rh = this.Properties.View.GetRowHandle(i);
                    this.Properties.View.SetRowCellValue(rh, this.Properties.View.OptionsSelection.CheckBoxSelectorField, false);
                }
            }
            RefreshEditValue();
            Refresh();
            UpdateDisplayText();
        }

        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.fPropertiesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            fProperties.Name = "fProperties";
            fProperties.PopupView = this.fPropertiesView;
            // 
            // fPropertiesView
            // 
            this.fPropertiesView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.fPropertiesView.Name = "fPropertiesView";
            this.fPropertiesView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fPropertiesView.OptionsView.ShowGroupPanel = false;
            // 
            // MultiSelectLookupEdit
            // 
            this.Size = new System.Drawing.Size(100, 22);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
