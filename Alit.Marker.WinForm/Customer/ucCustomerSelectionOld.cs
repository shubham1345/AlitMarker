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
using Alit.Marker.Model.Customer;

namespace Alit.Marker.WinForm.Customer
{
    public partial class ucCustomerSelectionOld : UserControl
    {
        public ucCustomerSelectionOld()
        {
            InitializeComponent();
        }

        public event EventHandler CustomerIDChanged;

        [DefaultValue(0)]
        public long CustomerID
        {
            get
            {
                return (long?)lookupListCustomer1.EditValue ?? 0;
            }
            set
            {
                lookupListCustomer1.EditValue = value;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            var form = this.FindForm();
            if (form != null && form is frmCRUDTemplate)
            {
                lookupListCustomer1.ParentCRUDForm = (frmCRUDTemplate)form;
            }
            base.OnParentChanged(e);
        }

        bool CustomerNoChanging;
        private void txtCustomerNo_EditValueChanged(object sender, EventArgs e)
        {
            if (IsLookupCustomerEditValueChanging) { return; }

            CustomerNoChanging = true;
            long v = (long)txtCustomerNo.EditValue;
            if (lookupListCustomer1.Properties.DataSource != null)
            {
                var customer = ((List<Model.Customer.CustomerLookUpListModel>)lookupListCustomer1.Properties.DataSource).FirstOrDefault(r => r.CustomerNo == v);
                if (customer != null)
                {
                    lookupListCustomer1.EditValue = customer.CustomerID;
                }
                else
                {
                    lookupListCustomer1.EditValue = null;
                }
            }
            else
            {
                lookupListCustomer1.EditValue = null;
            }
            CustomerNoChanging = false;
        }

        bool IsLookupCustomerEditValueChanging;
        private void lookupCustomer_EditValueChanged(object sender, EventArgs e)
        {
            IsLookupCustomerEditValueChanging = true;
            FillCustomerInfoInControls();
            IsLookupCustomerEditValueChanging = false;

            CustomerIDChanged?.Invoke(this, new EventArgs());
        }

        public void FillCustomerInfoInControls()
        {
            txtBalance.EditValue = null;
            if (lookupListCustomer1.EditValue != null)
            {
                CustomerLookUpListModel SelectedCustomer = (CustomerLookUpListModel)lookupListCustomer1.GetSelectedDataRow();
                if (SelectedCustomer != null)
                {
                    if (!CustomerNoChanging)
                    {
                        txtCustomerNo.EditValue = SelectedCustomer.CustomerNo;
                    }
                    txtGSTNo.Text = SelectedCustomer.GSTNo;
                    txtBalance.EditValue = DAL.Customer.CustomerBalanceDAL.GetBalance(SelectedCustomer.CustomerID);
                }
            }
        }

        public CustomerLookUpListModel GetSelectedRecord()
        {
            return (CustomerLookUpListModel)lookupListCustomer1.GetSelectedDataRow();
        }

    }
}
