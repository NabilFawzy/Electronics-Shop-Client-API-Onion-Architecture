using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;
using OnionArch.Data.Interfaces;
using OnionArch.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductsController(IProductService productService,IMapper mapper,IConfiguration configuration )
        {
          
            _productService = productService;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task< ActionResult<Pagination>> GetProducts([FromQuery]ProductFilterDto productFilterDto)
        {
            var products =  await _productService.GetProductsAsync(productFilterDto);

           foreach (var product in products)
                product.PictureUrl = product.PictureUrl == null ? (_configuration["ApiUrl"] + "unknown.png") : (_configuration["ApiUrl"] + product.PictureUrl);

           var data = _mapper.Map<List<Product>, List<ProductDto>>(products);

            Pagination pagination = new Pagination();
            pagination.PageSize = productFilterDto.PageSize;
            pagination.PageIndex = productFilterDto.pageIndex;
            pagination.Count = data.Count;
            pagination.data = data.AsEnumerable().Skip((productFilterDto.pageIndex - 1) * productFilterDto.PageSize).Take(productFilterDto.PageSize).ToList();


            return Ok(pagination);

        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(Guid id)
        {
            var product= await _productService.GetProductByIdAsync(id);
            
            product.PictureUrl = product.PictureUrl==null ? (_configuration["ApiUrl"] + "unknown.png") :(_configuration["ApiUrl"] + product.PictureUrl);
            return _mapper.Map<Product,ProductDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        { 
            return Ok(await _productService.GetProductTypesAsync());
        }


        [HttpGet("CalculateDiscountOnProductItems")]
        public async Task<double> CalculateDiscountOnProductItems(Guid productId ,int itemsCount )
        {
            var priceAfterDiscount = await _productService.CalculateDiscountOnProductItems(productId, itemsCount);


            return priceAfterDiscount;
        }





    }
}
