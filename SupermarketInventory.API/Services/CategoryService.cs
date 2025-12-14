using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Models;
using SupermarketInventory.API.Repository;

namespace SupermarketInventory.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
                return null;

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _repository.Get();

            var categoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDtos;
        }

        public async Task<CategoryDto?> AddCategory(string categoryName)
        {
            if (await _repository.Exist(categoryName))
                return null;

            var newCategory = new Category
            {
                Name = categoryName
            };

            await _repository.Add(newCategory);
            await _repository.Save();

            var categoryDto = _mapper.Map<CategoryDto>(newCategory);

            return categoryDto;
        }
    }
}