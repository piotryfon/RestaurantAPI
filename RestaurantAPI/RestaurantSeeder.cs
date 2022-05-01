using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContect;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContect = dbContext;
        }
        public void Seed()
        {
            if (_dbContect.Database.CanConnect()) //jeżeli połączenie do db może być nawiązane
            {
                if (!_dbContect.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContect.Restaurants.AddRange(restaurants);
                    _dbContect.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kentaucky Fried Chicken",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                             Name = "Nashville Chicken",
                             Price = 10.30M,
                        },
                        new Dish()
                        {
                             Name = "Chicken Nuggets",
                             Price = 5.30M,
                        }

                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald's",
                    Category = "Fast Food",
                    Description = "Hamburgers and Śmiecie",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                             Name = "Hamburger",
                             Price = 10.30M,
                        },
                        new Dish()
                        {
                             Name = "Chicken Nuggets",
                             Price = 5.30M,
                        }

                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Krótka 15",
                        PostalCode = "01-001"
                    }
                }
            };


            return restaurants;
        }
    }
}
