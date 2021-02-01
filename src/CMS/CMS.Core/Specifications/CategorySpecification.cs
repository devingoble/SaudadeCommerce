using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

using CMS.Core.Entities;

namespace CMS.Core.Specifications
{
    public class CategorySpecification : Specification<Category>
    {
        public CategorySpecification(int skip, int take, string searchString) : base()
        {
            Query.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).Skip(skip).Take(take);
        }
    }
}
