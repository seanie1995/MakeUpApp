using MakeUpApp.Models.DTOs.ProductDTOs;
using MakeUpApp.Models.ViewModels;
using MakeUpApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakeUpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }


        [HttpGet("GetProductById/{id}")]
        public async Task<ProductViewModel> GetProductById(int id)
        {
            var result = await _services.GetProductByIdAsync(id);
            return result;
        }



        [HttpPost("AddNewProduct")]
        public async Task<bool> Post([FromBody] ProductDTO product)
        {
            var result = await _services.AddProductAsync(product);
            return result;
        }



        [HttpPut("UpdateProduct")]
        public async Task<bool> UpdateProduct([FromBody] ProductDTO product)
        {
            var result = await _services.UpdateProductAsync(product);

            return result;
        }

        
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _services.DeleteProductAsync(id);

            return result;
        }
    }
}
