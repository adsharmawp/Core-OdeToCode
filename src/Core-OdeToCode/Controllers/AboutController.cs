using Microsoft.AspNet.Mvc;

namespace Core_OdeToCode.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+9111-555-555-555";
        }

        [Route("[action]")]
        public string Country()
        {
            return "India";
        }
    }
}
