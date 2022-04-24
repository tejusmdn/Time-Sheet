using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Team DefaultTeam { get; set; }
    }
}
