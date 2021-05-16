using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

using CMS.Core.Entities;
using CMS.Core.Specifications.Filters;

namespace CMS.Core.Specifications
{
    public class CategorySpecification : Specification<Category>
    {
        public CategorySpecification(CategoryFilter categoryFilter) : base()
        {
            if(categoryFilter == null)
            {
                throw new ArgumentNullException(nameof(categoryFilter));
            }

            Query.Where(c => c.Name.Contains(categoryFilter.Name, StringComparison.OrdinalIgnoreCase))
                .Skip(categoryFilter.PaginationOptions.Page * categoryFilter.PaginationOptions.PageSize)
                .Take(categoryFilter.PaginationOptions.PageSize);
        }
    }
}
