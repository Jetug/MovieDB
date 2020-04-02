using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MovieDB.Tables;
using MovieDB.Model;
using System.Windows.Controls;
using MovieDB.View;

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

            FrameContent = moviesListVM.View;
        }

        MoviesListVM moviesListVM = new MoviesListVM();
        ActorsListVM actorsListVM = new ActorsListVM();

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
    }
}