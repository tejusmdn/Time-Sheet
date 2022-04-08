using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.Interfaces.Repositories
{
    public interface IWorkItemRepository
    {
        Task<IEnumerable<WorkItemEntry>> GetSprintItems(string sprintName);
        
    }
}
