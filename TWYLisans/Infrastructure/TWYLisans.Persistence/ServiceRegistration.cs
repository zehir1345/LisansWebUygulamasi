﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Persistence.Context;
using TWYLisans.Persistence.Repositories;
using TWYLisans.Persistence.Repositories.Licences;

namespace TWYLisans.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<TWYLisansDbContext>(options => options.UseSqlServer(Configuration.ConnectionString,null));
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IWriteCustomerRepository, CustomerWriteRepository>();
            service.AddScoped<IReadCustomerRepository, CustomerReadRepository>();
            service.AddScoped<ILicenceWriteRepository, LicenceWriteRepository>();
            service.AddScoped<ILicenceReadRepository, LicenceReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        }
    }
}
