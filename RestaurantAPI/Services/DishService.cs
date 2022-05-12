using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IDishService //1. tworzymy abstrakcję - Interfejs który zarejestrujemy w kontenerze zależności w Startup aby wstrzyknąć tą zależność na podstawie tego interfejsu
    {
        int Create(int restaurantId, CreateDishDto dto);
    }
    public class DishService : IDishService
    {
        public RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found.");
            }

            var dishEntity = _mapper.Map<Dish>(dto); // mapujemy dto wysłane przez klienta do encji Dish
            dishEntity.RestaurantId = restaurantId;  // mapujemy ręcznie aby powiązać danie z restauracją
            _context.Dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.Id;
        }
    }
}
