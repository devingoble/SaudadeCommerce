using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class List : BaseAsyncEndpoint<ListCategoryCommand, ListCategoryResponse>
    {
        private readonly IMediator _mediator;

        public List(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/catalog/categories")]
        public async override Task<ActionResult<ListCategoryResponse>> HandleAsync(ListCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var results = await _mediator.Send(request, cancellationToken);

            return this.ToActionResult(results);
        }
    }
}
