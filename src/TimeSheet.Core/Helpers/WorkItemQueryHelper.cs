using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace TimeSheet.Core.Helpers
{
    using TimeSheet.Core.Models;

    public static class WorkItemQueryHelper
    {
        public static Wiql GetCurrentSprintWorkItemQuery(Project project, string user = null)
        {
            if (project == null)
            {
                return null;
            }

            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("Select [System.Id] FROM WorkItems WHERE ");

            if (!string.IsNullOrEmpty(project.Name))
            {
                queryStringBuilder.Append($" [System.TeamProject] = '{project.Name}' And ");

                if (!string.IsNullOrEmpty(project.DefaultTeam.Name))
                {
                    queryStringBuilder.Append($" [System.IterationPath] = @CurrentIteration('[{project.Name}]\\{project.DefaultTeam.Name}') ");
                    queryStringBuilder.Append(" And ");
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
