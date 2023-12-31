﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string categoryName { get; set; } = null!;

        public virtual ICollection<Product> products { get; set; } = new List<Product>();
    }
}
