using Microsoft.Win32;
using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MovieDB.ViewModel
{
    class MoviePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MoviePageVM()
        {
            MoviePage moviePage = new MoviePage();
            moviePage.DataContext = this;
            View = moviePage;
        }

        private EntityModel model = new EntityModel();
        public Page View { get; private set; }

        #region Свойства
        private bool adminMode = false;
        public bool AdminMode
        {
            get => adminMode;
            set
            {
                adminMode = value;
                Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private bool editMode = false;
        public bool EditMode
        {
            get => editMode;
            set
            {
                editMode = value;
                ReadOnly = !value;
            }
        }

        private bool readOnly = true;
        public bool ReadOnly
        {
            get => readOnly;
            set
            {
                readOnly = value;
                OnProperteyChanged();
            }
        }

        private bool isEnabled = false;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                OnProperteyChanged();
            }
        }
        
        private Visibility visibility = Visibility.Hidden;
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnProperteyChanged();
            }
        }

        private Movie movie = new Movie();
        public Movie Movie
        {
            get => movie;
            set
            {
                movie = value;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand Edit
        {
            get => new DelegateCommand((obj) =>
            {
                EditMode = true;
            });
        }

        public ICommand TitleChanged
        {
            get => new DelegateCommand((obj) =>
            {
                Movie.Title = ((TextBox)obj).Text;
                OnProperteyChanged("Movie");
            });
        }

        public ICommand DescriptionChanged
        {
            get => new DelegateCommand((obj) =>
            {
                Movie.Description = ((TextBox)obj).Text;
                OnProperteyChanged("Movie");
            });
        }
        
        public ICommand EditCover
        {
            get => new DelegateCommand((obj) =>
            {
                string fileName = "";

                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Изображения (*.jpg)|*.jpg",
                };

                if (fileDialog.ShowDialog() == true) fileName = fileDialog.FileName;
                if (fileName != "")
                {
                    //Movie.Cover = new BitmapImage(new Uri(fileName));
                    Movie.Cover = File.ReadAllBytes(fileName);
                }
                OnProperteyChanged("Movie");
            });
        }

        public ICommand DurationChanged
        {
            get => new DelegateCommand((obj) =>
            {
                try
                {
                    Movie.Duration = int.Parse(((TextBox)obj).Text);
                }
                catch (FormatException)
                {
                }
                OnProperteyChanged("Movie");
            });
        }

        public ICommand YearChanged
        {
            get => new DelegateCommand((obj) =>
            {
                try
                {
                    Movie.Year = int.Parse(((TextBox)obj).Text);
                }
                catch (FormatException)
                {
                }
                
                OnProperteyChanged("Movie");
            });
        }

        public ICommand AddMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.RecordMovie(Movie);
            });
        }

        public ICommand EditMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.UpdateMovie(Movie);
            });
        }

        public ICommand RemoveMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.RemoveMovie(Movie);
            });

        }
        #endregion
    }
}
