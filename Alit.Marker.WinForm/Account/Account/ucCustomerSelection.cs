using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.WinForm.Template;
using Alit.Marker.Model.Account.Account;

namespace Alit.Marker.WinForm.Account.Account
{
    public partial class ucCustomerSelection : UserControl
    {
        public ucCustomerSelection()
        {
            InitializeComponent();
        }

        //public event EventHandler CustomerIDChanged;

        [DefaultValue(0)]
        public long CustomerID
        {
            get
            {
                return (long?)lookupEditAccount1.EditValue ?? 0;
            }
            set
            {
                lookupEditAccount1.EditValue = value;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            var form = this.FindForm();
            if (form != null && form is frmCRUDTemplate)
            {
                lookupEditAccount1.ParentCRUDForm = (frmCRUDTemplate)form;
            }
            base.OnParentChanged(e);
        }
        
        //bool CustomerNoChanging;
        //private void txtCustomerNo_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (IsLookupCustomerEditValueChanging) { return; }

        //    CustomerNoChanging = true;
        //    long v = (long)txtCustomerNo.EditValue;
        //    if (lookupListCustomer1.Properties.DataSource != null)
        //    {
        //        var customer = ((List<Model.Customer.CustomerLookUpListModel>)lookupListCustomer1.Properties.DataSource).FirstOrDefault(r => r.CustomerNo == v);
        //        if (customer != null)
        //        {
        //            lookupListCustomer1.EditValue = customer.CustomerID;
        //        }
        //        else
        //        {
        //            lookupListCustomer1.EditValue = null;
        //        }
        //    }
        //    else
        //    {
        //        lookupListCustomer1.EditValue = null;
        //    }
        //    CustomerNoChanging = false;
        //}

        //bool IsLookupCustomerEditValueChanging;
        //private void lookupCustomer_EditValueChanged(object sender, EventArgs e)
        //{
        //    IsLookupCustomerEditValueChanging = true;
        //    FillCustomerInfoInControls();
        //    IsLookupCustomerEditValueChanging = false;

        //    CustomerIDChanged?.Invoke(this, new EventArgs());
        //}

        //public void FillCustomerInfoInControls()
        //{
        //    //txtBalance.EditValue = null;
        //    if (lookupEditAccount1.EditValue != null)
        //    {
        //        AccountLookUpListModel SelectedCustomer = (AccountLookUpListModel)lookupEditAccount1.GetSelectedDataRow();
        //        if (SelectedCustomer != null)
        //        {
        //            //if (!CustomerNoChanging)
        //            //{
        //            //    txtCustomerNo.EditValue = SelectedCustomer.CustomerNo;
        //            //}
        //            //txtGSTNo.Text = SelectedCustomer.GSTNo;
        //            //txtBalance.EditValue = DAL.Customer.CustomerBalanceDAL.GetBalance(SelectedCustomer.CustomerID);
        //        }
        //    }
        //}

        public AccountLookUpListModel GetSelectedRecord()
        {
            return (AccountLookUpListModel)lookupEditAccount1.GetSelectedDataRow();
        }

        [DefaultValue(null)]
        [DisplayName("Lookup Account Filter")]
        public LookupEditAccount LookupEditAccountFilter { get { return lookupEditAccount1; } }
    }
}


