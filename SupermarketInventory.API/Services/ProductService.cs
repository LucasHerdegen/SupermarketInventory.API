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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> GetProduct(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return null;

            var productDto = _mapper.Map<ProductDto>(product);
            
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _repository.Get();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }
        public async Task<ProductDto?> AddProduct(ProductPostDto product)
        {
            if (await _repository.Exist(product.Name))
                return null;

            var newProduct = _mapper.Map<Product>(product);

            await _repository.Add(newProduct);
            await _repository.Save();

            var productDto = _mapper.Map<ProductDto>(newProduct);

            return productDto;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return false;

            _repository.Delete(product);
            await _repository.Save();

            return true;
        }

        public async Task<ProductDto?> UpdateProduct(int id, ProductPutDto productPutDto)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return null;

            _mapper.Map(productPutDto, product);

            _repository.Update(product);
            await _repository.Save();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}