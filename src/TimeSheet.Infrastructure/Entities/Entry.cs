using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Infrastructure.Entities
{
    public class Entry
    {
        public int WorkItemId { get; set; }
        
        public IEnumerable<EntryDetails> Entries { get; set; }
    }
}
