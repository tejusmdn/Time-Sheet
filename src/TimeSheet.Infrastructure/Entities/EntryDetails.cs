using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Infrastructure.Entities
{
    public class EntryDetails
    {
        public string UserId { get; set; }

        public DateTime EntryDate { get; set; }

        public float Hours { get; set; }
    }
}
