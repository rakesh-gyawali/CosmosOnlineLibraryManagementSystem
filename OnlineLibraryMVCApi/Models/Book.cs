using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryMVCApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Isbn { get; set; }

        [Required]
        public string Name { get; set; }

        public Author Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public Publication Publication { get; set; }

        [Required]
        public int PublicationId { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public Category Category { get; set; }
        public int? TotalPage { get; set; }
    }
}