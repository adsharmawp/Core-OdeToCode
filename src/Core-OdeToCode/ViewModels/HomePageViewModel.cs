using Core_OdeToCode.Entities;
using System.Collections.Generic;

namespace Core_OdeToCode.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
