using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //added dataannotation to use key and other annotations

namespace NausheenBooks.Models
{
    //made public access
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

    }
}
