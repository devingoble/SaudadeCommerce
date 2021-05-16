using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Specifications.Filters
{
    public record CategoryFilter(string Name, PaginationOptions PaginationOptions, IReadOnlyList<SortField> SortFields) :
        BaseFilter(PaginationOptions, SortFields);
}
