﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]//wymagaj nagłówka autoryzacji
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        //[AllowAnonymous]
        //[Authorize(Policy = "HasNationality")]
        //[Authorize(Roles = "Admin,Manager")]
        [Authorize(Policy = "Atleast20")] // nazwa polityki jak w klasie startap
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery]RestaurantQuery query)
        {
            var restaurantsDtos = _restaurantService.GetAll(query);
            //Thread.Sleep(4000);
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]//zezwól bez autoryzacji
        [Authorize(Policy = "Atleast20")] // nazwa polityki jak w klasie startap
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurants/{id}", null); // status 201 - ścieżka do nowo utworzonego zasobu, drugi parametr zawiera body i jest opcjonalny
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            _restaurantService.Update(id, dto);

            return Ok();
        }
    }
}
