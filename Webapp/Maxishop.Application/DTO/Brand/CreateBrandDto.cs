using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.DTO.Brand
{
    public class CreateBrandDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int EstablishedYear { get; set; }
    }

    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.EstablishedYear).InclusiveBetween(1920, DateTime.UtcNow.Year);
        }
    }
}
