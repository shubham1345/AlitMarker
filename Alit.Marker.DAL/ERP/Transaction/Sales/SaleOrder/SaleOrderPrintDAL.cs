using Alit.Marker.DBO;
using Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.ERP.Transaction.Sales.SaleOrder
{
    public class SaleOrderPrintDAL
    {
        public List<SaleOrderPrintModel> GenerateReportData(long SaleOrderID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleOrders.Where(wr => wr.SaleOrderID == SaleOrderID));
            }
        }

        public List<SaleOrderPrintModel> GenerateReportData(DateTime? DateFrom, DateTime? DateTo, long? CustomerID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleOrders.Where(wr =>
                    (DateFrom == null || wr.SaleOrderDate >= DateFrom) &&
                    (DateTo == null || wr.SaleOrderDate <= DateTo) &&
                    (CustomerID == null || wr.CustomerID == CustomerID)));
            }
        }

        public List<SaleOrderPrintModel> ConvertToModel(IQueryable<tblSaleOrder> SaleOrderRecords)
        {
            List<SaleOrderPrintModel> OrderDS = SaleOrderRecords.Select<tblSaleOrder, SaleOrderPrintModel>(r => new SaleOrderPrintModel()
            {
                SaleOrderID = r.SaleOrderID,

                OrderDate = r.SaleOrderDate,
                OrderNo = r.SaleOrderNo,
                SaleOrderNoPrefixID = r.SaleOrderNoPrefixID,
                SaleOrderNoPrefixName = r.tblSaleOrderNoPrefix.PrefixName,
                CustomerID = r.CustomerID,
                CustomerNameTitle = r.tblCustomer.NameTitle,
                CustomerName = r.tblCustomer.CustomerName,
                CompanyName = r.tblCustomer.CustomerCompanyName,
                CustomerAddress = r.tblCustomer.Address,
                CustomerCityName = r.tblCustomer.tblCity.CityName,
                CustomerCityStateShortName = r.tblCustomer.tblCity.tblState.StateShortName ?? r.tblCustomer.tblCity.tblState.StateName,
                CustomerCityCountryName = r.tblCustomer.tblCity.tblCountry.CountryName,
                CustomerPostCode = r.tblCustomer.PostCode,
                CustomerMobileNo = r.tblCustomer.MobileNo,
                CustomerPhoneNo = r.tblCustomer.PhoneNo,
                CustomerEMailID = r.tblCustomer.EMailID,
                CustomerWebsite = r.tblCustomer.Website,
                CustomerPAN = r.tblCustomer.PAN,
                CustomerGSTNo = r.tblCustomer.GSTNo,
                CustomerServiceTaxNo = r.tblCustomer.ServiceTaxNo,

                //ChallanNo = r.ChallanNo,
                //ChallanDate = r.ChallanDate,
                //OrderNo = r.OrderNo,
                //OrderDate = r.OrderDate,
                //SuppRefNo = r.SupplRefNo,
                //OtherRefNo = r.OtherRefNo,
                //TransportID = r.TransportID,
                //TransportName = r.tblTransport.TransportName,
                //NoPackets = r.NofPackets,
                //Destination = r.Destination,
                //DeliveryDate = r.DeliveryDate,
                GrossAmt = r.GrossAmt,
                NetAmt = r.NetAmt,
                NetAmtInWords = "",
                //OrderMemo = r.OrderMemo,

                Products = r.tblSaleOrderProductDetails.Select<tblSaleOrderProductDetail, SaleOrderProductReportModel>(pr => new SaleOrderProductReportModel()
                {
                    SaleOrderProductDetailID = pr.SaleOrderProductDetailID,
                    SaleOrderID = pr.SaleOrderID,
                    ProductID = pr.ProductID,
                    SNo = pr.SNo,
                    ProductName = (pr.ProductID != null ? pr.tblProduct.ProductName : null),
                    ProductDescr = pr.Descr,
                    Quan = pr.Quan,
                    Rate = pr.Rate,
                    UnitID = pr.UnitID,
                    UnitName = pr.tblUnit.UnitName,
                    DiscPerc = pr.DiscPerc,
                    DiscAmt = pr.DiscAmt,

                    Tax1Perc = pr.Tax1Perc,
                    Tax1Amt = pr.Tax1Amt,
                    Tax1ID = pr.Tax1ID,
                    Tax1Name = pr.tblProduct.tblAdditionalItemMaster.ItemName,

                    Tax2Perc = pr.Tax2Perc,
                    Tax2Amt = pr.Tax2Amt,
                    Tax2ID = pr.Tax2ID,
                    Tax2Name = pr.tblProduct.tblAdditionalItemMaster1.ItemName,

                    Tax3Perc = pr.Tax3Perc,
                    Tax3Amt = pr.Tax3Amt,
                    Tax3ID = pr.Tax3ID,
                    Tax3Name = pr.tblProduct.tblAdditionalItemMaster2.ItemName,


                    GAmt = pr.GAmt,
                    NAmt = pr.NAmt,

                }).ToList(),

                Additionals = r.tblSaleOrderAdditionals.Select<tblSaleOrderAdditional, SaleOrderAdditionReportModel>(ar => new SaleOrderAdditionReportModel()
                {
                    SaleOrderAdditionalsID = ar.SaleOrderAdditionalsID,
                    SaleOrderID = ar.SaleOrderID,
                    AddiotionalID = ar.AdditionalItemID,
                    AdditionalName = ar.tblAdditionalItemMaster.ItemName,
                    Descr = ar.Descr,
                    ItemNature = ((eAdditionalItemNature)ar.ItemNature == eAdditionalItemNature.Less ? "Less" : "Add"),
                    Perc = ar.Perc,
                    Amt = ar.Amt,
                    UpdatedAmt = ar.UpdatedAmt
                }).ToList()
            }).ToList();

            OrderDS.ForEach(r =>
            {
                r.CompanyDetail = Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel;
                r.NetAmtInWords = Model.CommonFunctions.NumbersToWords(r.NetAmt);
            });

            return OrderDS;
        }

        public List<SaleOrderPrintModel> GetSaleOrderPrintModel(long SaleOrderID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ConvertToModel(db.tblSaleOrders.Where(wr => wr.SaleOrderID == SaleOrderID));
            }
        }
    }
}