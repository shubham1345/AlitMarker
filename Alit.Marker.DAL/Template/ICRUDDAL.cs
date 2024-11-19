using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alit.Marker.Model.Template;

namespace Alit.Marker.DAL.Template
{
    public interface ICRUDDAL
    {
        SavingResult SaveRecord(ICRUDViewModel ViewModel);

        BeforeDeleteValidationResult ValidateBeforeDelete(long ID);

        SavingResult DeleteRecord(long ID);

        BeforeUpdateRecordStateValidationResult ValidateBeforeUpdateRecordState(long ID, eRecordState oldState, eRecordState newState);

        SavingResult UpdateRecordState(long ID, eRecordState newState);

        ICRUDViewModel GetCRUDViewModelByPrimeKey(long ID);
    }
}
