using Journey.Application.UseCases.Links.Delete;
using Journey.Application.UseCases.Links.Register;
using Journey.Application.UseCases.Links.Update;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripLinksController : ControllerBase
    {
        [HttpPost]
        [Route("{tripId}/register")]
        [ProducesResponseType(typeof(ResponseLinkJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterParticipant([FromRoute]Guid tripId, [FromBody] RequestRegisterLinkJson request)
        {
            var useCase = new RegisterLinkForTripUseCase();
            var response = useCase.Execute(tripId, request);
            return Created(string.Empty, response);
        }
        
        [HttpPut]
        [Route("{tripId}/update/{linkId}")]
        [ProducesResponseType(typeof(ResponseLinkJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateById([FromRoute]Guid tripId, [FromRoute]Guid linkId, 
            [FromBody]RequestRegisterLinkJson request)
        {
            var useCase = new UpdateLinkForTripUseCase();
            var response = useCase.Execute(tripId, linkId, request);
            return Ok(response);
        }
                
        [HttpDelete]
        [Route("{tripId}/delete/{linkId}")]
        [ProducesResponseType(typeof(ResponseLinkJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteParticipant([FromRoute]Guid tripId, [FromRoute]Guid linkId)
        {
            var useCase = new DeleteLinkForTripUseCase();
            useCase.Execute(tripId, linkId);
            return NoContent();
        }
    }
}
