using Microsoft.AspNetCore.Mvc;

namespace UM.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <param name="term">Enter registration number</param>
        /// <returns>If there is a Customer, return the Customer, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<object>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                //var request = new GetAllCustomersRequest { Term = term };
                //var result = await Mediator!.Send(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}