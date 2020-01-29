using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Models
{
    public class Category
    {
        public byte Id { get; set; }

        [Display(Name = "Category")]
        [Required]
        public string Name { get; set; }
    }
}