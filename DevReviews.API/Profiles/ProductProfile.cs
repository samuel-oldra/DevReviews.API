using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;

namespace DevReviews.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<Product, ProductDetailsViewModel>();

            CreateMap<ProductReview, ProductReviewViewModel>();

            CreateMap<ProductReview, ProductReviewDetailsViewModel>();
        }
    }
}