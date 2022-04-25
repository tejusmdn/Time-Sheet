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
        private readonly IEntriesRepository entriesRepository;
        private readonly IDevOpsRepository devOpsRepository;

        public TimeSheetEntryService(IEntriesRepository entriesRepository, IDevOpsRepository devOpsRepository)
        {
            this.entriesRepository = entriesRepository ?? throw new ArgumentNullException(nameof(entriesRepository));
            this.devOpsRepository = devOpsRepository ?? throw new ArgumentNullException(nameof(devOpsRepository));
        }

        public async Task<TimeSheetData> GetCurrentSprintItems(string projectName)
        {
            var project = await this.devOpsRepository.GetProject(projectName);

            var wiql = WorkItemQueryHelper.GetCurrentSprintWorkItemQuery(project);

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

        public async Task<bool> UpdateTimeSheetEntry(TimeSheetData data)
        {
            // Todo : Step 1 - Get Current entries for the work item from cosmos db. 
            // Todo : Step 2 - Compare the stored entries to the newly entries. 
            // Todo : Step 3 - If the values have changed, update the completed and remaining hours for the work item
            // Todo : Step 4 - Update the CosmosDB entries record

            return false;
        }
    }
}
