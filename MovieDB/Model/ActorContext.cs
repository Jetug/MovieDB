using MovieDB.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Model
{
    class ActorContext : DbContext
    {
        public ActorContext() : base("DbConnection")
        {

        }
        public DbSet<Actor> Actors { get; set; }
    }
}
