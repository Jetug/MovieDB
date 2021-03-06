﻿using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public MoviesListVM()
        {
            model.ShowMovies = (moviesList) => MoviesList = new ObservableCollection<Movie>(moviesList);
            model.BtnEnabled = () => IsEnabled = true;
            model.BtnNotEnabled = () => IsEnabled = false;

            MoviesListPage moviesListPage = new MoviesListPage();
            View = moviesListPage;

            moviesListPage.DataContext = this;
        }

        public Action<Page> ChangePage; 
        private EntityModel model = new EntityModel();

        #region Свойства
        public Page View { get; private set; }

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

        private ObservableCollection<Movie> moviesList = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> MoviesList
        {
            get => moviesList;
            set
            {
                moviesList = value;
                OnProperteyChanged();
            }
        }

        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get => selectedMovie;
            set
            {
                selectedMovie = value;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Команды
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
                moviePageVM.ChangePage = ChangePage;
                moviePageVM.Movie = SelectedMovie;
                ChangePage(moviePageVM.View);
            });
        }

        public ICommand AddMovie
        {
            get => new DelegateCommand((obj) =>
            {
                MoviePageVM moviePageVM = new MoviePageVM();
                moviePageVM.EditMode = true;
                ChangePage(moviePageVM.View);
            });
        }

        public ICommand RemoveMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.RemoveMovie(SelectedMovie);
                model.GetMoviesList();
            });
        }
        #endregion
    }
}