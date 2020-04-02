using MovieDB.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MovieDB.Model
{
    public enum RecordMode
    {
        Adding,
        Update
    }

    class MainModel
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

        public void RecordMovie(Movie movie, RecordMode mode)
        {
            string recordMovie = mode == RecordMode.Adding ?
                "INSERT INTO movies(title, description, cover, duration, year) VALUES(@title, @description, @cover, @duration, @year)" :
                "UPDATE movies SET title = @title, description = @description, cover = @cover, duration = @duration, year = @year WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(recordMovie, connection);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@description", movie.Description);
                    command.Parameters.AddWithValue("@cover", movie.Cover);
                    command.Parameters.AddWithValue("@duration", movie.Duration);
                    command.Parameters.AddWithValue("@year", movie.Year);
                    command.Parameters.AddWithValue("@id", movie.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void RecordActor(Actor actor, RecordMode mode)
        {
            string recordActor = mode == RecordMode.Adding ?
                "INSERT INTO actors(photo, name, surname, patronymic, country, birth_date) VALUES(@photo, @name, @surname, @patronymic, @country, @birth_date)" :
                "UPDATE Actors SET photo = @photo, name = @name, surname = @surname, patronymic = @patronymic, country = @country, birth_date = @birth_date WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //try
                //{
                    SqlCommand command = new SqlCommand(recordActor, connection);
                    //if (actor.Photo != null) command.Parameters.AddWithValue("@photo", BitmapToByte(actor.Photo));
                    //else
                    //command.Parameters.AddWithValue("@photo", DBNull.Value);
                    //command.Parameters.AddWithValue("@name", actor.Name);
                    //command.Parameters.AddWithValue("@surname", actor.Surname);
                    //object buffPatr = actor.Patronymic;
                    //if (actor.Patronymic == null) buffPatr = DBNull.Value;
                    //command.Parameters.AddWithValue("@patronymic", buffPatr);
                    //command.Parameters.AddWithValue("@country", actor.Country);
                    //command.Parameters.AddWithValue("@birth_date", actor.BirthDate);
                    //command.Parameters.AddWithValue("@id", actor.Id);

                    command.Parameters.AddWithValue("@photo", DBNull.Value);
                    command.Parameters.AddWithValue("@name", DBNull.Value);
                    command.Parameters.AddWithValue("@surname", DBNull.Value);
                    command.Parameters.AddWithValue("@patronymic", DBNull.Value);
                    command.Parameters.AddWithValue("@country", DBNull.Value);
                    command.Parameters.AddWithValue("@birth_date", DBNull.Value);
                    command.Parameters.AddWithValue("@id", actor.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                //}
                //catch (SqlException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }

        public void RemoveMovie(Movie movie)
        {
            string DeletionScript = "Delete movies Where id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(DeletionScript, connection);
                    command.Parameters.AddWithValue("@id", movie.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void RemoveActor(Actor actor)
        {
            string DeletionScript = "Delete actors Where id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(DeletionScript, connection);
                    command.Parameters.AddWithValue("@id", actor.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            string sqlExpression = "SELECT * FROM Movies";
            string getActors = "USE Movies " +
                               "Select actors.actor_id" +
                               " From movies " +
                               "Join movies_actors on movies.movie_id = movies_actors.movie_id " +
                               "Join actors on actors.actor_id = movies_actors.actor_id " +
                               "Where movies.movie_id = ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Movie> mList = new List<Movie>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Movie movie = new Movie();

                            movie.Id = reader.GetInt32(0);
                            movie.Title = reader.GetString(1);
                            movie.Description = reader.GetString(2);

                            object cover = reader.GetValue(3);
                            if (!(cover is DBNull))
                            {
                                movie.Cover = (byte[])cover;
                            }

                            movie.Duration = reader.GetInt32(4);
                            movie.Year = reader.GetInt32(5);
                            
                            mList.Add(movie);
                        }
                        ShowMovies(mList);
                    }
                    else
                    {
                        //MessageBox.Show("No Rows");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    BtnEnabled();
                }
            }
        }

        private void GetActorsFromDB()
        {
            string sqlExpression = "SELECT * FROM Actors";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Actor> mList = new List<Actor>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Actor actor = new Actor();

                            actor.Id = (int)reader.GetValue(0);
                            object photo = reader.GetValue(1);
                            if (!(photo is DBNull))
                                actor.Photo = (byte[])photo;
                            actor.Name = (string)reader.GetValue(2);
                            actor.Surname = (string)reader.GetValue(3);

                            object patronymic = reader.GetValue(4);
                            if(!(patronymic is DBNull)) actor.Patronymic = (string)patronymic;
                            actor.Birth_Date = reader.GetDateTime(6);


                            mList.Add(actor);
                        }
                        ShowActors(mList);
                    }
                    else
                    {
                        //MessageBox.Show("No Rows");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    BtnEnabled();
                }
            }
        }
    }
}
