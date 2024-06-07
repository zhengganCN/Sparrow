using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sparrow.Security.JsonWebToken.Test.Users;

namespace Sparrow.Security.JsonWebToken.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly SparrowCurrent<TestUser> _test;
        private readonly SparrowCurrent<ComplexUser> _complex;

        public UserController(ILogger<UserController> logger, SparrowCurrent<TestUser> test, SparrowCurrent<ComplexUser> complex)
        {
            _logger = logger;
            _test = test;
            _complex = complex;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new
            {
                test = _test.User,
                complex = _complex.User,
            });
        }
    }
}
