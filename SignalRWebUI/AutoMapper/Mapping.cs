using AutoMapper;
using EntityLayer.Concrete;
using SignalRWebUI.Dtos.About;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Category;
using SignalRWebUI.Dtos.Contact;
using SignalRWebUI.Dtos.Discount;
using SignalRWebUI.Dtos.Feature;
using SignalRWebUI.Dtos.Products;
using SignalRWebUI.Dtos.SocialMedia;
using SignalRWebUI.Dtos.Testimonial;

namespace SignalRWebUI.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<ProductsListDto, Products>().ReverseMap();
            CreateMap<UpdateProducts, Products>().ReverseMap();
            CreateMap<AddProduct, Products>().ReverseMap();
            CreateMap<CategoryList, Category>().ReverseMap();
            CreateMap<AddCategory, Category>().ReverseMap();
            CreateMap<AddAbout, About>().ReverseMap();
            CreateMap<UpdateAbout, About>().ReverseMap();
            CreateMap<UpdateBooking, Booking>().ReverseMap();
            CreateMap<AddBooking, Booking>().ReverseMap();
            CreateMap<DiscountList, Discount>().ReverseMap();
            CreateMap<UpdateDiscount, Discount>().ReverseMap();
            CreateMap<AddDiscount, Discount>().ReverseMap();
            CreateMap<TestimonialList, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonial, Testimonial>().ReverseMap();
            CreateMap<SocialMediaList, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMedia, SocialMedia>().ReverseMap();
            CreateMap<AddSocialMedia, SocialMedia>().ReverseMap();
            CreateMap<FeatureList, Feature>().ReverseMap();
            CreateMap<UpdateFeature, Feature>().ReverseMap();
            CreateMap<ContactList, Contact>().ReverseMap();
            CreateMap<AddContact, Contact>().ReverseMap();
            CreateMap<UpdateContact, Contact>().ReverseMap();
        }
    }
}
