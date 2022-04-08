using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using TimeSheet.Core.Interfaces.Repositories;
using TimeSheet.Core.Models;
using TimeSheet.Infrastructure.Context;

namespace TimeSheet.Infrastructure.Repositories
{
    public class DevOpsRepository : IDevOpsRepository
    {
        private readonly DevOpsContext devOpsContext;
        private readonly IMapper mapper;

        public DevOpsRepository(DevOpsContext devOpsContext, IMapper mapper)
        {
            this.devOpsContext = devOpsContext;
            this.mapper = mapper;
        }

        public async Task<WorkItemQueryResult> ExecuteQueryAsync(Wiql query)
        {
            return this.devOpsContext.ExecuteQueryAsync(query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<DevOpsWorkItem>> GetWorkItemsAsync(IEnumerable<int> workItemIds)
        {
            var workItems = await this.devOpsContext.GetWorkItemsAsync(workItemIds);

            return this.mapper.Map<IEnumerable<DevOpsWorkItem>>(workItems);
        }
    }
}
