using AppointmentTracking.Application.Features.ConsultantService.Commands;
using AppointmentTracking.Application.Features.ConsultantService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultantServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignService([FromBody] AssignServiceToConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveService([FromBody] RemoveServiceFromConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("consultant/{consultantId}")]
        public async Task<IActionResult> GetServicesByConsultant(Guid consultantId)
        {
            var result = await _mediator.Send(new GetServicesByConsultantIdQuery(consultantId));
            return Ok(result);
        }
    }
}
