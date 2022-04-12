using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Helpers;
using TimeSheet.Core.Interfaces.Repositories;
using TimeSheet.Core.Interfaces.Services;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.Services
{
    public class TimeSheetEntryService : ITimeSheetEntryService
    {
        private readonly IWorkItemRepository workItemRepository;
        private readonly IDevOpsRepository devOpsRepository;

        public TimeSheetEntryService(IWorkItemRepository workItemRepository, IDevOpsRepository devOpsRepository)
        {
            this.workItemRepository = workItemRepository ?? throw new ArgumentNullException(nameof(workItemRepository));
            this.devOpsRepository = devOpsRepository ?? throw new ArgumentNullException(nameof(devOpsRepository));
        }

        public async Task<TimeSheetData> GetCurrentSprintItems(string project, IEnumerable<string> teams)
        {

            var wiql = WorkItemQueryHelper.GetCurrentSprintWorkItemQuery(project, teams);

            var result = await this.devOpsRepository.ExecuteQueryAsync(wiql);

            var workItemIds = result.WorkItems.DistinctBy(x => x.Id).Select(workItem => workItem.Id).ToList();

            var workItems = await this.devOpsRepository.GetWorkItemsAsync(workItemIds, Constants.Fields, DateTime.Today);

            var timeSheetData = new TimeSheetData()
            {
                WorkItems = workItems
            };

            //Todo : Retrieve the entries from DB and append to the user's data.

            return timeSheetData;
        }
    }
}
