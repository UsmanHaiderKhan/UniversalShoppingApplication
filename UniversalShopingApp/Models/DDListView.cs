using System.Collections.Generic;
using System.Web.Mvc;

namespace UniversalShopingApp.Models
{
    public class DDListView
    {
        public string Name { get; set; }

        public string Caption { get; set; }

        public IEnumerable<SelectListItem> Values { get; set; }

        public string GlyphIcon { get; set; }
    }
}
