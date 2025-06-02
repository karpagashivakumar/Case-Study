using SongsHub;
using System;

class Program
{
    static void Main()
    {
        MyPlayList playlist = new MyPlayList();

        while (true)
        {
            Console.WriteLine("\nEnter 1: Add Song");
            Console.WriteLine("Enter 2: Remove Song by Id");
            Console.WriteLine("Enter 3: Get Song By Id");
            Console.WriteLine("Enter 4: Get Song by Name");
            Console.WriteLine("Enter 5: Get All Songs");
            Console.WriteLine("Enter 0: Exit");

            Console.Write("Choice: ");
            int choice = int.TryParse(Console.ReadLine(), out int c) ? c : -1;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Song Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Song Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Song Genre: ");
                    string genre = Console.ReadLine();

                    Song song = new Song(id, name, genre);
                    playlist.Add(song);
                    break;

                case 2:
                    Console.Write("Enter Song Id to Remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    playlist.Remove(removeId);
                    break;

                case 3:
                    Console.Write("Enter Song Id to Search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    var songById = playlist.GetSongById(searchId);
                    if (songById != null)
                        Console.WriteLine($"ID: {songById.SongId}, Name: {songById.SongName}, Genre: {songById.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case 4:
                    Console.Write("Enter Song Name to Search: ");
                    string searchName = Console.ReadLine();
                    var songByName = playlist.GetSongByName(searchName);
                    if (songByName != null)
                        Console.WriteLine($"ID: {songByName.SongId}, Name: {songByName.SongName}, Genre: {songByName.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case 5:
                    var allSongs = playlist.GetAllSongs();
                    if (allSongs.Count == 0)
                        Console.WriteLine("Playlist is empty.");
                    else
                    {
                        Console.WriteLine("Playlist Songs:");
                        foreach (var s in allSongs)
                            Console.WriteLine($"ID: {s.SongId}, Name: {s.SongName}, Genre: {s.SongGenre}");
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}