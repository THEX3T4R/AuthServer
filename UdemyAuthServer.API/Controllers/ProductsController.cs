using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;
using UdemyAuthServer.Core.Services;

namespace UdemyAuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IGenericService<Product,ProductDto> _genericService;

        public ProductsController(IGenericService<Product, ProductDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return ActionResultInstance(await _genericService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _genericService.AddAsync(productDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _genericService.Update(productDto, productDto.Id));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            return ActionResultInstance(await _genericService.Remove(Id));
        }
    }
}
