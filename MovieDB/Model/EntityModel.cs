using MovieDB.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Data.Entity;

namespace MovieDB.Model
{
    class EntityModel
    {
        public Action<List<Movie>> ShowMovies;
        public Action<List<Actor>> ShowActors;

        public Action BtnNotEnabled;
        public Action BtnEnabled;

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True";

        /// <summary>
        /// Получает список фильмов из БД в новом потоке.
        /// </summary>
        public void GetMoviesList()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetMoviesFromDB);
            thread.Start();

            //GetMoviesFromDB();
        }

        /// <summary>
        /// Получает список актёров из БД в новом потоке.
        /// </summary>
        public void GetActorsList()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetActorsFromDB);
            thread.Start();

            //GetActorsFromDB();
        }

        //private void FillMovieWithActors(ref Movie movie)
        //{
        //    using (MovieDBContext db = new MovieDBContext())
        //    {
        //        List<Actor> actors = new List<Actor>(movie.Actors);
        //        movie.Actors.Clear();

        //        foreach (var a in actors)
        //        {
        //            movie.Actors.Add(db.Actors.Find(a.Id));
        //        }
        //    }
        //}


        public void AddActorsToMovie(ref Movie movie, List<Actor> actors)
        {
            //using (MovieDBContext db = new MovieDBContext())
            //{
            //    foreach (var a in actors)
            //    {
            //        movie.Actors.Add(db.Actors.Find(a.Id));
            //    }
            //}
        }

        public void RecordMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public void RecordActor(Actor actor)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                var updMovie = db.Movies
                .Where(c => c.Id == movie.Id)
                .FirstOrDefault();

                updMovie.Title = movie.Title;
                updMovie.Description = movie.Description;
                updMovie.Cover = movie.Cover;
                updMovie.Duration = movie.Duration;
                updMovie.Year = movie.Year;
                updMovie.Actors = movie.Actors;

                db.SaveChanges();
            }
        }

        public void UpdateActor(Actor actor)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                var updActor = db.Actors
                .Where(c => c.Id == actor.Id)
                .FirstOrDefault();

                updActor.Photo = actor.Photo;
                updActor.Name = actor.Name;
                updActor.Surname = actor.Surname;
                updActor.Patronymic = actor.Patronymic;
                updActor.Country = actor.Country;
                updActor.Birth_Date = actor.Birth_Date;
                updActor.Movies = actor.Movies;

                db.SaveChanges();
            }
        }

        public void RemoveMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                Movie delMovie = db.Movies
               .Where(m => m.Id == movie.Id)
               .FirstOrDefault();

                db.Movies.Remove(delMovie);
                db.SaveChanges();
            }
        }

        public void RemoveActor(Actor actor)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                Actor delActor = db.Actors
               .Where(a => a.Id == actor.Id)
               .FirstOrDefault();

                db.Actors.Remove(delActor);
                db.SaveChanges();
            }
        }

        private void GetMoviesFromDB()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowMovies(db.Movies.Include("Actors").ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetActorsFromDB()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                List<Actor> bufActors = db.Actors.Include("Movies").ToList();
                ShowActors(bufActors);
            }
            BtnEnabled?.Invoke();
        }

        public List<Actor> SearchActor(string searchString, IEnumerable<Actor> actors)
        {
            List<Actor> searchedActors = new List<Actor>();

            string name = searchString;
            string surname = "";

            foreach (char c in searchString)
            {

            }

            searchedActors = actors.Where( (a) => 
            {
                if (a.Name == name || a.Surname == name)
                    return true;
                else
                    return false;

            }).ToList();

            return searchedActors;
        }


    }
}
