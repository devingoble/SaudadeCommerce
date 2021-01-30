using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class CustomField : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public FieldType CustomFieldType { get; private set; }

        public CustomField(string name, string description, FieldType customFieldType)
        {
            Name = name;
            Description = description;
            CustomFieldType = customFieldType;
        }
    }
}
