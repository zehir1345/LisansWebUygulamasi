﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Domain.Entities;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
  
        public ProductReadRepository(TWYLisansDbContext context) : base(context)
        {
        
        }

        public async Task<Product> GetByIdProductAsync(int id)
        {
            return await Table
               .Include(e => e.category)
               .FirstOrDefaultAsync(c => c.ID == id);
        }
      
    }
}
