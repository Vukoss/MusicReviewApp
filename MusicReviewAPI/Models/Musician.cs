namespace MusicReviewAPI.Models;

public class Musician
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public ICollection<MusicianBand> MusicianBands { get; set; }
}