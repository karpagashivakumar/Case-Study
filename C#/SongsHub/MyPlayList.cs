using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsHub
{
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private readonly int capacity;

        public MyPlayList()
        {
            capacity = 20;
        }

        public void Add(Song song)
        {
            string[] allowedGenres = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };

            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Playlist is full. Cannot add more songs.");
                return;
            }

            if (!allowedGenres.Contains(song.SongGenre, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid Genre. Allowed Genres: " + string.Join(", ", allowedGenres));
                return;
            }

            myPlayList.Add(song);
            Console.WriteLine("Song added successfully.");
        }

        public void Remove(int songId)
        {
            var song = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (song != null)
            {
                myPlayList.Remove(song);
                Console.WriteLine("Song removed.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.FirstOrDefault(s => s.SongId == songId);
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetAllSongs()
        {
            return myPlayList;
        }
    }
}
