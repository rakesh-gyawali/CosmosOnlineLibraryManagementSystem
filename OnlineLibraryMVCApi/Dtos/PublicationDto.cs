using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Dtos
{
    public class PublicationDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}