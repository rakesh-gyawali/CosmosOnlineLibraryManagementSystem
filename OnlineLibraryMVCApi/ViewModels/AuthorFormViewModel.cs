using OnlineLibraryMVCApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibraryMVCApi.ViewModels
{
    public class AuthorFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author name")]
        public string Name { get; set; }

        public AuthorFormViewModel()
        {
            Id = 0;
        }

        public AuthorFormViewModel(Author author)
        {
            Name = author.Name;
        }
    }
}