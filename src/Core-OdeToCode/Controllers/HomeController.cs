using Core_OdeToCode.ViewModels;
using Core_OdeToCode.Services;
using Microsoft.AspNet.Mvc;
using Core_OdeToCode.Entities;
using Microsoft.AspNet.Authorization;

namespace Core_OdeToCode.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public IActionResult GetData()
        {
            // this.ActionContext = to get more action you are inside of
            // this.HttpContext.Request // you can look headers or set header in response.
            // this.HttpContext.Response

            // Method to produce results
            // this.File()
            // this.View() = to create a view
            // return Content("to re turn a string");
            return new ObjectResult(new { Name = "Akash", Country = "India" }); // to return json response by default
            //var model = new Restaurant() { Id = 12, Name = "KFC" };
            //return new ObjectResult(model);
        }

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Add(restaurant);
                _restaurantData.Commit();
                //return View("Details", restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
                //return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel input)
        {
                
            var restaurant = _restaurantData.Get(id);
            if (restaurant != null && ModelState.IsValid)
            {
                restaurant.Name = input.Name;
                restaurant.Cuisine = input.Cuisine;
                //_restaurantData.Update();
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }
    }
}
