using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Containers
{
    public static class ServicesContainers
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAboutServices, AboutManager>();
            services.AddScoped<IAbout, EFAbout>();

            services.AddScoped<IBookingServices, BookingManager>();
            services.AddScoped<IBooking, EFBooking>();

            services.AddScoped<ICategoryServices, CategoryManager>();
            services.AddScoped<ICategory, EFCategory>();

            services.AddScoped<IContactServices, ContactManager>();
            services.AddScoped<IContact, EFContact>();

            services.AddScoped<IDiscountServices, DiscountManager>();
            services.AddScoped<IDiscount, EFDiscount>();

            services.AddScoped<IFeatureServices, FeatureManager>();
            services.AddScoped<IFeature, EFFeature>();

            services.AddScoped<IProductsServices, ProductManager>();
            services.AddScoped<IProducts, EFProducts>();

            services.AddScoped<IProductsServices, ProductManager>();
            services.AddScoped<IProducts, EFProducts>();

            services.AddScoped<ISocialMediaServices, SocialMediaManager>();
            services.AddScoped<ISocialMedia, EFSocialMedia>();

            services.AddScoped<ITestimonialServices, TestimonialManager>();
            services.AddScoped<ITestimonial, EFTestimonial>();
        }
    }
}
