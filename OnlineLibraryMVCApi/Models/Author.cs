using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}