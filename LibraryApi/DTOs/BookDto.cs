﻿using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTOs
{
    public class BookDTO
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Author { get; set; }
        public string? ImageLink { get; set; }
        public string? Language { get; set; }
        public string? Link { get; set; }
        public int? Pages { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Format { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
