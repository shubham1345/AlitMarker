using Alit.Marker.Model;
using Alit.Marker.Model.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.UpdateMaster
{
    public static class CommonFunctions
    {
        public static void GetFinalError(SavingResult res, Exception ex)
        {
            res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
            res.Exception = ex;
            while (res.Exception != null && res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
            {
                res.Exception = res.Exception.InnerException;
            }

            if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
            {
                res.ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                {
                    foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                    {
                        res.ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                    }
                    res.ValidationError += "\r\n";
                }

                res.Exception = new Exception(res.ValidationError);
            }
        }

        public static void GetFinalError(Exception ex)
        {
            while (ex != null && ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
            {
                ex = ex.InnerException;
            }

            if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
            {
                string ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                {
                    foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                    {
                        ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                    }
                    ValidationError += "\r\n";
                }

                ex = new Exception(ValidationError);
            }
        }
    }
}