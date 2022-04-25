using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class TimeSheetData
    {
        public IEnumerable<DevOpsWorkItem> WorkItems { get; set; }

        public IEnumerable<WorkItemEntry> Entries { get; set; }
    }
}
