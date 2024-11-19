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
using Alit.Marker.Model.City.City;
using Alit.Marker.Model;
using Alit.Marker.DAL.City.City;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.Template;

namespace Alit.Marker.WinForm.City.City
{
    public partial class frmCityCRUD : Template.frmCRUDTemplate
    {
        CityDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new CityDAL();
                }

                return DALObject;
            }
        }

        public frmCityCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmCityCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new CityDAL();
        }

        #region Overriden Methods

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new CityViewModel()
            {
                CityName = txtCityName.Text,
                StateID = (long?)lueState.EditValue,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            CityViewModel EditingRecord = (CityViewModel)RecordToFill;

            txtCityName.Text = EditingRecord.CityName;
            lueState.EditValue = EditingRecord.StateID;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCityName.Text))
            {
                ErrorProvider.SetError(txtCityName, "Please enter City Name.");
            }            
            else if (DALObject.IsDuplicateRecord(txtCityName.Text, (lueState.EditValue != null ? (long?)lueState.EditValue : 0),
                   (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0) ))
            {
                ErrorProvider.SetError(txtCityName, "Can not accept duplicate City Name.");
            }
            else
            {
                ErrorProvider.SetError(txtCityName, null);
            }
        }

        private void lueState_Validating(object sender, CancelEventArgs e)
        {
            if (lueState.EditValue == null)
            {
                ErrorProvider.SetError(lueState, "Please select State.");
            }
            else
            {
                ErrorProvider.SetError(lueState, null);
            }
        }
        #endregion

    }
}