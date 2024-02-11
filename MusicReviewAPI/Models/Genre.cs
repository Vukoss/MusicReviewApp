using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Genre
{
    public int Id { get; set; }
    [Required]
    public string GenreName { get; set; }
    public ICollection<Band>? Bands { get; set; }
}