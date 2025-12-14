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

        public ProductsController(IProductService productService,
            IValidator<ProductPostDto> productPostValidator,
            IValidator<ProductPutDto> productPutValidator)
        {
            _productService = productService;
            _productPostValidator = productPostValidator;
            _productPutValidator = productPutValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest("The ID must be greater than 0");

            var product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductPostDto productPostDto)
        {
            var validation = _productPostValidator.Validate(productPostDto);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var product = await _productService.AddProduct(productPostDto);

            if (product == null)
                return Conflict("The product already exists or the category do not exists!");

            return CreatedAtAction(nameof(GetProduct), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductPutDto productPutDto)
        {
            var validation = _productPutValidator.Validate(productPutDto);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var product = await _productService.UpdateProduct(id, productPutDto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteResult = await _productService.DeleteProduct(id);

            if (!deleteResult)
                return NotFound();

            return NoContent();
        }
    }
}