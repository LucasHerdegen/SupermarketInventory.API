using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketInventory.API.DTOs;

namespace SupermarketInventory.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto?> AddCategory(string categoryName);
        Task<CategoryDto?> GetCategoryById(int id);
    }
}