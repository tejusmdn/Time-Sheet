using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Infrastructure.Entities;

namespace TimeSheet.Infrastructure.Context
{
    public class WorkItemDbContext
    {
        private readonly string account;
        private readonly string key;

        public WorkItemDbContext(string account, string key)
        {
            this.account = account;
            this.key = key;
        }
    }
}
