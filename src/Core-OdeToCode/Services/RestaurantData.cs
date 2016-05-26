using Core_OdeToCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_OdeToCode.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant newRestaurant);
        int Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToCodeDbContext _context;

        public SqlRestaurantData(OdeToCodeDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
            // need to use paging for large data.
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "McD" },
                new Restaurant { Id = 2, Name = "Red Chili" },
                new Restaurant { Id = 3, Name = "Kareem's" }
            };
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
