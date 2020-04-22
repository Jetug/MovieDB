﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //public Actor(int id, byte[] photo, string name, string surname, string patronymic, string country, DateTime birthDate, ICollection<Movie> movies)
        //{
        //    Id = id;
        //    Photo = photo;
        //    Name = name;
        //    Surname = surname;
        //    Patronymic = patronymic;
        //    Country = country;
        //    Birth_Date = birthDate;
        //    Movies = movies;
        //    //Movies = new List<Movie>();
        //}

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