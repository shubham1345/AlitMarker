using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model
{
    /*
    #region public enum
    /// <summary>
    /// Allowed UIs on form
    /// </summary>
    [Flags]
    public enum eFormAllowedUIs
    {
        Display = 0,
        NewEntry = 1,
        Edit = 2,
        Delete = 4
    }

    /// <summary>
    /// Form's Current UI
    /// </summary>
    public enum eFormCurrentUI
    {
        Display = 0,
        NewEntry = 1,
        Edit = 2,
        Delete = 3
    }

    /// <summary>
    /// Show form as Normal CRUD or specially dialogue form for specific UI.
    /// </summary>
    public enum eShowFormAs
    {
        RegularForm = 0,
        NewEntryDialogue = 1,
        EditDialogue = 2,
        DeleteDialogue = 3
    }

    public enum eFillSelectedRecordInContentFlag
    {
        None = 0,
        FilledSuccessfully = 1,
        SelectionSourceNotAvailable = 2,
        SelectedIndexNotAvailable = 3
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
    #endregion

    public class CRUDMTemplateParas
    {
        public CRUDMTemplateParas()
        {
            FormDefaultUI = eFormCurrentUI.NewEntry;
            FormAllowedUIs = eFormAllowedUIs.Display | eFormAllowedUIs.NewEntry | eFormAllowedUIs.Edit | eFormAllowedUIs.Delete;
            ShowFormAs = eShowFormAs.RegularForm;
        }

        public eFormCurrentUI FormDefaultUI { get; set; }

        public eFormAllowedUIs FormAllowedUIs { get; set; }

        public eShowFormAs ShowFormAs { get; set; }
    }

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

    public class BeforeDeleteValidationResult
    {
        public bool IsValidForDelete { get; set; }

        public string ValidationMessage { get; set; }
    }

    public class SavingParemeter
    {
        public enum eSavingInterface
        {
            AddNew = 0,
            Update = 1
        }
        public eSavingInterface SavingInterface { get; set; }

        /// <summary>
        /// Saving Object
        /// </summary>
        public SavingResult SavingResult { get; set; }
    }

    public class DeletingParameter
    {
        //public enum eDeleteResult
        //{
        //    None = 0,
        //    DeleteSuccessfullt = 1,
        //    ValidationErrors = 2,
        //    Exception = 3
        //}
        //public eDeleteResult DeleteResult { get; set; }
        //public System.Exception Exception { get; set; }

        /// <summary>
        /// Deleting Object
        /// </summary>
        public SavingResult DeletingResult { get; set; }
    }

    public class GenerateReportParameter
    {
        public GenerateReportResult GenerateReportResult { get; set; }
    }
    public class GenerateReportResult
    {
        public Exception Exception { get; set; }
        public eExecutionResult ExecutionResult { get; set; }
        public string ValidationError { get; set; }
        public GenerateReportResult()
        {
            Exception = null;
            ExecutionResult = eExecutionResult.NotExecutedYet;
        }
        public string MessageAfterReportGenerated { get; set; }
    }

    public class EditUserInfo
    {
        [Browsable(false)]
        public DateTime? CreatedDateTime { get; set; }

        [Browsable(false)]
        public long? CreatedUserID { get; set; }

        [Browsable(false)]
        public string CreatedUserName { get; set; }

        [Browsable(false)]
        public DateTime? EditedDateTime { get; set; }

        [Browsable(false)]
        public long? EditedUserID { get; set; }

        [Browsable(false)]
        public string EditedUserName { get; set; }
    }

    */
}