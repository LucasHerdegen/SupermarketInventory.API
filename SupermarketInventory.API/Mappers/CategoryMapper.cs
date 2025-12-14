using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Models;

namespace SupermarketInventory.API.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}