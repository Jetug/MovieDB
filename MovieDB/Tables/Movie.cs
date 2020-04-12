using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MovieDB.Tables
{
    class Movie
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public byte[] Cover { get; set; } = null;
        public int Duration { get; set; } = 0;
        public int Year { get; set; } = 0;
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();

        public Movie()
        {
            //Actors = new List<Actor>();
        }

        public override bool Equals(object obj)
        {
            Movie movie = (Movie)obj;
            return Id == movie.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}