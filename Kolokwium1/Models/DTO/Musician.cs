using System;
using System.Collections.Generic;

namespace Kolokwium1.Models
{
    public class MusicianDTO
    {
        public MusicianDTO()
        {
        }

        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<Track> tracks { get; set; }

    }
}
