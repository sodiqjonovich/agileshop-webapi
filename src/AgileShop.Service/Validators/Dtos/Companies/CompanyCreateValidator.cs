using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Companies;
using FluentValidation;

namespace AgileShop.Service.Validators.Dtos.Companies;

public class CompanyCreateValidator : AbstractValidator<CompanyCreateDto>
{
    public CompanyCreateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Company name is required!")
            .MinimumLength(3).WithMessage("Company name must be more than 3 characters!")
            .MaximumLength(50).WithMessage("Company name must be less than 50 characters!");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Company phone number is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");

        int maxImageSizeMB = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");

    }
}
