using MovieDB.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Model
{
    class MovieContext : DbContext
    {
        public MovieContext() : base("DbConnection")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
