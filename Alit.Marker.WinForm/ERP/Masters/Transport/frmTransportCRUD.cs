using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.ERP.Masters.Transport;
using Alit.Marker.DAL.ERP.Masters.Transport;

namespace Alit.Marker.WinForm.ERP.Masters.Transport
{
    public partial class frmTransportCRUD : Template.frmCRUDTemplate
    {
        TransportDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new TransportDAL();
                }

                return DALObject;
            }
        }

        public frmTransportCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmTransportCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new TransportDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new TransportViewModel()
            {
                TransportID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                TransportName = txtTransportName.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            TransportViewModel EditingRecord = (TransportViewModel)RecordToFill;
            txtTransportName.Text = EditingRecord.TransportName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtTransportName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTransportName.Text))
            {
                ErrorProvider.SetError(txtTransportName, "Please enter Transport Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtTransportName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtTransportName, "Can not accept duplicate Transport Name.");
            }
            else
            {
                ErrorProvider.SetError(txtTransportName, null);
            }
        }

        #endregion
    }
}
