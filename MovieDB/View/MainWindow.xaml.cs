using MovieDB.Model;
using MovieDB.Tables;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace MovieDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var rep = new MovieDBRepository();
            //foreach (var actor in rep.GetActors())
            //{
            //    MessageBox.Show($"{actor.Name}; {actor.Movies.Count}");
            //}
        }
    }
}
