using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Models
{
    public class Publication
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}