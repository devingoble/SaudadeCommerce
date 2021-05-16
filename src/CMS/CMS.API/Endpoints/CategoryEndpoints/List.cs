using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Ardalis.Specification;

using AutoMapper;

using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Specifications;
using CMS.Core.Specifications.Filters;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class List : BaseAsyncEndpoint<List.ListCommand, List.ListResponse>
    {
        private readonly IMediator _mediator;

        public List(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/catalog/categories")]
        public async override Task<ActionResult<ListResponse>> HandleAsync(ListCommand request, CancellationToken cancellationToken = default)
        {
            var results = await _mediator.Send(request, cancellationToken);

            return this.ToActionResult(results);
        }

        public record ListCommand(string SearchString, PaginationOptions PaginationOptions, IReadOnlyList<SortField> SortFields) : IRequest<Result<ListResponse>>;
        public record SortField(string FieldName, OrderTypeEnum SortType);
        public record ListResponse(IReadOnlyList<CategoryResponse> Categories, int CategoryCount, int CurrentPage, int PageCount);
        public record CategoryResponse(int Id, string Name, string Description);

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Category, CategoryResponse>();
                CreateMap<ListCommand, CategoryFilter>();
            }
        }

        public class ListHandler : IRequestHandler<ListCommand, Result<ListResponse>>
        {
            private readonly IAsyncRepository<Category> _repository;
            private readonly Mapper _mapper;

            public ListHandler(IAsyncRepository<Category> repository, Mapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ListResponse>> Handle(ListCommand request, CancellationToken cancellationToken)
            {
                var filter = _mapper.Map<ListCommand, CategoryFilter>(request);
                var catSpec = new CategorySpecification(filter);
                var totalCategories = await _repository.CountAsync(catSpec, cancellationToken);
                var pageCount = (int)Math.Ceiling((decimal)totalCategories / request.PaginationOptions.PageSize);
                var categories = await _repository.ListAsync(catSpec, cancellationToken);

                var result = new Result<ListResponse>(new ListResponse(_mapper.Map<IReadOnlyList<CategoryResponse>>(categories), totalCategories, request.PaginationOptions.Page, pageCount));

                return result;
            }
        }
    }
}
