using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}