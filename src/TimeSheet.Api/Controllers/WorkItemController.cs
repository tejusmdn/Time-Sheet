using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.Interfaces.Services;
using TimeSheet.Core.Models;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItemService workItemService;

        public WorkItemController(IWorkItemService workItemService)
        {
            this.workItemService = workItemService ?? throw new ArgumentNullException(nameof(workItemService));
        }

        /// <summary>
        /// Get all the current sprint work items
        /// </summary>
        /// <returns>Current sprint work items</returns>
        [HttpGet]
        [Route("/currentsprint")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<WorkItemModel>>> GetCurrentSprintItems()
        {
            var response = await workItemService.GetCurrentSprintItems().ConfigureAwait(false);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
