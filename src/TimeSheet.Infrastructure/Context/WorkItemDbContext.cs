using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Infrastructure.Entities;

namespace TimeSheet.Infrastructure.Context
{
    public class WorkItemDbContext : DbContext
    {
        public WorkItemDbContext(DbContextOptions<WorkItemDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<WorkItem> WorkItems { get; set; }
    }
}
