using System.ComponentModel.DataAnnotations;

namespace Core_OdeToCode.Entities
{
    public enum CuisineType
    {
        None,
        Indian,
        Chinese,
        Panjabi,
        South
    }

    public class Restaurant
    {
        public int Id { get; set; }
        
        [Display(Name = "Restaurant Name:")]
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Display(Name = "Cuisine Type:")]
        public CuisineType Cuisine { get; set; }
    }
}
