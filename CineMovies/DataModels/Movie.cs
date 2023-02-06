using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace CineMovies.CinemaData;
[Table("Movies")]
public class Movie
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Director { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Genre { get; set; }
    
    [Required]
    public int Duration { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public int AgeRestriction { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
    
    public List<Reservation> Reservations { get; set; }
}