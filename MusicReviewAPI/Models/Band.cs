using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Band
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public Genre Genre { get; set; }
    
    public ICollection<Album>? Albums { get; set; }
    public ICollection<MusicianBand> MusicianBands { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
}