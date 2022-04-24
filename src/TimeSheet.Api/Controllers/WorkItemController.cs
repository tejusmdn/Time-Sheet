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
        private readonly ITimeSheetEntryService timeSheetEntryService;

        public WorkItemController(ITimeSheetEntryService timeSheetEntryService)
        {
            this.timeSheetEntryService = timeSheetEntryService ?? throw new ArgumentNullException(nameof(timeSheetEntryService));
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
        public async Task<ActionResult<IEnumerable<WorkItemEntry>>> GetCurrentSprintItems([FromQuery] string project)
        {
            var response = await this.timeSheetEntryService.GetCurrentSprintItems(project).ConfigureAwait(false);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
