using Maxishop.Domain.Contracts;
using Maxishop.Domain.Models;
using Maxishop.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Respositries
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
            
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Product.Include(x => x.Catagory).Include(x => x.Brand).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetDetailsAsync(int id)
        {
            return await _dbContext.Product.Include(x => x.Catagory).Include(x => x.Brand).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
