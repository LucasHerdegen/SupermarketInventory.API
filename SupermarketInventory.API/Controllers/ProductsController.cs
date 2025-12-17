using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Services;

namespace SupermarketInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductPostDto> _productPostValidator;
        private readonly IValidator<ProductPutDto> _productPutValidator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService,
            IValidator<ProductPostDto> productPostValidator,
            IValidator<ProductPutDto> productPutValidator,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _productPostValidator = productPostValidator;
            _productPutValidator = productPutValidator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            _logger.LogInformation("A GET request for products was submitted");

            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            _logger.LogInformation("A GET request was made for product with id {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("A product with a negative ID was requested: {Id}", id);
                return BadRequest("The ID must be greater than 0");
            }

            var product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductPostDto productPostDto)
        {
            _logger.LogInformation("A POST request was made for create product with name: {Name}", productPostDto.Name);

            var validation = _productPostValidator.Validate(productPostDto);

            if (!validation.IsValid)
            {
                _logger.LogWarning("Invalid request was made for create product: {Errors}", validation.Errors);
                return BadRequest(validation.Errors);
            }
                
            var product = await _productService.AddProduct(productPostDto);

            if (product == null)
            {
                _logger.LogWarning("The request for create a product failed");
                return Conflict("The product already exists or the category do not exists!");
            }

            return CreatedAtAction(nameof(GetProduct), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductPutDto productPutDto)
        {
            _logger.LogInformation("A PUT request was made to update product with id {Id}", id);

            var validation = _productPutValidator.Validate(productPutDto);

            if (!validation.IsValid)
            {
                _logger.LogWarning("Invalid request was made for update product: {Errors}", validation.Errors);
                return BadRequest(validation.Errors);
            }

            var product = await _productService.UpdateProduct(id, productPutDto);

            if (product == null)
            {
                _logger.LogWarning("The product with id {Id} to update was not found", id);
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation("A DELETE request was made to delete product with id {Id}", id);

            var deleteResult = await _productService.DeleteProduct(id);

            if (!deleteResult)
            {
                _logger.LogWarning("The product with id {Id} to delete was not found", id);
                return NotFound();
            }
                
            return NoContent();
        }
    }
}