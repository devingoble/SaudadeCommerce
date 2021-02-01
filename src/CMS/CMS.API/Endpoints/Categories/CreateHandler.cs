using Ardalis.Result;

using AutoMapper;

using CMS.Core.Entities;
using CMS.Core.Interfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class CreateHandler : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryResponse>>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly Mapper _mapper;

        public CreateHandler(IAsyncRepository<Category> repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCat = new Category(request.Name, request.Description, request.Slug, request.ParentCategory);
            var createResult = await _repository.AddAsync(newCat, cancellationToken);

            var result = new Result<CreateCategoryResponse>(new CreateCategoryResponse(_mapper.Map<CategoryDto>(createResult)));

            return result;
        }
    }
}
