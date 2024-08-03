using Journey.Application.UseCases.Activities.Complete;
using Journey.Application.UseCases.Activities.Delete;
using Journey.Application.UseCases.Activities.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripActivitiesController : ControllerBase
    {
        
        [HttpPost]
        [Route("{tripId}/register")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterActivity([FromRoute]Guid tripId, [FromBody] RequestRegisterActivityJson request)
        {
            var useCase = new RegisterActivityForTripUseCase();
            var response = useCase.Execute(tripId, request);
            return Created(string.Empty, response);
        }
        
        [HttpPut]
        [Route("{tripId}/complete/{activityId}")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult CompleteActivity([FromRoute]Guid tripId, [FromRoute]Guid activityId)
        {
            var useCase = new CompleteActivityForTripUseCase();
            useCase.Execute(tripId, activityId);
            return NoContent();
        }    
        
        [HttpDelete]
        [Route("{tripId}/delete/{activityId}")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteActivity([FromRoute]Guid tripId, [FromRoute]Guid activityId)
        {
            var useCase = new DeleteActivityForTripUseCase();
            useCase.Execute(tripId, activityId);
            return NoContent();
        }

    }
}
