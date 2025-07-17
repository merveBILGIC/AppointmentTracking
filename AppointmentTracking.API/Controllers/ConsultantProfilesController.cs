using AppointmentTracking.Application.Features.ConsultantProfiles.Commands;
using AppointmentTracking.Application.Features.ConsultantProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultantProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConsultantProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

       

        [HttpGet("consultant/{consultantId:guid}")]
        public async Task<IActionResult> GetByConsultantId(Guid consultantId)
        {
            var result = await _mediator.Send(new GetConsultantProfileByConsultantIdQuery(consultantId));
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllConsultantProfilesQuery());
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateConsultantProfileCommand command)
        {
            if (id != command.Id) return BadRequest("ID uyuşmuyor.");
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteConsultantProfileCommand(id));
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

