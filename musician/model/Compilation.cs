using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    public class Compilation
    {
        public string Title { get; set; }
        public List<Song> Songs { get; set; }

        public Compilation(string title, List<Song> songs)
        {
            Title = title;
            Songs = songs; 
        }
    }
}
