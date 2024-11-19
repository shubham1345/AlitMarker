using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Service.Update.Model
{
    public class SavingResult
    {
        public long PrimeKeyValue { get; set; }
        public Exception Exception { get; set; }
        public eExecutionResult ExecutionResult { get; set; }
        public string ValidationError { get; set; }
        public SavingResult()
        {
            PrimeKeyValue = 0;
            Exception = null;
            ExecutionResult = eExecutionResult.NotExecutedYet;
        }
        public string MessageAfterSave { get; set; }
    }
    public enum eExecutionResult
    {
        /// <summary>
        /// Transaction Has not been executed yet.
        /// </summary>
        NotExecutedYet = 0,
        /// <summary>
        /// Transaction Completed Successfully
        /// </summary>
        CommitedSucessfuly = 1,
        /// <summary>
        /// Error Occured While Transaction Executing (PgSql has generated some error)
        /// </summary>
        ErrorWhileExecuting = 2,
        /// <summary>
        /// Validation error occured before transaction executed.
        /// </summary>
        ValidationError = 3
    }
}
