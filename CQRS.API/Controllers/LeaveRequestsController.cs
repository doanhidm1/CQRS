using CQRS.Application.Features.LeaveRequest.Commands;
using CQRS.Application.Features.LeaveRequest.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<LeaveRequestDTO>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery());
            return leaveRequests;
        }

        [HttpGet("{id}")]
        public async Task<LeaveRequestDetailDTO> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id });
            return leaveRequest;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
        {
            var response = await _mediator.Send(leaveRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
