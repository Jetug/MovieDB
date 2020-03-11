using MovieDB.Model;
using MovieDB.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieDB.ViewModel
{
    class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public TestViewModel()
        {
            model.ShowResults = (moviesList) => MoviesList = moviesList;
            model.BtnEnabled = () => IsEnabled = true;
            model.BtnNotEnabled = () => IsEnabled = false;
        }

        private MainModel model = new MainModel();

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

        public ICommand Start
        {
            get => new DelegateCommand((obj) =>
            {
                model.Start();
            });
        }
    }
}
