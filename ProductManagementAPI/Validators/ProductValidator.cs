using FluentValidation;
using ProductManagementAPI.Models;


namespace ProductManagementAPI.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name cannot be empty.")
                .MaximumLength(50)
                .WithMessage("Product name cannot be longer than 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Product description cannot be empty.")
                .MaximumLength(100)
                .WithMessage("Product description cannot be longer than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price cannot be negative or zero.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock cannot be negative.");
            
        }




    }
}
