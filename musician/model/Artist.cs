using System;
using System.Collections.Generic;

namespace model
{
    public class Artist
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<Album> Albums { get; set; }

        public Artist(string name, Genre genre)
        {
            Name = name;
            Genre = genre;
            Albums = new List<Album>();
        }
    }
} 
