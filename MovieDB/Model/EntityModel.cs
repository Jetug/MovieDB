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
        public Action<List<Director>> ShowDirectors;

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
        }

        /// <summary>
        /// Получает список актёров из БД в новом потоке.
        /// </summary>
        public void GetActorsList()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetActorsFromDB);
            thread.Start();
        }

        public void GetDirectorsList()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetDirectorsFromDB);
            thread.Start();
        }

        public void GetMoviesList_NoMTM()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetMoviesFromDB_NoMTM);
            thread.Start();
        }

        public void GetActorsList_NoMTM()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetActorsFromDB_NoMTM);
            thread.Start();
        }

        public void GetDirectorsList_NoMTM()
        {
            BtnNotEnabled?.Invoke();
            Thread thread = new Thread(GetDirectorsFromDB_NoMTM);
            thread.Start();
        }

        public void AddOrUpdate(object entity)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                object obj = null;
                
                switch (entity)
                {
                    case Movie m:
                        obj = db.Movies.Find(m.Id);
                        break;
                    case Actor a:
                        obj = db.Actors.Find(a.Id);
                        break;
                    case Director d:
                        obj = db.Directors.Find(d.Id);
                        break;
                }

                if (obj == null)
                    RecordEntity(entity);
                else
                    UpdateEntity(entity);
            }
        }


        public void RecordEntity(object entity)
        {
            switch (entity)
            {
                case Movie m:
                    RecordMovie(m);
                    break;
                case IPerson a:
                    RecordPerson(a);
                    break;
            }
        }

        public void UpdateEntity(object entity)
        {
            switch (entity)
            {
                case Movie m:
                    UpdateMovie(m);
                    break;
                case IPerson a:
                    UpdatePerson(a);
                    break;
            }
        }

        public void RemoveEntity(object entity)
        {
            switch (entity)
            {
                case Movie m:
                    RemoveMovie(m);
                    break;
                case IPerson a:
                    RemovePerson(a);
                    break;
            }
        }

        public void RecordMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                movie.Actors = movie.Actors.Select( a => a = db.Actors.Find(a.Id) ).ToList();
                db.Movies.Add(movie);  
                db.SaveChanges();
            }
        }

        public void RecordPerson(IPerson person)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                person.Movies = person.Movies.Select(m => m = db.Movies.Find(m.Id)).ToList();
                if (person is Actor)
                {
                    db.Actors.Add((Actor)person);
                }
                else if (person is Director)
                {
                    db.Directors.Add((Director)person);
                }
                db.SaveChanges();
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                var updMovie = db.Movies.Include("Actors")
                .Where(c => c.Id == movie.Id)
                .FirstOrDefault();

                updMovie.Title = movie.Title;
                updMovie.Description = movie.Description;
                updMovie.Cover = movie.Cover;
                updMovie.Duration = movie.Duration;
                updMovie.Year = movie.Year;

                IEnumerable<Actor> AddedActors = movie.Actors.Where(actor => !updMovie.Actors.Contains(actor));
                IEnumerable<Actor> RemovedActors = new List<Actor>(updMovie.Actors.Where(actor => !movie.Actors.Contains(actor)));

                foreach (Actor a in AddedActors)
                {
                    updMovie.Actors.Add(db.Actors.Find(a.Id));
                }

                foreach (Actor a in RemovedActors)
                {
                    updMovie.Actors.Remove(db.Actors.Find(a.Id));
                }

                db.SaveChanges();
            }
        }

        public void UpdatePerson(IPerson person)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                IPerson updActor = null;

                if (person is Actor)
                {
                    updActor = db.Actors
                        .Where(c => c.Id == person.Id)
                        .FirstOrDefault();
                }
                else if (person is Director)
                {
                    updActor = db.Directors
                        .Where(c => c.Id == person.Id)
                        .FirstOrDefault();
                }

                //updActor = db.Actors
                //        .Where(c => c.Id == person.Id)
                //        .FirstOrDefault();

                updActor.Photo = person.Photo;
                updActor.Name = person.Name;
                updActor.Surname = person.Surname;
                updActor.Patronymic = person.Patronymic;
                updActor.Country = person.Country;
                updActor.Birth_Date = person.Birth_Date;

                IEnumerable<Movie> AddedMovies = person.Movies.Where(movie => !updActor.Movies.Contains(movie));
                IEnumerable<Movie> RemovedMovies = new List<Movie>(updActor.Movies.Where(movie => !person.Movies.Contains(movie)));

                foreach (Movie m in AddedMovies)
                {
                    updActor.Movies.Add(db.Movies.Find(m.Id));
                }

                foreach (Movie m in RemovedMovies)
                {
                    updActor.Movies.Remove(db.Movies.Find(m.Id));
                }

                db.SaveChanges();
            }
        }

        public void RemoveMovie(Movie movie)
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                Movie delMovie = db.Movies
                    .Include("Actors")
                    .Where(item => item.Id == movie.Id)
                    .FirstOrDefault();

                db.Movies.Remove(delMovie);
                db.SaveChanges();
            }
        }

        public void RemovePerson(IPerson person)
        {
            using (MovieDBContext db = new MovieDBContext())
            {

                if (person is Actor)
                {
                    Actor delActor = db.Actors
                        .Include("Movies")
                        .Where(a => a.Id == person.Id)
                        .FirstOrDefault();
                    db.Actors.Remove(delActor);
                }
                else if (person is Director)
                {
                    Director delActor = db.Directors
                        .Include("Movies")
                        .Where(a => a.Id == person.Id)
                        .FirstOrDefault();
                    db.Directors.Remove(delActor);
                }
                
                db.SaveChanges();
            }
        }

        private void GetMoviesFromDB()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowMovies(db.Movies.Include("Actors").Include("Directors").ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetActorsFromDB()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowActors(db.Actors.Include("Movies").ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetDirectorsFromDB()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowDirectors(db.Directors.Include("Movies").ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetMoviesFromDB_NoMTM()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowMovies(db.Movies.ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetActorsFromDB_NoMTM()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowActors(db.Actors.ToList());
            }
            BtnEnabled?.Invoke();
        }

        private void GetDirectorsFromDB_NoMTM()
        {
            using (MovieDBContext db = new MovieDBContext())
            {
                ShowDirectors(db.Directors.ToList());
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
