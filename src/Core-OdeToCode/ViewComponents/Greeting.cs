using Core_OdeToCode.Services;
using Microsoft.AspNet.Mvc;

namespace Core_OdeToCode.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            return View("Default", model);
        }
    }
}
