namespace MusicReviewAPI.Models;

public class MusicianBand
{
    public int MusicianId { get; set; }
    public int BandId { get; set; }
    public Band Band { get; set; }
    public Musician Musician { get; set; }
}