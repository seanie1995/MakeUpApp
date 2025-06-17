using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MakeUpApp.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        public readonly MakeupContext _context;

        public ProductRepo(MakeupContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductAsync(Product product)
        {

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
            
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {

            try
            {
                var found = await _context.Products.FindAsync(product.Id);
                _context.Remove(found);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
                throw new ApplicationException("Database error at Repo level", ex);     
            }   
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {    
            try
            {
                var productList = await _context.Products.ToListAsync();
                return productList;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var found = await _context.Products.FindAsync(id);
                return found;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at Repo level", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetUserProductsAsync(int id)
        {
            try
            {
                var foundList = await _context.Products
                    .Where(p => p.Id == id)
                    .ToListAsync();

                return foundList;
                
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message, ex); }
        }

        public async Task<bool> UpdateProductAsync(Product existingProduct, Product updatedProduct)
        {
            try
            {
                var existing = await _context.Products.FindAsync(existingProduct.Id);
                if (existing == null)
                {
                    return false;
                }
                existing.Description = updatedProduct.Description;
                existing.Name = updatedProduct.Name;    
                existing.OpenDate = updatedProduct.OpenDate;
                existing.PAO = updatedProduct.PAO;

                return true;

            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Database error at repo level", ex);
            }
        }
    }
}
