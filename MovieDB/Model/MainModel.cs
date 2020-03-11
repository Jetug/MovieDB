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
        public Action<List<Movie>> ShowResults;
        public Action BtnNotEnabled;
        public Action BtnEnabled;

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True";

        public void Start()
        {
            BtnNotEnabled();
            Thread thread = new Thread(GetMoviesList);
            thread.Start();

            //GetMoviesList();
        }

        public void RecordMovie1(Movie movie, RecordMode recordMode)
        {
            string addMovie = "use Movies INSERT INTO movies(title, description, cover) VALUES(@title, @description, @cover)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(addMovie, connection);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@description", movie.Description);
                    command.Parameters.AddWithValue("@cover", BitmapToByte(movie.Cover));
                    command.Parameters.AddWithValue("@duration", movie.Duration);
                    command.Parameters.AddWithValue("@year", movie.Year);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void RecordMovie(Movie movie, RecordMode mode)
        {
            string recordMovie = mode == RecordMode.Adding ?
                "INSERT INTO movies(title, description, cover, duration, year) VALUES(@title, @description, @cover, @duration, @year)" :
                "UPDATE movies SET title = @title, description = @description, duration = @duration, year = @year WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(recordMovie, connection);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@description", movie.Description);
                    command.Parameters.AddWithValue("@cover", BitmapToByte(movie.Cover));
                    command.Parameters.AddWithValue("@duration", movie.Duration);
                    command.Parameters.AddWithValue("@year", movie.Year);
                    command.Parameters.AddWithValue("@id", movie.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void RemoveMovie()
        {
            
        }

        public void EditMovie(Movie movie)
        {
            string addMovie = "UPDATE movies SET title = @title, description = @description, duration = @duration, year = @year WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(addMovie, connection);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@description", movie.Description);
                    command.Parameters.AddWithValue("@cover", BitmapToByte(movie.Cover));
                    command.Parameters.AddWithValue("@duration", movie.Duration);
                    command.Parameters.AddWithValue("@year", movie.Year);

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

        private void GetMoviesList()
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

                            movie.ID = (int)reader.GetValue(0);
                            movie.Title = (string)reader.GetValue(1);
                            movie.Description = (string)reader.GetValue(2);

                            object cover = reader.GetValue(3);
                            if (!(cover is DBNull))
                            {
                                Application.Current.Dispatcher.Invoke(() => movie.Cover = ByteToBitmap((byte[])cover));
                            }

                            movie.Duration = (int)reader.GetValue(4);
                            movie.Year = (int)reader.GetValue(5);

                            //SqlCommand command2 = new SqlCommand(getActors + movie.ID, connection);
                            //SqlDataReader reader2 = command2.ExecuteReader();

                            //while (reader2.Read())
                            //{
                            //    movie.ActorsID.Add( (int)reader2.GetValue(0) );
                            //}
                            mList.Add(movie);
                            //OnProperteyChanged("MoviesList");
                        }
                        //MoviesList = mList;
                        ShowResults(mList);
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
