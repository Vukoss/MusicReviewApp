using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Repository.IRepository;

public interface IBandRepository
{
    Task<Band> GetBand(int bandId);
    Task<bool> BandExists(int bandId);
    Task Save();
}