using AutoMapper;
using Maxishop.Application.DTO.Brand;
using Maxishop.Application.DTO.Catagory;
using Maxishop.Application.DTO.Product;
using Maxishop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Catagory, CreateCatagoryDto>().ReverseMap();
            CreateMap<Catagory, UpdateCatagoryDto>().ReverseMap();
            CreateMap<Catagory, CatagoryDto>().ReverseMap();

            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();


            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Catagory, opt => opt.MapFrom(source => source.Catagory.Name))
                .ForMember(x => x.Brand, opt => opt.MapFrom(source => source.Brand.Name));


        }
    }
}
