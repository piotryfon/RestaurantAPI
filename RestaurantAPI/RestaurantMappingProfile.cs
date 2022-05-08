using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile // AutoMapper.Extensions.Microsoft.DependencyInjection
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
            // pozostałe właściwości, jeżeli zgadzają się typy i nazwy właściwości pomiędzy tymi dwoma klasami
            // (Restaurant RestaurantDto), zostaną zmapowane automatycznie!

            CreateMap<Dish, DishDto>();

      
        }
    }
}
