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

        private Page mainContent;
        public Page MainContent
        {
            get => mainContent;
            set
            {
                mainContent = value;
                OnProperteyChanged();
            }
        }

        public MainViewModel()
        {
            //MoviesLi stPage moviesListPage = new MoviesListPage();
           
            MoviesListVM moviesListVM = new MoviesListVM();
            moviesListVM.ChangePage += (page) => MainContent = page;
            MainContent = moviesListVM.View;
        }
    }
}