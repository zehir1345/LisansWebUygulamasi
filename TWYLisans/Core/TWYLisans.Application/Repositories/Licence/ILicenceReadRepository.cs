﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.Repositories
{
    public interface ILicenceReadRepository : IReadRepository<Licence>
    { 
        Task<Licence> GetByIdLicenceAsync(int id);
    }
}

