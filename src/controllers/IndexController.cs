using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TapEnd.VersioningExample.V1
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Get() => "Version 1";
    }
}

namespace TapEnd.VersioningExample.V2
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Get() => "Version 2";
    }
}
