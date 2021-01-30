using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? LongDescription { get; private set; }
        public string? PrivateComments { get; private set; }
        public decimal BasePrice { get; private set; }
        public int? IsVariantOf { get; private set; }
        public bool IsVariant {
            get 
            {
                return IsVariantOf != null;
            }
        }
        public int NumberInStock { get; private set; }
        public bool AllowBackOrder { get; set; }

        private readonly List<CustomField> _customFields = new List<CustomField>();

        public IReadOnlyCollection<CustomField> CustomFields => _customFields.AsReadOnly();

        public Product(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }

        public void SetDescriptions(string? shortDescription, string? longDescription, string? privateComments)
        {
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            PrivateComments = privateComments;
        }

        public void AddCustomField(string name, string description, FieldType fieldType)
        {
            var field = new CustomField(name, description, fieldType);

            _customFields.Add(field);
        }
    }
}
