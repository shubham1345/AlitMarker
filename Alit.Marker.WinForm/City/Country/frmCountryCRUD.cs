using Alit.Marker.DAL.City.Country;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model.City.Country;
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

namespace Alit.Marker.WinForm.City.Country
{
    public partial class frmCountryCRUD : Template.frmCRUDTemplate
    {
        CountryDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new CountryDAL();
                }
                return DALObject;
            }
        }

        public frmCountryCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmCountryCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new CountryDAL();           
        }

        #region Override Methods

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new CountryViewModel()
            {
                CountryID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                CountryName = txtCountryName.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            CountryViewModel ViewModel = (CountryViewModel)RecordToFill;
            txtCountryName.Text = ViewModel.CountryName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation

        private void txtCountryName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCountryName.Text))
            {
                ErrorProvider.SetError(txtCountryName, "Please enter Country Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtCountryName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtCountryName, "Can not accept duplicate Country Name.");
            }
            else
            {
                ErrorProvider.SetError(txtCountryName, null);
            }
        }

        #endregion
    }
}
