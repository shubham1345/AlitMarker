using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.VoucherType
{
    public enum ePrimaryVoucherType
    {
        None = 0,
        JournalVoucher = 1,
        ContraVoucher = 2,
        Sale =3,
        SaleReturn = 4,
        Purchase = 5,
        PurchaseReturn = 6,
        Receipt = 7,
        Payment = 8
    }
    public class VoucherTypeDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return VoucherTypeID; } set { VoucherTypeID = value; } }

        [Browsable(false)]
        public long VoucherTypeID { get; set; }

        [DisplayName("Voucher Type Name")]
        public string VoucherTypeName { get; set; }

        [Browsable(false)]
        public ePrimaryVoucherType PrimaryVoucherType { get; set; }

        [DisplayName("Primary Voucher Type")]
        public string PrimaryVoucherStr
        {
            get
            {
                switch (PrimaryVoucherType)
                {
                    case ePrimaryVoucherType.None:
                        return "None";
                    case ePrimaryVoucherType.JournalVoucher:
                        return "Journal Voucher";
                    case ePrimaryVoucherType.ContraVoucher:
                        return "Contra Voucher";
                    case ePrimaryVoucherType.Sale:
                        return "Sale";
                    case ePrimaryVoucherType.SaleReturn:
                        return "Sale Return";
                    case ePrimaryVoucherType.Purchase:
                        return "Purchase";
                    case ePrimaryVoucherType.PurchaseReturn:
                        return "Purchase Return";
                    case ePrimaryVoucherType.Receipt:
                        return "Receipt";
                    case ePrimaryVoucherType.Payment:
                        return "Payment";
                    default:
                        return null;
                }
            }
        }

    }

    public class VoucherTypeViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return VoucherTypeID; } set { VoucherTypeID = value; } }

        [Browsable(false)]
        public long VoucherTypeID { get; set; }

        [DisplayName("Voucher Type Name")]
        public string VoucherTypeName { get; set; }

        [DisplayName("Primary Voucher Type")]
        public ePrimaryVoucherType PrimaryVoucherType { get; set; }
    }

    public class VoucherTypeLookUpListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return VoucherTypeID; } set { VoucherTypeID = value; } }

        [Browsable(false)]
        public long VoucherTypeID { get; set; }

        [DisplayName("Voucher Type Name")]
        public string VoucherTypeName { get; set; }

        [Browsable(false)]
        public ePrimaryVoucherType PrimaryVoucherType { get; set; }

        [Browsable(false)]
        //[DisplayName("Primary Voucher Type")]
        public string PrimaryVoucherStr
        {
            get
            {
                switch (PrimaryVoucherType)
                {
                    case ePrimaryVoucherType.None:
                        return "None";
                    case ePrimaryVoucherType.JournalVoucher:
                        return "Journal Voucher";
                    case ePrimaryVoucherType.ContraVoucher:
                        return "Contra Voucher";
                    case ePrimaryVoucherType.Sale:
                        return "Sale";
                    case ePrimaryVoucherType.SaleReturn:
                        return "Sale Return";
                    case ePrimaryVoucherType.Purchase:
                        return "Purchase";
                    case ePrimaryVoucherType.PurchaseReturn:
                        return "Purchase Return";
                    case ePrimaryVoucherType.Receipt:
                        return "Receipt";
                    case ePrimaryVoucherType.Payment:
                        return "Payment";
                    default:
                        return null;
                }
            }
        }

    }
}
