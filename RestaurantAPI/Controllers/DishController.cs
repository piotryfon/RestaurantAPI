using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController] // atrybut walidujący
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService) // Wstrzykujemy zależność do kontrolera
        {
            _dishService = dishService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto) // nazwa restaurantId musi odpowiadać parametrowi w ścieżce Route({restaurantId})
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/{restaurantId}/dish/{newDishId}", null);
        }
    }
}
