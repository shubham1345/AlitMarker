using Alit.Marker.DAL.Customer;
using Alit.Marker.Model;
using Alit.Marker.Model.Customer;
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
using Alit.Marker.DAL.Template;

namespace Alit.Marker.WinForm.Customer
{
    public partial class frmCustomerOpeningBalance : Template.frmCRUDTemplate
    {
        CustomerOpeningBalanceDAL DALObject;

        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObject == null)
                {
                    DALObject = new CustomerOpeningBalanceDAL();
                }

                return DALObject;
            }
        }

        CustomerDAL CustomerDALObj;
        long CustomerID;
        CustomerViewModel SelectedCustomer;

        public frmCustomerOpeningBalance() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }, 0) { }

        public frmCustomerOpeningBalance(Model.Template.CRUDMTemplateParas paras, long customerID) : base(paras)
        {
            InitializeComponent();
            FirstControl = txtOpBalAmt;

            DALObject = new CustomerOpeningBalanceDAL();
            CustomerDALObj = new CustomerDAL();

            txtOpeningBalanceDate.EditValue = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;

            ////CommonFunctions.SetCurrencyMask(txtOpBalAmt);

            this.CustomerID = customerID;
        }

        #region Overriden Methods
        protected override void OnLoadFormValues()
        {
            SelectedCustomer = CustomerDALObj.GetViewModelByPrimeKey(CustomerID);
            base.OnLoadFormValues();
        }

        protected override void OnAssignFormValues()
        {
            if(SelectedCustomer != null)
            {
                txtCustomerName.Text = SelectedCustomer.CustomerName;
            }
            base.OnAssignFormValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            if(CustomerID == 0 || SelectedCustomer == null)
            {
                MessageBox.Show("Please select customer.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new CustomerOpeningBalanceViewModel()
            {
                OpBalID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                CustomerID = this.CustomerID,
                OpBalanceDate = (DateTime)txtOpeningBalanceDate.EditValue,
                OpBalanceAmt = (decimal)txtOpBalAmt.EditValue,
                Narration = memoNarration.Text,
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            CustomerOpeningBalanceViewModel ViewModel = (CustomerOpeningBalanceViewModel)RecordToFill;

            txtOpeningBalanceDate.EditValue = ViewModel.OpBalanceDate;
            txtOpBalAmt.EditValue = ViewModel.OpBalanceAmt;
            memoNarration.Text = ViewModel.Narration;

            return base.OnFillSelectedRecordInContent(RecordToFill);
        }
        #endregion

        #region Validation
        private void txtOpBalAmt_Validating(object sender, CancelEventArgs e)
        {
            if (txtOpBalAmt.EditValue == null || (decimal)txtOpBalAmt.EditValue == 0)
            {
                ErrorProvider.SetError(txtOpBalAmt, "Please enter Opening Balance Amt.");
            }
            else
            {
                ErrorProvider.SetError(txtOpBalAmt, null);
            }
        }
        #endregion

    }
}
