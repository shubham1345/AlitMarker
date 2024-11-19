using Alit.Marker.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Settings
{
    public class MenuOptionsDAL
    {
        public List<MenuOptionsViewModel> GetMenus()
        {
            List<MenuOptionsViewModel> res = new List<MenuOptionsViewModel>();
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1, MenuOptionName = "Company Profile", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2, MenuOptionName = "Financial Period", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3, MenuOptionName = "Users", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4, MenuOptionName = "User Group", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 5, MenuOptionName = "Recalculate Customer Balance", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.Normal });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 6, MenuOptionName = "Settings", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.Normal });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 7, MenuOptionName = "City / Town", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 8, MenuOptionName = "State / Region", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 9, MenuOptionName = "Country", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 10, MenuOptionName = "Product Master", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 11, MenuOptionName = "Product Unit", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 12, MenuOptionName = "Price List", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 13, MenuOptionName = "Product Tax", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 14, MenuOptionName = "Stock In", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 15, MenuOptionName = "Stock Out", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 16, MenuOptionName = "Stock Transfer", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 17, MenuOptionName = "Opening Stock", MenuOptionGroupName = "Inventory", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 18, MenuOptionName = "Stock In-Hand", MenuOptionGroupName = "Inventory - Reports", MenuType = eMenuOptionType.Report });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 19, MenuOptionName = "Purchase", MenuOptionGroupName = "Purchase", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 20, MenuOptionName = "Purchase Return", MenuOptionGroupName = "Purchase", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 21, MenuOptionName = "Sale Order", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 22, MenuOptionName = "Sale Invoice", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 23, MenuOptionName = "Sale Return", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 24, MenuOptionName = "Receipt", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 25, MenuOptionName = "Customer Master", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 26, MenuOptionName = "Opening Balance", MenuOptionGroupName = "Sale", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 27, MenuOptionName = "Additional Tax/Commission/Discount", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 28, MenuOptionName = "Transport", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 29, MenuOptionName = "Sale Invoice No. Prefix", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });
            //res.Add(new MenuOptionsViewModel() { MenuOptionID = 30, MenuOptionName = "Color", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 31, MenuOptionName = "Sale Order No. Prefix", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 32, MenuOptionName = "Invoice Print", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 33, MenuOptionName = "Receipt Print", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 34, MenuOptionName = "Sale Register", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 35, MenuOptionName = "Transaction Register", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 36, MenuOptionName = "Sale Summary", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 37, MenuOptionName = "Customer List", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 38, MenuOptionName = "Stock Ledger", MenuOptionGroupName = "Inventory - Reports", MenuType = eMenuOptionType.Report });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 39, MenuOptionName = "Customer Balance Report", MenuOptionGroupName = "Customer - Reports", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 40, MenuOptionName = "Payment", MenuOptionGroupName = "Receipt", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 41, MenuOptionName = "SMS Log", MenuOptionGroupName = "SMS", MenuType = eMenuOptionType.Report });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 42, MenuOptionName = "Product Tax Category", MenuOptionGroupName = "Inventory",  MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 43, MenuOptionName = "Sale Return No. Prefix", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 44, MenuOptionName = "Purchase Bill No. Prefix", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 45, MenuOptionName = "Purchase Return No. Prefix", MenuOptionGroupName = "Sale - Other", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 46, MenuOptionName = "Software Registration", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.Normal });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 47, MenuOptionName = "Tax Register", MenuOptionGroupName = "Sale - Reports", MenuType = eMenuOptionType.Report });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 48, MenuOptionName = "Receipt No. Prefix", MenuOptionGroupName = "Others - Receipt No. Prefix", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 49, MenuOptionName = "Formula", MenuOptionGroupName = "Manufacturing", MenuType = eMenuOptionType.Normal });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 50, MenuOptionName = "Process", MenuOptionGroupName = "Manufacturing", MenuType = eMenuOptionType.CRUD });
            return res;
        }
    }
}
