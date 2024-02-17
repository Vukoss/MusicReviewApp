using AutoMapper;
using MediatR;
using MusicReviewAPI.Application.Musicians.Commands;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Handlers
{
    public class CreateMusicianHandler : IRequestHandler<CreateMusicianCommand>
    {
        private readonly IMapper _mapper;
        private readonly DataAccessContext _db;

        public CreateMusicianHandler(IMapper mapper, DataAccessContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task Handle(CreateMusicianCommand request, CancellationToken cancellationToken)
        {
            var musician = _mapper.Map<Musician>(request.Musician);
            await _db.Musicians.AddAsync(musician);
            await _db.SaveChangesAsync();
        }
    }
}

