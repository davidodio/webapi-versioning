using Microsoft.AspNetCore.Mvc;

namespace TapEnd.VersioningExample.V1
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        [HttpGet]
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
        public string Get() => "Version 2";
    }
}
