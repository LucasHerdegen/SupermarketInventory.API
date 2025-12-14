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
        private readonly IValidator<ProductPostDto> _productPutValidator;

        public ProductsController(IProductService productService,
            IValidator<ProductPostDto> productPostValidator,
            IValidator<ProductPostDto> productPutValidator)
        {
            _productService = productService;
            _productPostValidator = productPostValidator;
            _productPutValidator = productPutValidator;
        }

        [HttpGet]
        public int Suma(int x, int y) => x + y;
    }
}