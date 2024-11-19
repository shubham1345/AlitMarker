using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Inventory
{
    public enum eStockVoucherType
    {
        StockIn = 1,
        StockOut = 2,
        PurchaseBill = 3,
        SaleInvoice = 4, 
        StockTransferProductToPruduct = 5,
        SaleReturn = 6,
        PurchaseReturn = 7,
        OpeningStock = 8,
        ManufacturingProcess = 9,
        
        // only for report purpose
        Other = -1
    }

    public class StockVoucherViewModel
    {

        public long VoucherID { get; set; }

        public eStockVoucherType StockVoucherTypeID { get; set; }

        public DateTime VoucherDate { get; set; }

        public long VoucherNo { get; set; }

        public long? ProductID { get; set; }

        public long? PriceListID { get; set; }

        public string Narration { get; set; }

        public List<StockVoucherProductDetailViewModel> ProductDetail { get; set; }
    }

    public class StockVoucherProductDetailViewModel
    {
        public long StockProductDetailID { get; set; }

        public long StockVoucherID { get; set; }

        public long ProductID { get; set; }

        public decimal Quantity { get; set; }

        public decimal Rate { get; set; }

        public decimal Amount { get; set; }
    }
}
