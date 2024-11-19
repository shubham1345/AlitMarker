using Alit.Marker.Model;
using DevExpress.XtraEditors;
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
using Alit.Marker.Model.Inventory.Masters.Product;
using Alit.Marker.DAL.Inventory.Masters.Product;
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Inventory.Masters.Product
{
    public partial class frmPriceListCRUD : Template.frmCRUDTemplate
    {
        PriceListDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new PriceListDAL();
                }
                return DALObject;
            }
        }

        public frmPriceListCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmPriceListCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new PriceListDAL();
        }

        #region Overriden Method

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new PriceListViewModel()
            {
                PriceListName = txtPriceListName.Text,
                PriceListShortName = txtPriceListShortName.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            PriceListViewModel EditingRecord = (PriceListViewModel)RecordToFill;

            txtPriceListName.Text = EditingRecord.PriceListName;
            txtPriceListShortName.Text = EditingRecord.PriceListShortName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }

        #endregion

        #region Validation
        private void txtPriceListName_Validating(object sender, CancelEventArgs e)
       { 
            if (String.IsNullOrWhiteSpace(txtPriceListName.Text))
            {
                ErrorProvider.SetError(txtPriceListName, "Please enter Price List Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtPriceListName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPriceListName, "Can not accept duplicate Price List Name.");
            }
            else
            {
                ErrorProvider.SetError(txtPriceListName, null);
            }
        }

        private void txtPriceListShortName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPriceListShortName.Text))
            {
                ErrorProvider.SetError(txtPriceListShortName, "Please enter Price List Short Name.");
            }
            else if (DALObject.IsDuplicateShortName(txtPriceListShortName.Text, (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtPriceListShortName, "Can not accept duplicate Price List Short Name.");
            }
            else
            {
                ErrorProvider.SetError(txtPriceListShortName, null);
            }
        }
        #endregion

    }

    public static class PriceListLookupFormatter
    {
        public static void FormatLookupLost(LookUpEdit LookupControl)
        {
            LookupControl.Properties.NullText = "[Select Price List]";
        }
    }
}
