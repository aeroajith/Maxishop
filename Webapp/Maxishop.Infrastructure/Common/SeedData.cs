using Maxishop.Domain.Models;
using Maxishop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Common
{
    public class SeedData
    {
        public static async Task SeedDataAysnc(ApplicationDbContext _dbContext)
        {
            if (!_dbContext.Brand.Any())
            {
                await _dbContext.AddRangeAsync(

                    new Brand
                    {
                        Name = "Apple",
                        EstablishedYear = 1956
                    },
                    new Brand
                    {
                        Name = "Samsung",
                        EstablishedYear = 1956
                    },
                    new Brand
                    {
                        Name = "Sony",
                        EstablishedYear = 1956
                    },
                    new Brand
                    {
                        Name = "Lenovo",
                        EstablishedYear = 1956
                    },
                    new Brand
                    {
                        Name = "Acer",
                        EstablishedYear = 1956
                    }
                    );
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
