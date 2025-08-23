using FluentValidation;
using Microsoft.AspNetCore.Http;
using Portfolio.Application.DTOs;

namespace Portfolio.Application.Validators
{
    public class ServiceCreateDtoValidator : AbstractValidator<ServicesCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(x => x.ServiceIcon)
                .NotNull().WithMessage("Service icon is required.")
                .Must(f => f.Length > 0).WithMessage("Service icon cannot be empty.");

            RuleFor(x => x.ServiceName)
                .NotEmpty().MaximumLength(100);

            RuleFor(x => x.ServiceDescription)
                .NotEmpty().MaximumLength(500);
        }
    }

    public class ServiceUpdateDtoValidator : AbstractValidator<ServicesUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
            RuleFor(x => x.ServiceName)
                .NotEmpty().MaximumLength(100);

            RuleFor(x => x.ServiceDescription)
                .NotEmpty().MaximumLength(500);

            When(x => x.ServiceIcon != null, () =>
            {
                RuleFor(x => x.ServiceIcon)
                    .Must(f => f.Length > 0).WithMessage("Invalid service icon.")
                    .Must(BeAValidIcon).WithMessage("Only JPG, JPEG, or PNG images are allowed.");
            });
        }

        private bool BeAValidIcon(IFormFile? file)
        {
            if (file == null) return true;
            var allowed = new[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLower();
            return allowed.Contains(ext);
        }
    }

}
