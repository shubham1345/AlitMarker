using Alit.Marker.DAL.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;
using Alit.Marker.DBO;
using Alit.Marker.Model.Inventory.Masters.StockItemTax;

namespace Alit.Marker.DAL.Inventory.Masters.StockItemTax
{
    public class StockItemTaxDAL : ICRUDDAL, IGridCRUDDAL, ILookupListDAL
    {
        AdditionalItemDAL DiscountTaxDALObj;

        public StockItemTaxDAL()
        {
            DiscountTaxDALObj = new AdditionalItemDAL();
        }

        public SavingResult SaveRecord(IGridCRUDViewModel ViewModel)
        {
            return SaveRecord((StockItemTaxViewModel)ViewModel);
        }

        public SavingResult SaveRecord(ICRUDViewModel ViewModel)
        {
            return SaveRecord((StockItemTaxViewModel)ViewModel);
        }

        public SavingResult SaveRecord(StockItemTaxViewModel ViewModel)
        {
            return DiscountTaxDALObj.SaveRecord(new AdditionalItemViewModel()
            {
                AdditionalItemID = ViewModel.AdditionalItemID,
                ItemName = ViewModel.ItemName,
                Perc = ViewModel.Perc,
                ProductTaxCategoryID = ViewModel.ProductTaxCategoryID,
                InclusiveTax = ViewModel.InclusiveTax,
                ItemType = eAdditionalItemType.Tax,
                Nature = eAdditionalItemNature.Add,
                CalculateOn = eCalculateOn.None,
                ReverseCalculatePercentage = false,
                IsDefaultRecord = false,
                DefaultRecordPriority = 0,
            });
        }

        IGridCRUDViewModel IGridCRUDDAL.GetCRUDViewModelByPrimeKey(long ID)
        {
            return (IGridCRUDViewModel)GetCRUDViewModelByPrimeKey(ID);
        }

        public ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAdditionalItemMasters

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.AdditionaItemID == ID
                        select new StockItemTaxViewModel()
                        {
                            AdditionalItemID = r.AdditionaItemID,
                            ItemName = r.ItemName,
                            Perc = r.Perc,
                            InclusiveTax = r.IsInclusive ?? false,
                            ProductTaxCategoryID = r.ProductTaxCategoryID ?? 0,

                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                        }).FirstOrDefault();
            }
        }

        public IEnumerable<IGridCRUDViewModel> GetViewModelList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAdditionalItemMasters

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && (eAdditionalItemType)r.ItemType == eAdditionalItemType.Tax

                        orderby r.ItemName

                        select new StockItemTaxViewModel()
                        {
                            AdditionalItemID = r.AdditionaItemID,
                            ItemName = r.ItemName,
                            Perc = r.Perc,
                            InclusiveTax = r.IsInclusive ?? false,
                            ProductTaxCategoryID = r.ProductTaxCategoryID ?? 0,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : null),
                            EditedUserName = (reu != null ? reu.UserName : null),

                        }).ToList();
            }
        }


        public BeforeDeleteValidationResult ValidateBeforeDelete(long ID)
        {
            return DiscountTaxDALObj.ValidateBeforeDelete(ID);
        }

        public SavingResult DeleteRecord(long ID)
        {
            return DiscountTaxDALObj.DeleteRecord(ID);
        }

        public BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState)
        {
            return DiscountTaxDALObj.ValidateBeforeUpdateRecordState(ID, oldState, newState);
        }

        public SavingResult UpdateRecordState(long ID, eRecordState newState)
        {
            return DiscountTaxDALObj.UpdateRecordState(ID, newState);
        }

        public bool IsDuplicateRecord(string ItemName, long ID)
        {
            return DiscountTaxDALObj.IsDuplicateRecord(ItemName, ID);
        }

        IEnumerable<ILookupListViewModel> ILookupListDAL.GetLookupList()
        {
            return GetLookupList(null);
        }
        
        public IEnumerable<ILookupListViewModel> GetLookupList(object[] FilterParas)
        {
            return GetLookUpList();
        }

        public List<StockItemTaxLookupListModel> GetLookUpList()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return (from r in db.tblAdditionalItemMasters

                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                              && (eAdditionalItemType)r.ItemType == eAdditionalItemType.Tax
                              && r.rstate != (byte)eRecordState.Deactivated

                        select new StockItemTaxLookupListModel()
                        {
                            RecordState = (eRecordState)r.rstate,
                            AdditionalItemID = r.AdditionaItemID,
                            ItemName = r.ItemName,
                            Perc = r.Perc,
                            InclusiveTax = r.IsInclusive ?? false,
                            ProductTaxCategoryID = r.ProductTaxCategoryID ?? 0,
                        }).ToList();
            }
        }
    }
}
