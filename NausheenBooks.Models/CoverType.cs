using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //added dataannotation to use key and other annotations

namespace NausheenBooks.Models
{
    public class CoverType
    {
        [Key]
        public int CoverTypeId { get; set; }

        [Display(Name = "Cover Type Name")]
        [Required]
        [MaxLength(50)]
        public string CoverTypeName { get; set; }
    }
}
