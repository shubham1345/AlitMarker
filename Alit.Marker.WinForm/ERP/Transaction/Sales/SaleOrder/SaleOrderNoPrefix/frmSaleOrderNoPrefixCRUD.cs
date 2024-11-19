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
using Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;
using Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix;

namespace Alit.Marker.WinForm.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix
{
    public partial class frmSaleOrderNoPrefix : Template.frmCRUDTemplate
    {
        SaleOrderNoPrefixDAL DALObject;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new SaleOrderNoPrefixDAL();
                }

                return DALObject;
            }
        }

        public frmSaleOrderNoPrefix() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmSaleOrderNoPrefix(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObject = new SaleOrderNoPrefixDAL();
        }

        #region Overriden Method
        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new SaleOrderNoPrefixViewModel()
            {
                SaleOrderNoPrefixID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                PrefixName = txtSaleOrderNoPrefix.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            SaleOrderNoPrefixViewModel EditingRecord = (SaleOrderNoPrefixViewModel)RecordToFill;

            txtSaleOrderNoPrefix.Text = EditingRecord.PrefixName;

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void txtPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSaleOrderNoPrefix.Text))
            {
                ErrorProvider.SetError(txtSaleOrderNoPrefix, "Please enter Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtSaleOrderNoPrefix.Text, (FormCurrentUI == eFormCurrentUI.Edit  && EditingRecord  != null ? EditingRecord.PrimeKeyID : 0)))
            {
                ErrorProvider.SetError(txtSaleOrderNoPrefix, "Can not accept duplicate Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtSaleOrderNoPrefix, null);
            }
        }
        #endregion
    }
}
