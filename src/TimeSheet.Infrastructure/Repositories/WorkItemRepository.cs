using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class WorkItemRepository : IWorkItemRepository
    {
        public WorkItemDbContext workItemDbContext;
        private readonly IMapper mapper;

        public WorkItemRepository(WorkItemDbContext dbContext, IMapper mapper)
        {
            this.workItemDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<WorkItemModel>> GetCurrentSprintItems()
        {
            var workItems = await this.workItemDbContext.WorkItems.ToListAsync().ConfigureAwait(false);
            return this.mapper.Map<IEnumerable<WorkItemModel>>(workItems);
        }
    }
}
