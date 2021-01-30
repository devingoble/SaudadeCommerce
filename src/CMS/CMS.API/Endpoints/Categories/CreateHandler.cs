using Ardalis.Result;
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
        public Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
