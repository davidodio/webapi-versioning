using Microsoft.AspNetCore.Mvc;

namespace Tapend.VersioningExample.V1
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        [HttpGet]
        public string Get() => "Version 1";
    }
}

namespace Tapend.VersioningExample.V2
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        [HttpGet]
        public string Get() => "Version 2";
    }
}
