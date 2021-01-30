using Ardalis.Result;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.API.Endpoints.Categories
{
    public class ListHandler : IRequestHandler<ListCategoryCommand, Result<ListCategoryResponse>>
    {
        public Task<Result<ListCategoryResponse>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
