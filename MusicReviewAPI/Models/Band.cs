namespace MusicReviewAPI.Models;

public class Band
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public Genre Genre { get; set; }
    public ICollection<Album> Albums { get; set; }
    public ICollection<MusicianBand> MusicianBands { get; set; }
}