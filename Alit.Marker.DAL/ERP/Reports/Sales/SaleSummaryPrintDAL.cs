using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Reports.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Reports.Sales
{
    public class SaleSummaryPrintDAL
    {
        public List<SaleSummaryPrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var SaleRec = (from r in db.tblSaleInvoices
                              where
                              (DateFrom == null || r.SaleInvoiceDate >= DateFrom) &&
                                (DateTo == null || r.SaleInvoiceDate <= DateTo) &&
                                //(CustomerID == null || r.CustomerID == CustomerID)
                                (CustomerID == null || r.CustomerAccountID == CustomerID)
                               group r by r.SaleInvoiceDate into gr
                              select new { SaleInvoiceDate = gr.Key, SaleAmt = gr.Sum(grr => grr.NetAmt) }).ToList();


                List<SaleSummaryPrintModel> ReportDS = (from r in SaleRec
                        group r by r.SaleInvoiceDate.ToString("MMM-yyyy") into gr
                                                        select new SaleSummaryPrintModel() { XAxisValue = gr.Key, SaleAmt = gr.Sum(grr => grr.SaleAmt) }).ToList(); ;

                return ReportDS;
            }
        }
    }
}
