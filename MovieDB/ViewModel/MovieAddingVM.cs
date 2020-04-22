using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class MovieAddingVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MovieAddingVM(ObservableCollection<Movie> act)
        {
            AddedMovies = act;
            model.ShowMovies = (movies) =>
            {
                AllMovies = new ObservableCollection<Movie>(movies);
                AllMovies = new ObservableCollection<Movie>(AllMovies.Except(AddedMovies));
            };
            model.GetMoviesList_NoMTM();
            movieAdding.DataContext = this;
        }

        EntityModel model = new EntityModel();
        public Window movieAdding = new MovieAdding();
        public Action<ObservableCollection<Movie>> SaveChanges;

        #region Свойства

        private string searchString;
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                OnProperteyChanged();
            }
        }

        private ObservableCollection<Movie> addedMovies = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> AddedMovies
        {
            get => addedMovies;
            set
            {
                addedMovies = value;
                OnProperteyChanged();
            }
        }

        private ObservableCollection<Movie> allctors = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> AllMovies
        {
            get => allctors;
            set
            {
                allctors = value;
                OnProperteyChanged();
            }
        }

        private bool addBtnEnabled = false;
        public bool AddBtnEnabled
        {
            get => addBtnEnabled;
            set
            {
                addBtnEnabled = value;
                OnProperteyChanged();
            }
        }

        private bool removeBtnEnabled = false;
        public bool RemoveBtnEnabled
        {
            get => removeBtnEnabled;
            set
            {
                removeBtnEnabled = value;
                OnProperteyChanged();
            }
        }

        private object selectedMovie1;
        public object SelectedMovie1
        {
            get => selectedMovie1;
            set
            {
                selectedMovie1 = value;
                RemoveBtnEnabled = value == null ? false : true;
                OnProperteyChanged();
            }
        }

        private object selectedMovie2;
        public object SelectedMovie2
        {
            get => selectedMovie2;
            set
            {
                selectedMovie2 = value;
                AddBtnEnabled = value == null ? false : true;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Команды

        public ICommand RemoveMovie
        {
            get => new DelegateCommand((obj) =>
            {
                Movie movie = (Movie)SelectedMovie1;
                AddedMovies.Remove(movie);
                AllMovies.Add(movie);
            });
        }

        public ICommand AddMovie
        {
            get => new DelegateCommand((obj) =>
            {
                Movie movie = (Movie)SelectedMovie2;
                AddedMovies.Add(movie);
                AllMovies.Remove(movie);
            });
        }

        public ICommand SearchMovies
        {
            get => new DelegateCommand((obj) =>
            {
                //AllMovies = new ObservableCollection<Movie>(model.SearchMovie(searchString, AllMovies));
            });
        }

        public ICommand OkClick
        {
            get => new DelegateCommand((obj) =>
            {
                SaveChanges(AddedMovies);
                movieAdding.Close();
            });
        }

        public ICommand CancleClick
        {
            get => new DelegateCommand((obj) =>
            {
                movieAdding.Close();
            });
        }

        #endregion

        public void ShowDialog()
        {
            movieAdding.ShowDialog();
        }
    }
}