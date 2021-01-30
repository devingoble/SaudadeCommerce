using Ardalis.Result;
using MediatR;
using System.Collections.Generic;

namespace CMS.API.Endpoints.Categories
{
    public record CategoryDto(int Id, string Name, string Description);

    public record ListCategoryCommand() : IRequest<Result<ListCategoryResponse>>;
    public record ListCategoryResponse(List<CategoryDto> Categories);

    public record CreateCategoryCommand(string Name, string Description, string Slug, int ParentCategory, int ImageId) : IRequest<Result<CreateCategoryResponse>>;
    public record CreateCategoryResponse(CategoryDto CreatedCategory);
}
