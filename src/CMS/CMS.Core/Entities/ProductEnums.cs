using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Entities
{
    public enum ImageType
    {
        Thumbnail,
        Gallery
    }

    public enum FieldType
    {
        SingleLineText,
        MultiLineText,
        MultiLineRichText,
        DropDownLIst,
        RadioButtonList,
        ColorSelector,
        ImageSelector
    }
}
