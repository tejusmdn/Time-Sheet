using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Infrastructure.Entities
{
    public class WorkItem
    {
        public string Id { get; set; }
        
        public DateTime EntryDate { get; set; } 
        
        public float EntryHours { get; set; }

        public string UserId { get; set; }

        public int WorkItemId { get; set; }
    }
}
