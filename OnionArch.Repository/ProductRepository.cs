using Microsoft.EntityFrameworkCore;
using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;
using OnionArch.Data.Interfaces;
using OnionArch.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<Product> GetProductByIdAsync(Guid productID)
        {
            return await  _shopContext.Products.Include(x=>x.ProductType).Where(x=>x.Id==productID).FirstOrDefaultAsync();
        }


        public async Task<List<Product>> GetProductsAsync(ProductFilterDto productFilterDto)
        {
            var products = await _shopContext.Products.Include(x => x.ProductType).ToListAsync();

            if (productFilterDto != null)
            {
                if (productFilterDto.ProductTypeId.HasValue)
                {
                    products = products.Where(x => x.ProductTypeId == productFilterDto.ProductTypeId).ToList();
                }
                
                
                
            }
      
            return products;
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            var productsTypes = await _shopContext.ProductTypes.ToListAsync();

           
            return productsTypes;
        }

        public async Task<double> CalculateDiscountOnProductItems(Guid productId, int itemsCount)
        {
            var product =await GetProductByIdAsync(productId);
            if (product == null) return 0;
            
            var discount = ((product.Discount * product.Price * (double)itemsCount) / 100.00);
            return discount;
        }
    }
}
