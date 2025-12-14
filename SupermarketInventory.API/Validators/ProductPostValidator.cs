using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SupermarketInventory.API.DTOs;

namespace SupermarketInventory.API.Validators
{
    public class ProductPostValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostValidator()
        {
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("The price must be greater than 0");
            RuleFor(p => p.Name).NotEmpty().WithMessage("The name does not have to be empty");
        }
    }
}