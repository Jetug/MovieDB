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
            BtnNotEnabled();
            Thread thread = new Thread(GetMoviesFromDB);
            thread.Start();

            //GetMoviesFromDB();
        }

        /// <summary>
        /// Получает список актёров из БД в новом потоке.
        /// </summary>
        public void GetActorsList()
        {
            BtnNotEnabled();
            Thread thread = new Thread(GetActorsFromDB);
            thread.Start();

            //GetActorsFromDB();
        }

        public void RecordMovie(Movie movie)
        {
            using (MovieContext db = new MovieContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public void RecordActor(Actor actor)
        {
            using (ActorContext db = new ActorContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (MovieContext db = new MovieContext())
            {
                var updMovie = db.Movies
                .Where(c => c.Id == movie.Id)
                .FirstOrDefault();

                updMovie.Title = movie.Title;
                updMovie.Description = movie.Description;
                updMovie.Cover = movie.Cover;
                updMovie.Duration = movie.Duration;
                updMovie.Year = movie.Year;

                db.SaveChanges();
            }
        }

        public void UpdateActor(Actor actor)
        {
            using (ActorContext db = new ActorContext())
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

                db.SaveChanges();
            }
        }

        public void RemoveMovie(Movie movie)
        {
            using (MovieContext db = new MovieContext())
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
            using (ActorContext db = new ActorContext())
            {
                Actor delActor = db.Actors
               .Where(a => a.Id == actor.Id)
               .FirstOrDefault();

                db.Actors.Remove(delActor);
                db.SaveChanges();
            }
        }

        private byte[] BitmapToByte(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private BitmapImage ByteToBitmap(byte[] bytes)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(bytes);
            bitmap.EndInit();

            return bitmap;
        }

        private byte[] PathToByte(string iFile)
        {
            FileInfo fInfo = new FileInfo(iFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            return br.ReadBytes((int)numBytes);
        }

        private void GetMoviesFromDB()
        {
            using (MovieContext db = new MovieContext())
            {
                List<Movie> movies = new List<Movie>();
                foreach (Movie m in db.Movies)
                {
                    movies.Add(m);
                }
                ShowMovies(movies);
            }
            BtnEnabled();
        }

        private void GetActorsFromDB()
        {
            using (ActorContext db = new ActorContext())
            {
                List<Actor> actors = new List<Actor>();
                foreach (Actor a in db.Actors)
                {
                    actors.Add(a);
                }
                ShowActors(actors);
            }
            BtnEnabled();
        }
    }
}
