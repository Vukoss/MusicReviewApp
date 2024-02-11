namespace MusicReviewAPI.Models.DTOs;

public class AlbumReviewsDTO
{
    public string AlbumName { get; set; }
    public ICollection<int> Ratings { get; set; }
}