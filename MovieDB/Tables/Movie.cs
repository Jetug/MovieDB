using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MovieDB.Tables
{
    class Movie
    {
        public int ID { get; set; } = 0;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public BitmapImage Cover { get; set; } = null;
        public int Duration { get; set; } = 0;
        public int Year { get; set; } = 0;
        public List<int> ActorsID { get; set; } = new List<int>();
    }
}