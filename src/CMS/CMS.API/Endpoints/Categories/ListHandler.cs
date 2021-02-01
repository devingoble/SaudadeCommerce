using Ardalis.Result;

using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CMS.Core.Interfaces;
using CMS.Core.Entities;
using CMS.Core.Specifications;

namespace CMS.API.Endpoints.Categories
{
    public class ListHandler : IRequestHandler<ListCategoryCommand, Result<ListCategoryResponse>>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly Mapper _mapper;

        public ListHandler(IAsyncRepository<Category> repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ListCategoryResponse>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
        {
            var catSpec = new CategorySpecification(request.PageIndex * request.PageSize, request.PageSize, request.SearchString);
            var categories = await _repository.ListAsync(catSpec, cancellationToken);

            var result = new Result<ListCategoryResponse>(new ListCategoryResponse(_mapper.Map<IEnumerable<CategoryDto>>(categories)));

            return result;
        }
    }
}
