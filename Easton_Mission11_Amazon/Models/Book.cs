using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Easton_Mission11_Amazon.Models;

public partial class Book
{
    [Key]
    public int BookId { get; set; }
    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public string Isbn { get; set; }
    [Required]

    public string Classification { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public int PageCount { get; set; }
    [Required]
    public double Price { get; set; }
}
