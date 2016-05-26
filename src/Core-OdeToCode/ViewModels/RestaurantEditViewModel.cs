using Core_OdeToCode.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core_OdeToCode.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Display(Name = "Restaurant Name:")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
