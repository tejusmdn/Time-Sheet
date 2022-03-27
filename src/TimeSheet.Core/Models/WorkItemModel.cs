using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class WorkItemModel
    {
        public DateTime EntryDate { get; set; }

        public float EntryHours { get; set; }

        public int WorkItemId { get; set; }
    }
}
