using System;
using System.Collections.Generic;

#nullable disable

namespace Kolokwium1.Models
{
    public partial class Track
    {
        public Track()
        {
            MusicianTracks = new HashSet<MusicianTrack>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double? Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

        public virtual Album IdMusicAlbumNavigation { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}
