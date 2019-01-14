using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityModels;

namespace Data
{
    public interface IMusicTrackService
    {
        IEnumerable<MusicTrack> GetAll();

        MusicTrack GetById(int id);

        void Add(MusicTrack newMusicTrack);

        void Remove(MusicTrack musictrack);

    }
}
