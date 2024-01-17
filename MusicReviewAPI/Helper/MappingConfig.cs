using AutoMapper;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Helper;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Musician, MusicianDTO>().ReverseMap();
        CreateMap<Band, BandDTO>().ReverseMap();
        CreateMap<Genre, GenreDTO>().ReverseMap();
        CreateMap<Album, AlbumDTO>().ReverseMap();

    }
}