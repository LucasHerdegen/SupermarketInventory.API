using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Services;

namespace SupermarketInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            // todo: validation

            var categories = await _categoryService.GetCategories();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(string newCategory)
        {
            var category = await _categoryService.AddCategory(newCategory);

            return Ok(category);
        }

    }
}