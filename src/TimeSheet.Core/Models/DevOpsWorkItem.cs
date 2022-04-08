using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public  class DevOpsWorkItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Uri Url { get; set; }

        public float Effort { get; set; }

        public float Remaining { get; set; }

        public float Completed { get; set; }

        public User AssignedTo { get; set; }

        
    }
}
