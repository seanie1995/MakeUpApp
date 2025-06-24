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
    public class ProductTypeController : ControllerBase
    {

        public readonly IProductTypeServices _productTypeServices;

        public ProductTypeController(IProductTypeServices productTypeServices)
        {
            _productTypeServices = productTypeServices;
        }


        
        [HttpGet("GetAllProductTypes")]
        public async Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypes()
        {
            var result = await _productTypeServices.GetAllProductTypesAsync();

            return result;
        }

       
        [HttpGet("GetProductType/{id}")]
        public async Task<ProductTypeViewModel> GetProductTypeById(int id)
        {
            var result = await _productTypeServices.GetProductTypeByIdAsync(id);
            return result;
        }

        
        [HttpPost("AddNewProductType")]
        public async Task<bool> AddNewProductType([FromBody] ProductTypeDTO product)
        {
            var result = await _productTypeServices.AddProductTypeAsync(product);

            return result;
        }

        
        [HttpPut("UpdateProductType/{id}")]
        public async Task<bool> UpdateProductType([FromBody] ProductTypeDTO product)
        {
            var result = await _productTypeServices.UpdateProductTypeAsync(product);

            return result;
        }

       
        [HttpDelete("DeleteProductType/{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _productTypeServices.DeleteProductTypeAsync(id);

            return result;
        }
    }
}
