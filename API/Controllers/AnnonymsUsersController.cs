using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;
using OnionArch.Data.Interfaces;
using OnionArch.Repository.Data;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonymsUsersController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        private readonly IProductService productService;

        public AnnonymsUsersController(ShopContext shopContext,IProductService productService)
        {
           _shopContext = shopContext;
            this.productService = productService;
        }

        [HttpPost("PlaceOrderReturnPriceAfterDiscount")]
        public async Task<double> PlaceOrderReturnPriceAfterDiscount(AnnonymsUser annonymsUser)
        {
            var product= await productService.GetProductByIdAsync(annonymsUser.productId);

            if (product.Discount > 0 && annonymsUser.quantity > 1)
            {
                annonymsUser.Price= await productService.CalculateDiscountOnProductItems(annonymsUser.productId, annonymsUser.quantity);
            }
               
              _shopContext.AnnonymsUsers.Add(annonymsUser);
              await _shopContext.SaveChangesAsync();


            return annonymsUser.Price;

        }

    }
}
