using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Interfaces.Repositories;
using TimeSheet.Core.Interfaces.Services;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IWorkItemRepository workItemRepository;

        public WorkItemService(IWorkItemRepository workItemRepository)
        {
            this.workItemRepository = workItemRepository ?? throw new ArgumentNullException(nameof(workItemRepository));
        }

        public async Task<IEnumerable<WorkItemModel>> GetCurrentSprintItems()
        {
            return await workItemRepository.GetCurrentSprintItems();
        }
    }
}
