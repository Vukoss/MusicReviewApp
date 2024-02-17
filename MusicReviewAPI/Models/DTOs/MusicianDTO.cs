namespace MusicReviewAPI.Models.DTOs;

public record MusicianDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Nickname { get; set; }
}