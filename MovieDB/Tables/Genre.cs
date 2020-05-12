using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDB.Tables
{
    class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public override bool Equals(object obj)
        {
            return Name == ((Genre)obj).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
