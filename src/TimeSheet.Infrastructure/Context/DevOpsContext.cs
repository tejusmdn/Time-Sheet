using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using TimeSheet.Core.Helpers;

namespace TimeSheet.Infrastructure.Context
{
    using Microsoft.TeamFoundation.Core.WebApi;

    public class DevOpsContext
    {
        private readonly Uri devOpsUri;
        private readonly VssBasicCredential credentials;

        public DevOpsContext(Uri devOpsUri, VssBasicCredential credentials)
        {
            this.devOpsUri = devOpsUri;
            this.credentials = credentials;
        }

        public async Task<WorkItemQueryResult> ExecuteQueryAsync(Wiql query)
        {
            using var client = new WorkItemTrackingHttpClient(this.devOpsUri, this.credentials);

            return client.QueryByWiqlAsync(query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(IEnumerable<int> workItemIds, string[] fields = null,
            DateTime? asOf = null)
        {
            using var client = new WorkItemTrackingHttpClient(this.devOpsUri, this.credentials);

            return await client.GetWorkItemsAsync(workItemIds, fields, asOf);
        }

        public async Task<TeamProject?> GetProject(string projectName)
        {
            using var client = new ProjectHttpClient(this.devOpsUri, this.credentials);
            var projects = await client.GetProjects(getDefaultTeamImageUrl:true);
            var projectId = projects.FirstOrDefault(x => x.Name.Equals(projectName))?.Id;

            if (projectId == null)
            {
                return null;
            }

            return await client.GetProject(projectId?.ToString());
        }
    }
}
