using Alit.Marker.DAL.City.State;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.City.State;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.City.State
{
    public partial class frmStateCRUD : Template.frmCRUDTemplate
    {
        StateDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new StateDAL();
                }
                return DALObject;
            }
        }

        public frmStateCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmStateCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new StateDAL();
        }

        #region Override Methods

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new StateViewModel()
            {
                StateID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                StateName = txtStateName.Text,
                CountryID = (long)lueCountry.EditValue,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            StateViewModel ViewModel = (StateViewModel)RecordToFill;

            txtStateName.Text = ViewModel.StateName;
            lueCountry.EditValue = ViewModel.CountryID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtStateName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtStateName.Text))
            {
                ErrorProvider.SetError(txtStateName, "Please enter State Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtStateName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtStateName, "Can not accept duplicate State Name.");
            }
            else
            {
                ErrorProvider.SetError(txtStateName, null);
            }
        }

        private void lueCountry_Validating(object sender, CancelEventArgs e)
        {
            if (lueCountry.EditValue == null)
            {
                ErrorProvider.SetError(lueCountry, "Please select Country.");
            }
            else
            {
                ErrorProvider.SetError(lueCountry, null);
            }
        }
        #endregion
    }
}
