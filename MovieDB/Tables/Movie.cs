using System.Collections.Generic;

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
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public Movie()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            Genres = new HashSet<Genre>();
        }

        public override bool Equals(object obj)
        {
            if(obj is Movie)
                return Id == ((Movie)obj).Id;
            return false; 
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}