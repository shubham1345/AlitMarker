using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;

namespace Alit.Marker.Model.Inventory.Masters.StockItem
{
    public class StockItemDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductID; } set { ProductID = value; } }

        [Browsable(false)]
        public long ProductID { get; set; }

        public long? OpeningStockID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("HSN Code")]
        public string HSNCode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Opening Stock ")]
        public decimal? CurrentStock { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }
   }

    public class StockItemViewModel : Template.ICRUDViewModel,Template.IDashboardViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return ProductID; } set { ProductID = value; } }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        public string ProdDescr { get; set; }

        public string HSNCode { get; set; }

        [DisplayName("Unit")]
        public long UnitID { get; set; }

        public long? Tax1ID { get; set; }

        public long? Tax2ID { get; set; }

        public long? Tax3ID { get; set; }

        [DisplayName(" Opening Stock")]
        public decimal? CurrentStock { get; set; }

        public decimal PurchaseRate { get; set; }

        public List<StockItemRateViewModel> SaleRate { get; set; }

        public ProductOpeningStockViewModel OpeningStock { get; set; }

        public eRecordState RecordState
        {
            get; set;
          
        }
    }

    public class StockItemRateViewModel 
    {
        [Browsable(false)]
        public long PriceListID { get; set; }

        [DisplayName("Price List")]
        public string PriceListName { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("Discount %")]
        public decimal DiscountPerc { get; set; }
    }

    public class StockItemLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ProductID; } set { ProductID = value; } }

        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        //[DisplayName("Brand")]
        //public string BrandName { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Stock")]
        public decimal? CurrentStock { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }
    }

    public class StockItemLookupListModel_WithoutStock
    {
        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        [Browsable(false)]
        public string Barcode { get; set; }

        //[DisplayName("Brand")]
        //public string BrandName { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }
    }

    public class StockItemDetailViewModel
    {
        [Browsable(false)]
        public long ProductID { get; set; }

        [DisplayName("P. Code")]
        public long PCode { get; set; }

        [DisplayName("Barcode")]
        public string Barcode { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        public string ProdDescr { get; set; }

        public string HSNCode { get; set; }

        public long UnitID { get; set; }

        public string UnitName { get; set; }


        public long? Tax1ID { get; set; }

        public string Tax1Name { get; set; }

        public long? Tax2ID { get; set; }

        public string Tax2Name { get; set; }

        public long? Tax3ID { get; set; }

        public string Tax3Name { get; set; }

        [DisplayName("Stock")]
        public decimal? CurrentStock { get; set; }

        public decimal PurchaseRate { get; set; }

        public List<StockItemRateViewModel> SaleRate { get; set; }
    }

}
