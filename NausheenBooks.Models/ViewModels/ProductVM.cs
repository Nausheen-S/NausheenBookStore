using Microsoft.AspNetCore.Mvc.Rendering; //needed for select list
using System;
using System.Collections.Generic;
using System.Text;

namespace NausheenBooks.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
