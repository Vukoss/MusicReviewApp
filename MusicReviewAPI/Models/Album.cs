using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Album
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Band Band { get; set; } 
    public ICollection<Review>? Reviews { get; set; }
}