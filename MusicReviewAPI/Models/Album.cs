namespace MusicReviewAPI.Models;

public class Album
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Band Band { get; set; }
}