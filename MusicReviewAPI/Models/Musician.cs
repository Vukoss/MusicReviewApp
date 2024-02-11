using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Musician
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Nickname { get; set; }
    public ICollection<MusicianBand>? MusicianBands { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}