﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.Repositories
{
    public interface IWriteCustomerRepository:IWriteRepository<Customer>
    {
        bool RemoveCustomer(int id);
        bool UpdateCustomer(Customer nCustomer);
    }
}
