using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class CreateValidator : AbstractValidator<CategoryDto>
    {
        public CreateValidator()
        {
            RuleFor(category => category.Name).NotEmpty();
        }
    }

    public class UpdateValidator : AbstractValidator<CategoryDto>
    {
        public UpdateValidator()
        {
            RuleFor(category => category.Id).NotNull();
            RuleFor(category => category.Name).NotEmpty();
        }
    }
}
