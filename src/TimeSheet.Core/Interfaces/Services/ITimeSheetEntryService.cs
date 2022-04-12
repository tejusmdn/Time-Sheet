using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.Interfaces.Services
{
    public interface ITimeSheetEntryService
    {
        Task<TimeSheetData> GetCurrentSprintItems(string project, IEnumerable<string> teams);
    }
}
