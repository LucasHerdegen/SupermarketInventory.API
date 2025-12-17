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
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            _logger.LogInformation("A GET request for categories was submitted");

            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            _logger.LogInformation("A GET request was made for category with id {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("A category with a negative ID was requested: {Id}", id);
                return BadRequest();
            }

            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                _logger.LogWarning("Category with ID {Id} was not found", id);
                return NotFound();
            }  

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(string newCategory)
        {
            _logger.LogInformation("A POST request was made for create category with name: {Name}", newCategory);

            var category = await _categoryService.AddCategory(newCategory);

            if (category == null)
            {
                _logger.LogWarning("A request was made to create an existing category: {Name}", newCategory);
                return Conflict("The category already exists!");
            }

            return Ok(category);
        }

    }
}