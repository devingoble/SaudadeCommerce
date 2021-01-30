using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public int ParentCategory { get; private set; }
        public int ImageId { get; set; }

        public Category(string name, string description, string slug, int parentCategory)
        {
            Name = name;
            Description = description;
            Slug = slug;
            ParentCategory = parentCategory;
        }
    }
}
