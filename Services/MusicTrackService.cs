using Data;
using Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class MusicTrackService : IMusicTrackService
    {
        private readonly ApplicationDbContext _DbContext;

        public MusicTrackService(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(MusicTrack newMusicTrack)
        {
            _DbContext.Add(newMusicTrack);
            _DbContext.SaveChanges();

        }

        public IEnumerable<MusicTrack> GetAll()
        {
            return _DbContext.MusicTracks;
        }

        public MusicTrack GetById(int id)
        {
            return _DbContext.MusicTracks.FirstOrDefault(MusicTrack => MusicTrack.Id == id);
        }

        public void Remove(MusicTrack musictrack)
        {

            _DbContext.Remove(musictrack);
            _DbContext.SaveChanges();
        }
    }
}
