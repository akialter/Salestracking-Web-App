using AzureDBApp.Models;
using FluentValidation;

public class ProductEntityValidator : AbstractValidator<ProductEntity>
{
    public ProductEntityValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("Product Name is required and must be no more than 50 characters.");

        RuleFor(product => product.Manufacturer)
            .NotEmpty()
            .WithMessage("Manufacturer is required and must be no more than 50 characters.");

        RuleFor(product => product.Style)
            .NotEmpty()
            .WithMessage("Style is required and must be no more than 50 characters.");

        RuleFor(product => product.PurchasePrice)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Purchase Price is required and must be greater than 0.");

        RuleFor(product => product.SalePrice)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Sale Price is required and must be greater than 0.");

        RuleFor(product => product.QtyOnHand)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Quantity is required and can't be negative.");

        RuleFor(product => product.CommissionPercentage)
            .NotEmpty()
            .InclusiveBetween(0, 100)
            .WithMessage("Commission Percentage is required and must be between 0 and 100.");
    }

}
