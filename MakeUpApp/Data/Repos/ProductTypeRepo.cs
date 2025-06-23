using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MakeUpApp.Data.Repos
{
    public class ProductTypeRepo : IProductTypeRepo

    {
        public readonly MakeupContext _context;

        public ProductTypeRepo(MakeupContext context )
        {
            _context = context;
        }
        public async Task<bool> AddProductTypeAsync(ProductType productType)
        {
            try
            {
                await _context.AddAsync( productType );
                await _context.SaveChangesAsync();
                return true;
            } 
            catch ( Exception ex ) 
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<bool> DeleteProductTypeAsync(int id)
        {
            try
            {
                var found = await _context.ProductTypes.FindAsync(id);
                if (found != null)
                {
                    _context.Remove(found);
                    return true;
                } else 
                {
                    return false;
                }
            }
            catch (Exception ex) 
            {
                throw new ApplicationException($"{ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            try
            {
                return await _context.ProductTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get product types.", ex);
            }
        }


        public async Task<ProductType?> GetProductTypeByIdAsync(int id)
        {
            try
            {
                return await _context.ProductTypes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get product type by ID.", ex);
            }
        }


        public async Task<bool> UpdateProductTypeAsync(ProductType updatedProductType)
        {
            try
            {
                _context.ProductTypes.Update(updatedProductType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{ex.Message}", ex);
            }
        }
    }
}
