using Alit.Marker.DAL.Settings.FinancialPeriod;
using Alit.Marker.DAL.Template;
using Alit.Marker.Model;
using Alit.Marker.Model.Settings.FinancialPeriod;
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

namespace Alit.Marker.WinForm.Settings.FinancialPeriod
{
    public partial class frmFinancialPeriodCRUD : Template.frmCRUDTemplate
    {
        FinPeriodDAL DALObj;
        protected override ICRUDDAL CrudDALObj
        {
            get
            {
                if (DALObj == null)
                {
                    DALObj = new FinPeriodDAL();
                }

                return DALObj;
            }
        }

        public frmFinancialPeriodCRUD() : this(new Model.Template.CRUDMTemplateParas() { FormDefaultUI = Model.Template.eFormCurrentUI.NewEntry }) { }

        public frmFinancialPeriodCRUD(Model.Template.CRUDMTemplateParas paras) : base(paras)
        {
            InitializeComponent();
            DALObj = new FinPeriodDAL();
        }

        FinPeriodDetailModel PrevFinPeriod = null;
        FinPeriodDetailModel NextFinPeriod = null;
        bool IsSaving = false;

        #region Overridden Methods
        protected override void OnClearValues()
        {
            IsSaving = false;
            base.OnClearValues();
        }

        protected async override void OnInitializeDefaultValues()
        {
            PrevFinPeriod = null;
            NextFinPeriod = null;

            deStartDate.Enabled = true;
            deEndDate.Enabled = true;

            lcgCustomerBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgProductStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            splitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            if (FormCurrentUI == eFormCurrentUI.NewEntry)
            {
                PrevFinPeriod = DALObj.GetLatestFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                if (PrevFinPeriod != null)
                {
                    lblPrevFinPeriod.Text = PrevFinPeriod.FinPeriodFrom.ToShortDateString() + " - ";
                    if (PrevFinPeriod.FinPeriodTo != null)
                    {
                        lblPrevFinPeriod.Text = lblPrevFinPeriod.Text + PrevFinPeriod.FinPeriodTo.Value.ToShortDateString();

                        deStartDate.EditValue = null;
                        deStartDate.EditValue = PrevFinPeriod.FinPeriodTo.Value.Date.AddDays(1).Date;
                        deStartDate.Enabled = false;
                    }
                    else
                    {
                        lblPrevFinPeriod.Text = lblPrevFinPeriod.Text + "*";
                    }

                    //-- Calculate Customer's Balances
                    gridControlCustomerBalance.DataSource = await DALObj.GetCustomerClosingBalance(PrevFinPeriod.CompanyID, PrevFinPeriod.FinPeriodID);
                    gridviewCustomerBalance.Columns["CustomerNo"].Width = 100;
                    gridviewCustomerBalance.Columns["CustomerName"].Width = 300;
                    gridviewCustomerBalance.Columns["CompanyName"].Width = 200;
                    gridviewCustomerBalance.Columns["Address"].Width = 150;
                    gridviewCustomerBalance.Columns["City"].Width = 100;
                    gridviewCustomerBalance.Columns["MobileNo"].Width = 100;
                    gridviewCustomerBalance.Columns["OpeningBalance"].Width = 100;


                    gridcontrolProductStock.DataSource = await DALObj.GetProductOpeningBalance(PrevFinPeriod.CompanyID, PrevFinPeriod.FinPeriodID);
                    gridviewProductStock.Columns["ProductCode"].Width = 100;
                    gridviewProductStock.Columns["ProductName"].Width = 300;
                    gridviewProductStock.Columns["Stock"].Width = 100;
                    gridviewProductStock.Columns["UnitName"].Width = 100;


                    lcgCustomerBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgProductStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    splitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }

            base.OnInitializeDefaultValues();
        }

        protected override bool OnValidateBeforeSave()
        {
            IsSaving = true;
            return base.OnValidateBeforeSave();
        }

        protected override ICRUDViewModel OnGetViewModelForSaving()
        {
            return new Model.Settings.FinancialPeriod.FinPeriodViewModel()
            {
                FinPeriodID = (FormCurrentUI == eFormCurrentUI.Edit && EditingRecord != null ? EditingRecord.PrimeKeyID : 0),
                FinPeriodName = txtFinPerName.Text,
                FinPeriodFrom = (DateTime)deStartDate.EditValue,
                FinPeriodTo = (DateTime?)deEndDate.EditValue,
                CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,

                OpeningBalance = (chkTransferCustomerOpeningBalance.Checked ? (List<CustomerClosingBalanceViewModel>)gridControlCustomerBalance.DataSource : null),

                OpeningStock = (chkTransferProductStock.Checked ? (List<ProductOpeningStockViewModel>)gridcontrolProductStock.DataSource : null),

                PreviousFinancialPeriod = PrevFinPeriod,
                NextFinancialPeriod = NextFinPeriod,
                
            };
        }

        protected override eFillSelectedRecordInContentFlag OnFillSelectedRecordInContent(ICRUDViewModel RecordToFill)
        {
            FinPeriodViewModel EditingRecord = (FinPeriodViewModel)RecordToFill;

            txtFinPerName.Text = EditingRecord.FinPeriodName;

            deStartDate.EditValue = null;
            deStartDate.EditValue = EditingRecord.FinPeriodFrom;
            deEndDate.EditValue = null;
            if(EditingRecord.FinPeriodTo.HasValue)
            {
                deEndDate.EditValue = EditingRecord.FinPeriodTo.Value;
            }

            PrevFinPeriod = DALObj.GetPreviousFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, EditingRecord.FinPeriodFrom);

            deStartDate.Enabled = (PrevFinPeriod == null);
            
            if (EditingRecord.FinPeriodTo == null)
            {
                NextFinPeriod = null;
            }
            else
            {
                NextFinPeriod = DALObj.GetNextFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, EditingRecord.FinPeriodTo.Value);
            }

