using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineMovies.CinemaData;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [Required]
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    
    [Required]
    public DateTime ReservationDate { get; set; }
    
    public User User { get; set; }
    
    public Movie Movie { get; set; }
}