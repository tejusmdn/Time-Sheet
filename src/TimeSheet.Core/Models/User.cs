using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string DisplayName { get; set; }

        public string UniqueName { get; set; }
    }
}
