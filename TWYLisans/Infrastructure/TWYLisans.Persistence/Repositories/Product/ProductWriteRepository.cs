﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
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
    internal class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        TWYLisansDbContext context;
        public ProductWriteRepository(TWYLisansDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool RemoveProduct(int id)
        {
            var entity = Table.Include(e => e.licences).FirstOrDefault(c => c.ID == id);
            if (entity != null)
            {
                entity.active = false;
                if (entity.licences.Count > 0)
                {
                    foreach (var l in entity.licences)
                    {
                        l.active = false;
                    }
                }
                EntityEntry<Product> entry = Table.Update(entity);
                return entry.State == EntityState.Modified;
            }
            return false;
        }

        public bool UpdateProduct(Product nProduct)
        {
            var entity = Table.Include(e => e.category).FirstOrDefault(c => c.ID == nProduct.ID);
            if (entity != null)
            {
                
                entity.productName = nProduct.productName;
                entity.productDescription = nProduct.productDescription;
                var category = context.Set<Category>().Find(nProduct.category.ID);
                entity.category = category;
                EntityEntry<Product> entry = Table.Update(entity);
                return entry.State == EntityState.Modified;
            }
            return false;
        }
    }
}
