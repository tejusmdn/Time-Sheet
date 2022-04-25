using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Interfaces.Repositories;
using TimeSheet.Core.Models;
using TimeSheet.Infrastructure.Context;

namespace TimeSheet.Infrastructure.Repositories
{
    public class EntriesRepository : IEntriesRepository
    {
        public EntriesDbContext EntriesDbContext;
        //private readonly IMapper mapper;

        public EntriesRepository(EntriesDbContext dbContext/*, IMapper mapper*/)
        {
            this.EntriesDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            //this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<WorkItemEntry>> GetSprintItems(string sprintName)
        {
            // Todo : Fix the CosmosDB data context and then fix the repository
            //var workItems = await this.workItemDbContext.WorkItems.ToListAsync().ConfigureAwait(false);
            //return this.mapper.Map<IEnumerable<WorkItemEntry>>(workItems);

            throw new NotImplementedException();
        }
    }
}
