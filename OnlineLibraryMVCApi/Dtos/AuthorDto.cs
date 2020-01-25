using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}