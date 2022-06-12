using Kolokwium1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicianController : ControllerBase
    {

        private readonly _2019SBDContext _dbcontext;

        public MusicianController(_2019SBDContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public MusicianDTO GetMusician(int id)
        {
            Musician musician1 = _dbcontext.Musicians.Find(id);
            MusicianDTO musician = new MusicianDTO();
            musician.IdMusician = musician1.IdMusician;
            musician.FirstName = musician1.FirstName;
            musician.LastName = musician1.LastName;
            musician.Nickname = musician1.Nickname;
            List<Track> tracks = new ();
            Console.WriteLine(musician1.MusicianTracks);
            foreach (var track in musician1.MusicianTracks)
            {
                Track track1 = _dbcontext.Tracks.Find(track.IdTrack);
                tracks.Add(track1);
            }
            musician.tracks = tracks;
            return musician;
        }
    }
}
