using System.ComponentModel.DataAnnotations;

namespace CineMovies.CinemaData;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public DateTime ReservationDate { get; set; }
    
    public User User { get; set; }
    
    public Movie Movie { get; set; }
}