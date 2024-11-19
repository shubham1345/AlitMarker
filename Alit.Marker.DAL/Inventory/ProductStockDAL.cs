using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Inventory
{
    public class ProductStockDAL
    {
        public static SavingResult UpdateStock(long ProductID, decimal UpdateStock, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            tblProductStock SaveModel = db.tblProductStocks.FirstOrDefault(r => 
                r.ProductID == ProductID &&
                r.CompanyID == CompanyID &&
                r.FinPeriodID == FinPeriodID);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblProductStock();

                SaveModel.ProductID = ProductID;

                SaveModel.Stock = UpdateStock;
                SaveModel.CompanyID = CompanyID;
                SaveModel.FinPeriodID = FinPeriodID;
                SaveModel.rcdt = DateTime.Now;
                //SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                db.tblProductStocks.Add(SaveModel);
            }
            else
            {
                SaveModel.Stock += UpdateStock;
                SaveModel.redt = DateTime.Now;
                //SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                db.tblProductStocks.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            return res;
        }

        public static SavingResult UpdateStock(long ProductID, decimal UpdateStock, long CompanyID, long FinPeriodID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return ProductStockDAL.UpdateStock(ProductID, UpdateStock, CompanyID, FinPeriodID, db, res);
            }
        }

        public static decimal GetStock(long ProductID, long CompanyID, long FinPeriodID, dbMarkerEntities db, SavingResult res)
        {
            tblProductStock SaveModel = db.tblProductStocks.FirstOrDefault(r =>
                r.ProductID == ProductID &&
                r.CompanyID == CompanyID && 
                r.FinPeriodID == FinPeriodID);
            if (SaveModel != null)
            {
                return SaveModel.Stock;
            }
            else
            {
                return 0;
            }
        }

        public static decimal GetStock(long ProductID, long CompanyID, long FinPeriodID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetStock(ProductID, CompanyID, FinPeriodID, db, res);
            }
        }

        public static decimal GetStock(long ProductID, dbMarkerEntities db, SavingResult res)
        {
            return GetStock(ProductID, 
                    Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                    db, res);
        }

        public static decimal GetStock(long ProductID)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                return GetStock(ProductID, db, res);
            }
        }
    }
}
