using Ardalis.Specification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Specifications.Filters
{
    public record BaseFilter(PaginationOptions PaginationOptions, IReadOnlyList<SortField> SortFields);

    public record PaginationOptions(bool IsPaginationEnabled, int Page, int PageSize);

    public record SortField(string FieldName, OrderTypeEnum SortType);
}
