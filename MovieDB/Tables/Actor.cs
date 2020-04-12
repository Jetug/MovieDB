using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieDB.Tables
{
    class Actor
    {
        public int Id { get; set; }// = 0;
        public byte[] Photo { get; set; }// = null;
        public string Name { get; set; }// = "";
        public string Surname { get; set; }// = "";
        public string Patronymic { get; set; }// = null;
        public string Country { get; set; }// = "";
        public DateTime Birth_Date { get; set; }// = new DateTime(DateTime.Now.Year, 1, 1);
        public ICollection<Movie> Movies { get; set; }// = new List<Movie>();

        public Actor() { }

        public Actor(int id, byte[] photo, string name, string surname, string patronymic, string country, DateTime birthDate, ICollection<Movie> movies)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Country = country;
            Birth_Date = birthDate;
            Movies = movies;
        }

        public override bool Equals(object obj)
        {
            Actor actor = (Actor)obj;
            return Id == actor.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}