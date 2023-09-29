using Maxishop.Domain.Contracts;
using Maxishop.Domain.Models;
using Maxishop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Respositries
{
    public class CatagoryRepository : GenericRepository<Catagory>, ICatagoryRepository
    {
        public CatagoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task UpdateAsync(Catagory catagory)
        {
            _dbContext.Update(catagory);
            await _dbContext.SaveChangesAsync();
        }

         
    }
}
