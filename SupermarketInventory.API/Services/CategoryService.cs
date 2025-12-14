using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Repository;

namespace SupermarketInventory.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<CategoryRepository> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<CategoryRepository> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CategoryDto>> GetCategories()
        {
            throw new NotImplementedException();


        }

        public Task<CategoryDto> AddCategory(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}