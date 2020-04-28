using System;
using System.Collections.Generic;

namespace MovieDB.Tables
{
    class Director: IPerson
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; } = null;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } = null;
        public string Country { get; set; }
        public DateTime Birth_Date { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public virtual ICollection<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public override bool Equals(object obj)
        {
            Director director = (Director)obj;
            return Id == director.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
