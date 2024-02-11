using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Review
{
    public int Id { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public int Rating { get; set; }
    public User User { get; set; }
}