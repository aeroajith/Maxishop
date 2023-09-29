﻿using Maxishop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProductAsync();

        Task<Product> GetDetailsAsync(int id);

        Task UpdateAsync(Product product);
    }
}
