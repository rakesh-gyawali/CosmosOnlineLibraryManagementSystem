using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineLibraryMVCApi.Models;

namespace OnlineLibraryMVCApi.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Publication")]
        public string Name { get; set; }

        public string Address { get; set; }

        public PublicationViewModel()
        {
            Id = 0;
        }

        public PublicationViewModel(Publication publication)
        {
            Id = publication.Id;
            Name = publication.Name;
            Address = publication.Address;
        }
    }
}