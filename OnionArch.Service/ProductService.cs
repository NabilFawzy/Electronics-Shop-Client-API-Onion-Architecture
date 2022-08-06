using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;
using OnionArch.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> GetProductByIdAsync(Guid productID)
        {
            return _productRepository.GetProductByIdAsync(productID);
        }
        public Task<double> CalculateDiscountOnProductItems(Guid productId, int itemsCount)
        {
            return _productRepository.CalculateDiscountOnProductItems( productId,  itemsCount);
        }

        

        public async Task<List<Product>> GetProductsAsync(ProductFilterDto productFilterDto)
        {
              return await _productRepository.GetProductsAsync(productFilterDto);
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _productRepository.GetProductTypesAsync();
        }
    }
}
