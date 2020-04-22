using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MovieDB.Tables;
using MovieDB.Model;
using System.Windows.Controls;
using MovieDB.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace MovieDB.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MainViewModel()
        {
            moviesListVM.ChangePage += (page) => FrameContent = page;
            actorsListVM.ChangePage += (page) => FrameContent = page;
            directorsListVM.ChangePage += (page) => FrameContent = page;

            FrameContent = moviesListVM.View;

            model.ShowMovies = movies => 
            {
                moviesListVM.MoviesList = new ObservableCollection<Movie>(movies);
                moviesListVM.IsEnabled = true;
            };
            model.ShowActors = actors =>
            {
                actorsListVM.ActorsList = new ObservableCollection<IPerson>(actors);
                actorsListVM.IsEnabled = true;
            };
            model.ShowDirectors = directors =>
            {
                directorsListVM.ActorsList = new ObservableCollection<IPerson>(directors);
                directorsListVM.IsEnabled = true;
            };

            moviesListVM.IsEnabled = false;
            actorsListVM.IsEnabled = false;
            directorsListVM.IsEnabled = false;

            model.GetMoviesList();
            model.GetActorsList();
            model.GetDirectorsList();

            AuthorizationWindowVM authorizationWindowVM = new AuthorizationWindowVM();
            authorizationWindowVM.ShowDialog();

            if (!authorizationWindowVM.CanContinue)
            {
                Application.Current.Shutdown();
            }
        }

        EntityModel model = new EntityModel();

        MoviesListVM moviesListVM = new MoviesListVM();
        ActorsListVM actorsListVM = new ActorsListVM();
        ActorsListVM directorsListVM = new ActorsListVM();

        private Page frameContent;
        public Page FrameContent
        {
            get => frameContent;
            set
            {
                frameContent = value;
                OnProperteyChanged();
            }
        }

        public ICommand ShowMovies
        {
            get => new DelegateCommand((obj) =>
            {
                FrameContent = moviesListVM.View;
            });
        }

        public ICommand ShowActors
        {
            get => new DelegateCommand((obj) =>
            {
                FrameContent = actorsListVM.View;
            });
        }

        public ICommand ShowDirectors
        {
            get => new DelegateCommand((obj) =>
            {
                FrameContent = directorsListVM.View;
            });
        }
    }
}