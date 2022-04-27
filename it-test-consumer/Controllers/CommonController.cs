using it_test_consumer.Areas.UserManagement.BindOrgUser;
using it_test_consumer.Areas.UserManagement.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace it_test_consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : Controller
    {
        private readonly IMediator _mediator;

        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("bind-org-user")]
        public async Task<IActionResult> BindOrgUser([FromBody]BindOrgUserRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery]GetUsersRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
