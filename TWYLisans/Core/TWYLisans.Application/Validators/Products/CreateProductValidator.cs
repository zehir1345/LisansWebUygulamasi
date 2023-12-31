﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() 
        {
            RuleFor(p => p.productName)
               .NotEmpty()
               .NotNull()
                 .WithMessage("Lütfen ürün adını boş geçemyiniz")
              .MaximumLength(200)
                 .WithMessage("Lütfen ürün adını 200 karakterden daha az giriniz");
            RuleFor(p => p.categoryID)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir kategori seçiniz");
        }
    }
}
