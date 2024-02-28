using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWebServices.Services.TestService;

namespace SocialWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _testService.GetAll();
            return Ok(result);
        }
    }
}
