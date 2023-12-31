﻿using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    public class Album
    {
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string title, Artist atrist, List<Song> songs)
        {
            Title = title;
            Artist = atrist;
            Songs = new List<Song>();
            Songs = songs;
        }
    }
}
