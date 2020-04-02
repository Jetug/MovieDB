using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieDB.ViewModel
{
    class MoviesListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Action<Page> ChangePage;

        public Page View { get; private set; }
        private EntityModel model = new EntityModel();

        public MoviesListVM()
        {
            model.ShowMovies = (moviesList) => MoviesList = moviesList;
            model.BtnEnabled = () => IsEnabled = true;
            model.BtnNotEnabled = () => IsEnabled = false;

            MoviesListPage moviesListPage = new MoviesListPage();
            View = moviesListPage;

            moviesListPage.DataContext = this;
        }


        private bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                OnProperteyChanged();
            }
        }

        private List<Movie> movies = new List<Movie>();
        public List<Movie> MoviesList
        {
            get => movies;
            set
            {
                movies = value;
                OnProperteyChanged();
            }
        }

        public ICommand ShowMovies
        {
            get => new DelegateCommand((obj) =>
            {
                model.GetMoviesList();
            });
        }

        public ICommand ShowMovieInfo
        {
            get => new DelegateCommand((obj) =>
            {
                MoviePageVM moviePageVM = new MoviePageVM();

                int i = ((ListBox)obj).SelectedIndex;

                moviePageVM.Movie = MoviesList[i];
                moviePageVM.AdminMode = true;
                ChangePage(moviePageVM.View);
            });
        }

        public ICommand AddMovie
        {
            get => new DelegateCommand((obj) =>
            {
                MoviePageVM moviePageVM = new MoviePageVM();
                moviePageVM.AdminMode = true;
                moviePageVM.EditMode = true;
                ChangePage(moviePageVM.View);
            });
        }

        public ICommand RemoveMovie
        {
            get => new DelegateCommand((obj) =>
            {
                
            });
        }
    }
}