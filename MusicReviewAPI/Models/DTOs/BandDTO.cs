namespace MusicReviewAPI.Models.DTOs;

public record BandDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public Genre Genre { get; set; }
}