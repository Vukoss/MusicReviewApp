namespace MusicReviewAPI.Models.DTOs;

public record BandDTO
{
    public string Name { get; set; }
    public string? Country { get; set; }
    public DateTime StartDate { get; set; }
}