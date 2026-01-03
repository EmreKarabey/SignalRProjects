using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SignalRApiProject.Dto.Basket;
using static SignalRApiProject.Controllers.AboutController;
using static SignalRApiProject.Controllers.BookingController;
using static SignalRApiProject.Controllers.CategoryController;

namespace SignalRApiProject.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AddAboutDto,About>().ReverseMap();
            CreateMap<AboutListDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();
            CreateMap<CreateBasket,Basket>().ReverseMap();
            CreateMap<AddBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<AddCategoryDto, Category>().ReverseMap();
           
        }
    }
}
