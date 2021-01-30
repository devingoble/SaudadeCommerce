using Ardalis.ApiEndpoints;
using Ardalis.Result;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class List : BaseAsyncEndpoint<Result<ListCategoryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public List(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<ActionResult<Result<ListCategoryResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
