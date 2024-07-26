using Journey.Application.UseCases.Participants;
using Journey.Application.UseCases.Participants.Delete;
using Journey.Application.UseCases.Participants.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripParticipantsController : ControllerBase
    {
        
        //Participant routes
        [HttpPost]
        [Route("{tripId}/register")]
        [ProducesResponseType(typeof(ResponseParticipantJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterParticipant([FromRoute]Guid tripId, [FromBody] RequestRegisterParticipantJson request)
        {
            var useCase = new RegisterParticipantForTripUseCase();
            var response = useCase.Execute(tripId, request);
            return Created(string.Empty, response);
        }
        
        [HttpPut]
        [Route("{tripId}/confirm/{participantId}")]
        [ProducesResponseType(typeof(ResponseParticipantJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult ConfirmParticipant([FromRoute]Guid tripId, [FromRoute]Guid participantId)
        {
            var useCase = new ConfirmParticipantForTripUseCase();
            useCase.Execute(tripId, participantId);
            return NoContent();
        }    
        
        [HttpDelete]
        [Route("{tripId}/delete/{participantId}")]
        [ProducesResponseType(typeof(ResponseParticipantJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteParticipant([FromRoute]Guid tripId, [FromRoute]Guid participantId)
        {
            var useCase = new DeleteParticipantForTripUseCase();
            useCase.Execute(tripId, participantId);
            return NoContent();
        }
    }
}
