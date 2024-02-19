namespace MusicReviewAPI.Models.DTOs;

public class AlbumWithRatingsDTO
{
    public string AlbumName { get; set; }
    public ICollection<int>? Ratings { get; set; }
}