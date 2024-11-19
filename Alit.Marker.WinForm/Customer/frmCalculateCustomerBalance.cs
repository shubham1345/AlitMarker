using Alit.Marker.DAL;
using Alit.Marker.DAL.Customer;
using Alit.Marker.Model;
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

namespace Alit.Marker.WinForm.Customer
{
    public partial class frmCalculateCustomerBalance : Template.frmNormalTemplate
    {
        public frmCalculateCustomerBalance()
        {
            InitializeComponent();
            progressbar.Visible = false;
            lblWaitMessage.Visible = false;
        }

        private async void btnCalculateBalance_Click(object sender, EventArgs e)
        {
            progressbar.Visible = true;
            lblWaitMessage.Visible = true;
            btnCalculateBalance.Enabled = false;
            //--

            SavingResult res = await DAL.Customer.CustomerBalanceDAL.ReCalculateBalance();

            this.Invoke((MethodInvoker)delegate
            {
                progressbar.Visible = false;
                lblWaitMessage.Visible = false;
                btnCalculateBalance.Enabled = true;


                switch (res.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        //Alit.WinformControls.ToastNotification.Show(this, "Record saved successfully");
                        Alit.WinformControls.MessageBox.Show(this, "Customer balance re-calculated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this, "Error occurred while trying to process. Please contact to your vendor.\r\n\r\n" +
                            (res.Exception.Message.Length > 500 ? res.Exception.Message.Substring(0, 500) : res.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not finish the process. Please check following validation issue.\r\n\r\n" + res.ValidationError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            });
        }
    }
}
