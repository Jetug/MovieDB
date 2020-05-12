using System;
using System.Collections.Generic;

namespace MovieDB.Tables
{
    class Actor: IPerson
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; } = null;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } = null;
        public string Country { get; set; }
        public DateTime Birth_Date { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public virtual ICollection<Movie> Movies { get; set; } //= new List<Movie>();

        public Actor() 
        {
            Movies = new HashSet<Movie>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Actor)
                return Id == ((Actor)obj).Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}