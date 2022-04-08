using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.Interfaces.Repositories
{
    public interface IDevOpsRepository
    {
        Task<WorkItemQueryResult> ExecuteQueryAsync(Wiql query);

        Task<IEnumerable<DevOpsWorkItem>> GetWorkItemsAsync(IEnumerable<int> workItemIds);
    }
}
