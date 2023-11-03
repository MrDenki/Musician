using model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace controller
{
    public class Catalog
    {
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Compilation> Compilations { get; set; }
        public List<Genre> Genres { get; set; }

        public Catalog()
        {
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Compilations = new List<Compilation>();
            Genres = new List<Genre>();
        }

        // Artist

        public void AddArtist(string name, Genre genre)
        {
            Artist artist = new Artist(name, genre);
            Artists.Add(artist);
        }

        public void PrintArtists()
        {
            Console.WriteLine("Имя\t\tЖанр\t\tАльбом\n");
            foreach (var item in Artists)
            {
                Console.Write($"{item.Name}\t{item.Genre.Name}\t");
                foreach (var albums in item.Albums)
                {
                    if (item.Albums.IndexOf(albums) == 0)
                    {
                        Console.WriteLine($"{albums.Title}");
                    }
                    else if (item.Albums.IndexOf(albums) != 0)
                    {
                        Console.WriteLine($"\t\t\t\t{albums.Title}");
                    }
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }

        public Artist FindArtist(string name)
        {
            return Artists.Find(artist => artist.Name == name);
        }
        
        public void PrintArtist(Artist artist)
        {
            if (artist is null)
            {
                Console.WriteLine("Такого Артиста не существует!");
            }
            else
            {
                Console.WriteLine($"Имя\t\tЖанр\t\tНаименование альбома\tТреки");
                Console.Write($"{artist.Name}\t{artist.Genre.Name}\t\t");
                foreach (var item in artist.Albums)
                {
                    Console.Write($"{item.Title}\t\t");
                    foreach (var song in item.Songs)
                    {
                        if (item.Songs.IndexOf(song) == 0)
                        {
                            Console.WriteLine($"{song.Title}");
                        }
                        else if (item.Songs.IndexOf(song) != 0)
                        {
                            Console.WriteLine($"\t\t\t\t\t\t\t{song.Title}");
                        }
                    }
                }
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }

        public Artist GetArtist(int n)
        {
            return Artists[n - 1];
        }

        // Album

        public void AddAlbum(string name, Artist atrist, List<Song> songs)
        {
            Album album = new Album(name, atrist, songs);
            Albums.Add(album);
            atrist.Albums.Add(album);
        }

        public void PrintAlbums()
        {
            Console.WriteLine("Имя\tАртист\tТрек\n");
            foreach (var item in Albums)
            {
                Console.Write($"{item.Title}\t{item.Artist.Name}\t");

                foreach (var song in item.Songs)
                {
                    if (item.Songs.IndexOf(song) == 0)
                    {
                        Console.Write($"{song.Title}\n");
                    }
                    else if (item.Songs.IndexOf(song) != 0)
                    {
                        Console.WriteLine($"\t\t\t{song.Title}");
                    }
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }

        public Album FindAlbum(string title)
        {
            return Albums.Find(album => album.Title == title);
        }

        public void PrintAlbum(Album album)
        {
            if (album is null)
            {
                Console.WriteLine("Такого Альбома не существует!");
            }
            else
            {
                Console.WriteLine($"Наименование альбома\tАртист\t\tТреки");
                Console.Write($"{album.Title}\t\t\t{album.Artist.Name}\t");
                foreach (var item in album.Songs)
                {
                    if (album.Songs.IndexOf(item) == 0)
                    {
                        Console.Write($"{item.Title}\n");
                    }
                    else if (album.Songs.IndexOf(item) != 0)
                    {
                        Console.WriteLine($"\t\t\t\t\t{item.Title}");
                    }
                }
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }


        // Song

        public List<Song> GetListSong(string[] traks)
        {
            List<Song> songs = new List<Song>();
            foreach (var item in traks)
            {
                Song song = new Song(item);
                songs.Add(song);
            }
            return songs; 
        }

        public Album FindSongByGenre(string genre)
        {
            return Albums.Find(item => item.Artist.Genre.Name == genre);
        }

        public void PrintSongsByAlbum(Album albums)
        {
            if (albums is null)
            {
                Console.WriteLine("Такого Альбома не существует!");
            }
            else
            {
                foreach (var item in albums.Songs)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }

        public void PrintAllSongs()
        {
            int i = 1;
            foreach (var item in Albums)
            {
                Console.WriteLine($"{i}\t{item.Title}\t{item.Artist.Name}\t");
                foreach (var song in item.Songs)
                {
                    Console.WriteLine($"{i}\t{song.Title}");
                    i++;
                }
                i++;
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }


        // Genre

        public void AddGenre(string title)
        {
            Genre genre = new Genre(title);
            Genres.Add(genre);
        }

        public Genre GetGenre(int n)
        {
            return Genres[n - 1];
        }

        public void PrintGenre()
        {
            for (int i = 0; i < Genres.Count(); i++)
            {
                Console.WriteLine($"{i + 1}\t-\t{Genres[i].Name}");
            }
        }


        // Compilation

        public Compilation FindCompilation(string title)
        {
            return Compilations.Find(compilation => compilation.Title == title);
        }            
        
        public void AddCompilation(string title, string[] songs)
        {
            Compilation compilation = new Compilation(title, GetListSong(songs));
            Compilations.Add(compilation);
        }

        public void PrintCompilation()
        {
            Console.WriteLine($"Наименование сборника\t\tТрек");
            foreach (var item in Compilations)
            {
                Console.Write($"{item.Title}\t");
                foreach (var songs in item.Songs)
                {
                    if (item.Songs.IndexOf(songs) == 0)
                    {
                        Console.Write($"{songs.Title}\n");
                    }
                    else if (item.Songs.IndexOf(songs) != 0)
                    {
                        Console.WriteLine($"\t\t\t\t\t{songs.Title}");
                    }
                }
            }
            Console.WriteLine("Нажмите на любую лавишу");
            Console.ReadKey();
        }
    }
}
