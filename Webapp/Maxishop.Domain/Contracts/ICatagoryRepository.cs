﻿using Maxishop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Contracts
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
       
        public Task UpdateAsync(Brand brand);
    }
}