            deEndDate.Enabled = (NextFinPeriod == null);

            return eFillSelectedRecordInContentFlag.FilledSuccessfully;
        }
        #endregion

        #region Validation
        private void textFinPerName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFinPerName.Text))
            {
                ErrorProvider.SetError(txtFinPerName, "Please enter Financial Period Name.");
            }
            else
            {
                ErrorProvider.SetError(txtFinPerName, null);
            }
        }

        private void deStartDate_Validating(object sender, CancelEventArgs e)
        {
            if(deStartDate.EditValue == null)
            {
                ErrorProvider.SetError(deStartDate, "Please select Date From.");
            }
            else if(FormCurrentUI == Model.Template.eFormCurrentUI.NewEntry &&
                    PrevFinPeriod != null &&
                (
                    (DateTime)deStartDate.EditValue <= PrevFinPeriod.FinPeriodFrom ||
                    (PrevFinPeriod.FinPeriodTo.HasValue && (DateTime)deStartDate.EditValue <= PrevFinPeriod.FinPeriodTo.Value))
                
                )
            {
                ErrorProvider.SetError(deStartDate, "Financial Period should start after previous Financial Period.");
            }
            else 
            {
                ErrorProvider.SetError(deStartDate, null);
                if (!IsSaving)
                {
                    txtFinPerName.Text = ((DateTime)deStartDate.EditValue).Date.Year.ToString() + " - " +
                        (deEndDate.EditValue == null ? "*" : ((DateTime)deEndDate.EditValue).Date.Year.ToString());
                }
            }
        }

        private void deEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (deStartDate.EditValue != null)
            {
                if (deEndDate.EditValue != null && (DateTime)deEndDate.EditValue < (DateTime)deStartDate.EditValue)
                {
                    ErrorProvider.SetError(deEndDate, "Date To should be greater than From Date.");
                }
                else if(!IsSaving)
                {
                    ErrorProvider.SetError(deEndDate, null);
                    if (!IsSaving)
                    {
                        txtFinPerName.Text = ((DateTime)deStartDate.EditValue).Date.Year.ToString() + " - " +
                            (deEndDate.EditValue == null ? "*" : ((DateTime)deEndDate.EditValue).Date.Year.ToString());
                    }
                }
            }
            else
            {
                ErrorProvider.SetError(deEndDate, "Please select From Date.");
            }
        }
        #endregion
        
    }
}
