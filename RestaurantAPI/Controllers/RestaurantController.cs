using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
   
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _dbContext.Restaurants.ToList();
            return Ok(restaurants);
        }
    }
}
