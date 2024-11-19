using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.SMS
{
    public partial class frmSMSLog : Template.frmNormalTemplate
    {
        public frmSMSLog()
        {
            InitializeComponent();

            entityInstantFeedbackSource1.KeyExpression = "SMSLogID";
            //entityInstantFeedbackSource1.GetQueryable += EntityInstantFeedbackSource1_GetQueryable;
            //entityInstantFeedbackSource1.DismissQueryable += EntityInstantFeedbackSource1_DismissQueryable;
            gridControl1.DataSource = entityInstantFeedbackSource1;
        }


        private void EntityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            //dbMarkerEntities db = new dbMarkerEntities();
            //e.QueryableSource = 
            //    from r in db.tblSMSLogs
            //    join u in db.tblUsers on r.UserID equals u.UserID
            //    select new { r.SMSLogID, r.OptionName, r.SendDateTime, r.MobileNo, r.SenderID, r.SMSText, r.DeliveryStatus, r.Error, u.UserName, r.SMSID};
            //e.Tag = db;
        }

        private void EntityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            //((dbMarkerEntities)e.Tag).Dispose();
        }
    }
}
