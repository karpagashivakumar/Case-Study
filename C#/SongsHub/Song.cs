using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsHub
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongGenre { get; set; }

        public Song(int id, string name, string genre)
        {
            SongId = id;
            SongName = name;
            SongGenre = genre;
        }
    }

}
