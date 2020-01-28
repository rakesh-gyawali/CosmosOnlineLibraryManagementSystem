﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineLibraryMVCApi.Models;

namespace OnlineLibraryMVCApi.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ISBN")]
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

        [Display(Name = "No. of Page")]
        public int? TotalPage { get; set; }
    }
}