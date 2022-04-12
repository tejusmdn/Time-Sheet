using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace TimeSheet.Core.Helpers
{
    public static class WorkItemQueryHelper
    {
        public static Wiql GetCurrentSprintWorkItemQuery(string project, string team, string user = null)
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("Select [System.Id] FROM WorkItems WHERE ");

            if (!string.IsNullOrEmpty(project))
            {
                queryStringBuilder.Append($" [System.TeamProject] = '{project}' And ");

                if (!string.IsNullOrEmpty(team))
                {
                    queryStringBuilder.Append($" [System.IterationPath] = @CurrentIteration('[{project}]\\{team}') And ");
                }
            }

            queryStringBuilder.Append(" [System.WorkItemType] In ('Bug', 'Task') ");

            if (!string.IsNullOrEmpty(user))
            {
                queryStringBuilder.Append($" And [System.AssignedTo] = '{user}' ");
            }
            else
            {
                queryStringBuilder.Append($" And [System.AssignedTo] <> '' ");
            }

            var wiql = new Wiql()
            {
                Query = queryStringBuilder.ToString()
            };

            return wiql;
        }
    }
}
