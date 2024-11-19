using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alit.Marker.Service.Update
{
    public static class CommonFunctions
    {
        public static Exception GetFinalError(Exception ex)
        {
            while (ex != null && ex.Message.Contains("See the inner exception"))
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
            return ex;
        }
    }
}