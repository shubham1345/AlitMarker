using Alit.Marker.DBO;
using Alit.Marker.Model;
using Alit.Marker.Model.Settings.ApplicationSettings;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.DAL.Settings.ApplicationSettings
{
    public class SettingsDAL
    {
        public ApplicationSettingsViewModel GetSetting()
        {
            return GetSetting(0);
        }
        public ApplicationSettingsViewModel GetSetting(long CompanyID)
        {
            ApplicationSettingsViewModel NewSettings = new ApplicationSettingsViewModel();
            GetSetting(CompanyID, NewSettings);
            return NewSettings;
        }
        public void GetSetting(long CompanyID, ApplicationSettingsViewModel NewSettings)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                PropertyInfo[] Props = typeof(ApplicationSettingsViewModel).GetProperties();

                foreach (var SaveModel in db.tblSettingL0)
                {
                    string SettingName = SaveModel.SettingName;
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SettingName);
                    if (p == null)
                    {
                        continue;
                    }

                    eSettingValueType SettingValueType = (eSettingValueType)SaveModel.SettingValueType;
                    object SettingValue = (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModel.SettingValueVC :
                                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModel.SettingValueInt :
                                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModel.SettingValueLong :
                                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModel.SettingValueDateTime :
                                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModel.SettingValueBoolean :
                                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModel.SettingValueDecimal : null))))));

                    SettingValue = (SettingValueType == eSettingValueType.Int && p.PropertyType == typeof(int) ? (object)((int?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.Long && p.PropertyType == typeof(long) ? (object)((long?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.DateTime && p.PropertyType == typeof(DateTime) ? (object)((DateTime?)SettingValue ?? DateTime.MinValue) :
                                (SettingValueType == eSettingValueType.Boolean && p.PropertyType == typeof(bool) ? (object)((bool?)SettingValue ?? false) :
                                (SettingValueType == eSettingValueType.Decimal && p.PropertyType == typeof(decimal) ? (object)((decimal?)SettingValue ?? 0) :
                                
                                SettingValue)))));

                    p.SetValue(NewSettings, SettingValue);
                }

                //foreach (PropertyInfo p in Props)
                foreach (var SaveModelMaster in db.tblSettingMasterL1)
                {
                    string SettingName = SaveModelMaster.SettingName;
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SettingName);
                    if (p == null)
                    {
                        continue;
                    }

                    //tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
                    //if (SaveModelMaster == null)
                    //{
                    //    continue;
                    //}

                    eSettingValueType SettingValueType = (eSettingValueType)SaveModelMaster.SettingValueType;
                    object SettingMasterValue = (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModelMaster.SettingValueVC :
                                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModelMaster.SettingValueInt :
                                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModelMaster.SettingValueLong :
                                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModelMaster.SettingValueDateTime :
                                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModelMaster.SettingValueBoolean :
                                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModelMaster.SettingValueDecimal : null))))));

                    object SettingValue = null;
                    if (CompanyID != 0)
                    {
                        tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == CompanyID);

                        SettingValue = (SaveModel == null ? null : (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModel.SettingValueVC :
                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModel.SettingValueInt :
                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModel.SettingValueLong :
                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModel.SettingValueDateTime :
                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModel.SettingValueBoolean :
                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModel.SettingValueDecimal : null)))))));
                    }

                    if (SettingValue == null)
                    {
                        SettingValue = SettingMasterValue;
                    }

                    /// If property type is not nullable type and setting value is null then assign default value.
                    SettingValue = (SettingValueType == eSettingValueType.Int && (p.PropertyType == typeof(int) || p.PropertyType.IsEnum) ? (object)((int?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.Long && p.PropertyType == typeof(long) ? (object)((long?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.DateTime && p.PropertyType == typeof(DateTime) ? (object)((DateTime?)SettingValue ?? DateTime.MinValue) :
                                (SettingValueType == eSettingValueType.Boolean && p.PropertyType == typeof(bool) ? (object)((bool?)SettingValue ?? false) :
                                (SettingValueType == eSettingValueType.Decimal && p.PropertyType == typeof(decimal) ? (object)((decimal?)SettingValue ?? 0) :
                                
                                SettingValue)))));


                    p.SetValue(NewSettings, SettingValue);
                }
                //if (SaveModel == null || SettingValue == null)
                //{
                //        switch (SettingValueType)
                //        {
                //            case eSettingValueType.Varchar50:
                //                p.SetValue(NewSettings, SaveModelMaster.SettingValueVC);
                //                break;
                //            case eSettingValueType.Int:
                //                if(p.PropertyType == typeof(int))
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueInt ?? 0);
                //                }
                //                else /// it will throw error if propert type is not exactly matching setting value type
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueInt);
                //                }
                //                break;
                //            case eSettingValueType.Long:
                //                if (p.PropertyType == typeof(long))
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueLong ?? 0);
                //                }
                //                else /// it will throw error if propert type is not exactly matching setting value type
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueLong);
                //                }
                //                break;
                //            case eSettingValueType.DateTime:
                //                if (p.PropertyType == typeof(DateTime))
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueDateTime ?? DateTime.MinValue);
                //                }
                //                else /// it will throw error if propert type is not exactly matching setting value type
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueDateTime);
                //                }
                //                break;
                //            case eSettingValueType.Boolean:
                //                if (p.PropertyType == typeof(bool))
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueBoolean ?? false);
                //                }
                //                else /// it will throw error if propert type is not exactly matching setting value type
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueBoolean);
                //                }
                //                break;
                //            case eSettingValueType.Decimal:
                //                if (p.PropertyType == typeof(decimal))
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueDecimal ?? 0);
                //                }
                //                else /// it will throw error if propert type is not exactly matching setting value type
                //                {
                //                    p.SetValue(NewSettings, SaveModelMaster.SettingValueDecimal);
                //                }
                //                break;
                //        }
                //}
                //else
                //{
                //    switch ((eSettingValueType)SaveModelMaster.SettingValueType)
                //    {
                //        case eSettingValueType.Varchar50:
                //            p.SetValue(NewSettings, SaveModel.SettingValueVC);
                //            break;
                //        case eSettingValueType.Int:
                //            if (p.PropertyType == typeof(int))
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueInt ?? 0);
                //            }
                //            else /// it will throw error if propert type is not exactly matching setting value type
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueInt);
                //            }
                //            break;
                //        case eSettingValueType.Long:
                //            if (p.PropertyType == typeof(long))
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueLong ?? 0);
                //            }
                //            else /// it will throw error if propert type is not exactly matching setting value type
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueLong);
                //            }
                //            break;
                //        case eSettingValueType.DateTime:
                //            if (p.PropertyType == typeof(DateTime))
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueDateTime ?? DateTime.MinValue);
                //            }
                //            else /// it will throw error if propert type is not exactly matching setting value type
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueDateTime);
                //            }
                //            break;
                //        case eSettingValueType.Boolean:
                //            if (p.PropertyType == typeof(bool))
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueBoolean ?? false);
                //            }
                //            else /// it will throw error if propert type is not exactly matching setting value type
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueBoolean);
                //            }
                //            break;
                //        case eSettingValueType.Decimal:
                //            if (p.PropertyType == typeof(decimal))
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueDecimal ?? 0);
                //            }
                //            else /// it will throw error if propert type is not exactly matching setting value type
                //            {
                //                p.SetValue(NewSettings, SaveModel.SettingValueDecimal);
                //            }
                //            break;
                //    }
                //}

                //tblSettingsL0 SettingsL0 = db.tblSettingsL0.FirstOrDefault();

                //if (SettingsL0 != null)
                //{
                //    NewSettings.SettingL0ID = SettingsL0.SettingL0ID;
                //    NewSettings.AutoUserLogin = false;//(SettingsL0.AutoUserLogin == 1);
                //}

                //if (Model.CommonProperties.LoginInfo.LoggedInCompany != null)
                //{
                //    tblSettingsL1 SettingsL1 = db.tblSettingsL1.Where(r => r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID).FirstOrDefault();
                //    if (SettingsL1 != null)
                //    {
                //        NewSettings.SettingL1ID = SettingsL1.SettingL1ID;

                //        NewSettings.SaleInvoiceMemoTypeApplies = (eSaleInvoiceMemoTypeApplies)SettingsL1.SaleInvoiceMemoTypeApplies;
                //        NewSettings.SaleInvoiceDefaultMemoType = (Alit.Marker.Model.Sales.eMemoType)SettingsL1.SaleInvoiceDefaultMemoType;

                //        NewSettings.SaleInvoiceAskCustomer = SettingsL1.SaleInvoiceAskCustomer;
                //        NewSettings.SaleInvoiceDefaultCashCustomerID = SettingsL1.SaleInvoiceDefaultCustomerID;

                //        NewSettings.SaleInvoiceNo = SettingsL1.SaleInvoiceNo;
                //        NewSettings.SaleInvoiceNoAutoGenerate = SettingsL1.SaleInvoiceNoAutoGenerate;
                //        NewSettings.SaleInvoiceNoPrefix = SettingsL1.SaleInvoiceNoPrefix;
                //        NewSettings.DefaultSaleInvoiceNoPrefixID = SettingsL1.DefaultSaleInvoiceNoPrefixID;
                //        NewSettings.SaleInvoiceSeries = (SettingsL1.SaleInvoiceNoSeries == null ? "" : SettingsL1.SaleInvoiceNoSeries);
                //        NewSettings.SaleInvoiceNoAllowEdit = SettingsL1.SaleInvoiceNoAllowEdit;
                //        NewSettings.SaleInvoiceChallanInfo = (SettingsL1.SaleInvoiceChallanInfo == null ? "" : SettingsL1.SaleInvoiceChallanInfo);
                //        NewSettings.SaleInvoiceDispatchInfo = SettingsL1.SaleInvoiceDispatchInfo;

                //        NewSettings.ApplyProductCode = SettingsL1.ProductCode;
                //        NewSettings.ApplyBarcode = SettingsL1.ProductBarcode;
                //        NewSettings.ApplyHSNCode = SettingsL1.HSNCode ?? false;

                //        NewSettings.MaintainProducts = SettingsL1.MaintainProducts;
                //        NewSettings.SaleInvoiceProductSelectionByProductCode = SettingsL1.SaleInvoiceProductSelectionByProductCode;
                //        NewSettings.SaleInvoiceProductSelectionByBarcode = SettingsL1.SaleInvoiceProductSelectionByBarcode;
                //        NewSettings.SaleInvoiceProductSelectionByProductName = SettingsL1.SaleInvoiceProductSelectionByProductName;
                //        NewSettings.SaleInvoiceAllowEditProductDescr = SettingsL1.SaleInvoiceAllowEditProductDescr;
                //        NewSettings.SaleInvoiceCursorStopOnQuan = SettingsL1.SaleInvoiceCursorStopOnQuan;
                //        NewSettings.SaleInvoiceDefaultQuan = SettingsL1.SaleInvoiceDefaultQuan;
                //        NewSettings.SaleInvoiceCursorStopOnRate = SettingsL1.SaleInvoiceCursorStopOnRate;
                //        NewSettings.SaleInvoiceAllowEditRate = SettingsL1.SaleInvoiceAllowEditRate;
                //        NewSettings.SaleInvoiceAddDiscountColumn = SettingsL1.SaleInvoiceAddDiscountColumn;
                //        NewSettings.SaleInvoiceCursorStopOnDisc = SettingsL1.SaleInvoiceCursorStopOnDisc;
                //        NewSettings.SaleInvoiceAddTaxColumn = SettingsL1.SaleInvoiceAddTaxColumn;
                //        NewSettings.SaleInvoiceCursorStopOnTax = SettingsL1.SaleInvoiceCursorStopOnTax;

                //        NewSettings.SaleInvoiceAddUnitColumn = SettingsL1.SaleInvoiceAddUnitColumn;
                //        NewSettings.SaleInvoiceCursorStopOnUnit = SettingsL1.SaleInvoiceCursorStopOnUnit;

                //        NewSettings.SaleInvoicePrintDefaultFormat = SettingsL1.SaleInvoicePrintDefaultFormatNo ?? (long)Model.Reports.Sales.eInvoiceFormats.Standard_A4;
                //        NewSettings.SaleInvoicePrintIsDirectPrint = SettingsL1.SaleInvoicePrintIsDirectPrint ?? false;
                //        NewSettings.SaleInvoicePrintNoCopies = SettingsL1.SaleInvoicePrintNoCopies ?? 1;

                //        NewSettings.ReceiptPrintIsDirectPrint = SettingsL1.ReceiptPrintIsDirectPrint ?? false;
                //        NewSettings.ReceiptPrintNoCopies = SettingsL1.ReceiptPrintNoCopies ?? 1;

                //        /// Sale Order
                //        NewSettings.ApplySaleOrderNo = SettingsL1.SaleOrderNo ?? false;
                //        NewSettings.SaleOrderNoAutoGenerate = SettingsL1.SaleOrderNoAutoGenerate ?? false;
                //        NewSettings.SaleOrderNoPrefix = SettingsL1.SaleOrderNoPrefix ?? false;
                //        NewSettings.DefaultSaleOrderNoPrefixID = SettingsL1.DefaultSaleOrderNoPrefixID;
                //        NewSettings.SaleOrderSeries = (SettingsL1.SaleOrderNoSeries == null ? "" : SettingsL1.SaleOrderNoSeries);
                //        NewSettings.SaleOrderNoAllowEdit = SettingsL1.SaleOrderNoAllowEdit ?? false;

                //        /// Sale Return
                //        NewSettings.ApplySaleReturnNo = SettingsL1.SaleReturnNo ?? false;
                //        NewSettings.SaleReturnNoAutoGenerate = SettingsL1.SaleReturnNoAutoGenerate ?? false;
                //        NewSettings.SaleReturnNoPrefix = SettingsL1.SaleReturnNoPrefix ?? false;
                //        NewSettings.DefaultSaleReturnNoPrefixID = SettingsL1.DefaultSaleReturnNoPrefixID;
                //        NewSettings.SaleReturnSeries = (SettingsL1.SaleReturnNoSeries == null ? "" : SettingsL1.SaleReturnNoSeries);
                //        NewSettings.SaleReturnNoAllowEdit = SettingsL1.SaleReturnNoAllowEdit ?? false;

                //        /// Purchase Bill
                //        NewSettings.ApplyPurchaseReceiptNo = SettingsL1.PurchaseReceiptNo ?? false;
                //        NewSettings.PurchaseReceiptNoAutoGenerate = SettingsL1.PurchaseReceiptNoAutoGenerate ?? false;
                //        NewSettings.PurchaseReceiptNoPrefix = SettingsL1.PurchaseReceiptNoPrefix ?? false;
                //        NewSettings.DefaultPurchaseReceiptNoPrefixID = SettingsL1.DefaultPurchaseReceiptNoPrefixID;
                //        NewSettings.PurchaseReceiptSeries = (SettingsL1.PurchaseReceiptNoSeries == null ? "" : SettingsL1.PurchaseReceiptNoSeries);
                //        NewSettings.PurchaseReceiptNoAllowEdit = SettingsL1.PurchaseReceiptNoAllowEdit ?? false;

                //        /// Purchase Return
                //        NewSettings.ApplyPurchaseReturnNo = SettingsL1.PurchaseReturnNo ?? false;
                //        NewSettings.PurchaseReturnNoAutoGenerate = SettingsL1.PurchaseReturnNoAutoGenerate ?? false;
                //        NewSettings.PurchaseReturnNoPrefix = SettingsL1.PurchaseReturnNoPrefix ?? false;
                //        NewSettings.DefaultPurchaseReturnNoPrefixID = SettingsL1.DefaultPurchaseReturnNoPrefixID;
                //        NewSettings.PurchaseReturnSeries = (SettingsL1.PurchaseReturnNoSeries == null ? "" : SettingsL1.PurchaseReturnNoSeries);
                //        NewSettings.PurchaseReturnNoAllowEdit = SettingsL1.PurchaseReturnNoAllowEdit ?? false;

                //        #region SMS
                //        NewSettings.IsSMSActivated = SettingsL1.SMSActivated ?? false;
                //        NewSettings.SMSAuthKey = SettingsL1.SMSAuthKey ?? "";

                //        NewSettings.SMSSendInSaleInvoice = SettingsL1.SMSSendInSI ?? false;
                //        NewSettings.SMSSISenderID = SettingsL1.SMSSISenderID ?? "";
                //        NewSettings.SMSSITemplate = SettingsL1.SMSITemp ?? "";

                //        NewSettings.SendSMSInReciept = SettingsL1.SMSSendInRec ?? false;
                //        NewSettings.SMSRecSenderID = SettingsL1.SMSRecSenderID ?? "";
                //        NewSettings.SMSRecieptTemplate = SettingsL1.SMSRecTemp ?? "";

                //        NewSettings.SendSMSInCBR = SettingsL1.SMSSendInCBR ?? false;
                //        NewSettings.SMSCBRSenderID = SettingsL1.SMSCBRSenderID ?? "";
                //        NewSettings.SMSCBRTemplate = SettingsL1.SMSCBRTemp ?? "";
                //        #endregion

                //    }
            }
        }

        public SavingResult SaveSettings(ApplicationSettingsViewModel ApplicationSetting, long CompanyID)
        {
            SavingResult res = new SavingResult();
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                PropertyInfo[] Props = typeof(ApplicationSettingsViewModel).GetProperties();

                /// Setting Level 0
                foreach (var SaveModel in db.tblSettingL0)
                {
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SaveModel.SettingName);
                    if (p == null)
                    {
                        continue;
                    }
                    SaveSettingL0(p.Name, p.GetValue(ApplicationSetting), db, res);
                }

                /// Setting Level 1
                foreach (var SaveModel in db.tblSettingMasterL1)
                {
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SaveModel.SettingName);
                    if(p == null)
                    {
                        continue;
                    }
                    SaveSettingL1(p.Name, p.GetValue(ApplicationSetting), CompanyID, db, res);
                }

                //--
                try
                {
                    db.SaveChanges();
                    //res.PrimeKeyValue = SaveModel.SettingL1ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveSettingL1(string SettingName, object SettingValue, long CompanyID)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblSettingsL1 SaveModel = SaveSettingL1(SettingName, SettingValue, CompanyID, db, res);
                if(res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SettingL1ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblSettingsL1 SaveSettingL1(string SettingName, object SettingValue, long CompanyID, dbMarkerEntities db, SavingResult res)
        {
            tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
            if (SaveModelMaster == null)
            {
                res.ValidationError = "Setting not found.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return null;
            }

            tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == CompanyID);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblSettingsL1()
                {
                    SettingName = SaveModelMaster.SettingName,
                    CompanyID = CompanyID
                };
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                db.tblSettingsL1.Add(SaveModel);
            }
            else
            {
                SaveModel.redt = DateTime.Now;
                db.tblSettingsL1.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            switch ((eSettingValueType)SaveModelMaster.SettingValueType)
            {
                case eSettingValueType.Varchar50:
                    SaveModel.SettingValueVC = (string)SettingValue;
                    break;
                case eSettingValueType.Int:
                    /// specially for enum type, casted to int then nullable int
                    SaveModel.SettingValueInt = (SettingValue != null ? (int?)((int)SettingValue) : null);
                    break;
                case eSettingValueType.Long:
                    SaveModel.SettingValueLong = (long?)SettingValue;
                    break;
                case eSettingValueType.DateTime:
                    SaveModel.SettingValueDateTime = (DateTime?)SettingValue;
                    break;
                case eSettingValueType.Boolean:
                    SaveModel.SettingValueBoolean = (bool?)SettingValue;
                    break;
                case eSettingValueType.Decimal:
                    SaveModel.SettingValueDecimal = (decimal?)SettingValue;
                    break;
            }
            return SaveModel;
        }

        public object GetSettingL1(string SettingName, long ComapnyID)
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
                if (SaveModelMaster == null)
                {
                    throw new Exception($"Setting name not found. Setting Name : {SettingName}");
                }

                tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == ComapnyID);
                //object SettingValue = null;
                if (SaveModel == null)
                {
                    if(SaveModelMaster != null)
                    {
                        switch ((eSettingValueType)SaveModelMaster.SettingValueType)
                        {
                            case eSettingValueType.Varchar50:
                                return SaveModelMaster.SettingValueVC;
                            case eSettingValueType.Int:
                                return SaveModelMaster.SettingValueInt;
                            case eSettingValueType.Long:
                                return SaveModelMaster.SettingValueLong;
                            case eSettingValueType.DateTime:
                                return SaveModelMaster.SettingValueDateTime;
                            case eSettingValueType.Boolean:
                                return SaveModelMaster.SettingValueBoolean;
                            case eSettingValueType.Decimal:
                                return SaveModelMaster.SettingValueDecimal;
                        }
                    }
                }
                else
                {
                    switch ((eSettingValueType)SaveModelMaster.SettingValueType)
                    {
                        case eSettingValueType.Varchar50:
                            return SaveModel.SettingValueVC;
                        case eSettingValueType.Int:
                            return SaveModel.SettingValueInt;
                        case eSettingValueType.Long:
                            return SaveModel.SettingValueLong;
                        case eSettingValueType.DateTime:
                            return SaveModel.SettingValueDateTime;
                        case eSettingValueType.Boolean:
                            return SaveModel.SettingValueBoolean;
                        case eSettingValueType.Decimal:
                            return SaveModel.SettingValueDecimal;
                    }
                }
            }
            return null;
        }


        public SavingResult SaveSettingL0(string SettingName, object SettingValue)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                tblSettingL0 SaveModel = SaveSettingL0(SettingName, SettingValue, db, res);
                if (res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SettingL0ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblSettingL0 SaveSettingL0(string SettingName, object SettingValue, dbMarkerEntities db, SavingResult res)
        {
            tblSettingL0 SaveModel = db.tblSettingL0.FirstOrDefault(r => r.SettingName == SettingName);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblSettingL0()
                {
                    SettingName = SaveModel.SettingName,
                };
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                db.tblSettingL0.Add(SaveModel);
            }
            else
            {
                SaveModel.redt = DateTime.Now;
                db.tblSettingL0.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            switch ((eSettingValueType)SaveModel.SettingValueType)
            {
                case eSettingValueType.Varchar50:
                    SaveModel.SettingValueVC = (string)SettingValue;
                    break;
                case eSettingValueType.Int:
                    SaveModel.SettingValueInt = (int?)SettingValue;
                    break;
                case eSettingValueType.Long:
                    SaveModel.SettingValueLong = (long?)SettingValue;
                    break;
                case eSettingValueType.DateTime:
                    SaveModel.SettingValueDateTime = (DateTime?)SettingValue;
                    break;
                case eSettingValueType.Boolean:
                    SaveModel.SettingValueBoolean = (bool?)SettingValue;
                    break;
                case eSettingValueType.Decimal:
                    SaveModel.SettingValueDecimal = (decimal?)SettingValue;
                    break;
            }
            return SaveModel;
        }
    }
}
