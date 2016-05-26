using Microsoft.Extensions.Configuration;

namespace Core_OdeToCode.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetGreeting()
        {
            return _configuration["greeting"];
        }
    }
}
