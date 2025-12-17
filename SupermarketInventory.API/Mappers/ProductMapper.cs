using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Models;

namespace SupermarketInventory.API.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>().ForMember(dto => dto.CategoryName, m => m.MapFrom(p => p.Category!.Name));
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();
        }
    }
}