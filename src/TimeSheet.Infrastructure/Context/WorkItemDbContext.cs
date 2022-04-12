using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Infrastructure.Entities;

namespace TimeSheet.Infrastructure.Context
{
    using Microsoft.Azure.Cosmos;

    public class WorkItemDbContext
    {
        private readonly string endPoint;
        private readonly string key;

        public WorkItemDbContext(string endPoint, string key)
        {
            this.endPoint = endPoint;
            this.key = key;
        }


        //public async IEnumerable<WorkItem> GetSprintWorkItems(string team, string sprint, string userId = null)
        //{
        //    using (var cosmosClient = new CosmosClient(this.endPoint, key))
        //    {
        //        await cosmosClient.CreateDatabaseIfNotExistsAsync(team);

        //        var db = cosmosClient.GetDatabase(team);

        //        await db.CreateContainerIfNotExistsAsync(sprint);

        //        var container = db.GetContainer(sprint);

                

        //    }
        //}
    }
}
