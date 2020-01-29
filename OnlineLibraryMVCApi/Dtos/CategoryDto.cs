using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibraryMVCApi.Dtos
{
    public class CategoryDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}