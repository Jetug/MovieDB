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
        public int Id { get; set; } = 0;
        public byte[] Photo { get; set; } = null;
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Patronymic { get; set; } = null;
        public string Country { get; set; } = "";
        public DateTime Birth_Date { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public ICollection<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new List<Movie>();
        }
    }
}