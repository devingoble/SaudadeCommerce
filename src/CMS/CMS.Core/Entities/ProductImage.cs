using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Title { get; set; }
        public ImageType ImageType { get; set; }
        public string Url { get; set; }
    }
}
