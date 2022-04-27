using it_test_producer.Areas.UserManagement.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace it_test_producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            await _mediator.Send(request);

            return Ok("User was processed");
        }
    }
}
