﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Tables;

namespace MovieDB.Model
{
    class MovieDBRepository
    {
        public IEnumerable<Actor> GetActors()
        {
            var context = new MovieDBContext();
            return context.Actors.Include("Movies").ToList();
        }
    }
}