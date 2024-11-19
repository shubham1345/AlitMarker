using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.DAL.Inventory.Masters.Unit;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Inventory.Masters.Unit;
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

namespace Alit.Marker.WinForm.Inventory.Masters.Unit
{
    public partial class frmUnitCRUD : Template.frmCRUDTemplate
    {
        UnitDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new UnitDAL();
                }

                return DALObject;
            }
        }

        public frmUnitCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmUnitCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new UnitDAL();
        }

        #region Overriden Method

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new UnitViewModel()
            {
                UnitID = (FormCurrentUI == eFormCurrentUI.NewEntry && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                UnitName = txtUnitName.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            UnitViewModel EditingRecord = (UnitViewModel)RecordToFill;

            txtUnitName.Text = EditingRecord.UnitName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation

        private void txtUnitName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                ErrorProvider.SetError(txtUnitName, "Please enter Unit Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtUnitName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtUnitName, "Can not accept duplicate Unit Name.");
            }
            else
            {
                ErrorProvider.SetError(txtUnitName, null);
            }
        }

        #endregion
    }
}
