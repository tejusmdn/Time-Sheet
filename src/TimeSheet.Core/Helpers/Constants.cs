using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Helpers
{
    using System.ComponentModel;

    public static class Constants
    {
        [Localizable(false)] public static string WorkItemTitleField = "System.Title";
        [Localizable(false)] public static string WorkItemIdField = "System.Id";
        [Localizable(false)] public static string WorkItemTypeField = "System.WorkItemType";
        [Localizable(false)] public static string WorkItemStateField = "System.State";
        [Localizable(false)] public static string WorkItemIterationPathField = "System.IterationPath";
        [Localizable(false)] public static string WorkItemEffortField = "Microsoft.VSTS.Scheduling.Effort";
        [Localizable(false)] public static string WorkItemAssignedToField = "System.AssignedTo";
        [Localizable(false)] public static string WorkItemRemainingWorkField = "Microsoft.VSTS.Scheduling.RemainingWork";
        [Localizable(false)] public static string WorkItemCompletedWorkField = "Microsoft.VSTS.Scheduling.CompletedWork";


        public static string[] Fields { get; } = new[] { WorkItemIdField, WorkItemTitleField, WorkItemTypeField, WorkItemStateField, WorkItemIterationPathField, WorkItemAssignedToField, WorkItemEffortField, WorkItemRemainingWorkField, WorkItemCompletedWorkField };
        

    }
}
