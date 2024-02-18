namespace MusicReviewAPI.Models.DTOs;

public record AlbumDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Country { get; set; }
    public string? Label { get; set; }
    public double? Duration { get; set; }
}