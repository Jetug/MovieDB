using System;
using System.Collections.Generic;

namespace MovieDB.Tables
{
    interface IPerson
    {
        int Id { get; set; }
        byte[] Photo { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        string Country { get; set; }
        DateTime Birth_Date { get; set; }
        ICollection<Movie> Movies { get; set; }
    }
}
