using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class MusicTrackList
    {
        public IEnumerable<MusicTrackListingModel> MusicTracks { get; set; }

    }
}
