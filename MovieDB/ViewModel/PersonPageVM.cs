using Microsoft.Win32;
using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieDB.ViewModel
{
    class PersonPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public PersonPageVM()
        {
            ActorPage actorPage = new ActorPage();
            actorPage.DataContext = this;
            View = actorPage;

            for (int i = 1; i <= 31; i++)
            {
                Days.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                Months.Add(i);
            }
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                Years.Add(i);
            }
        }

        public Action<Page> ChangePage;
        private EntityModel model = new EntityModel();
        public Page View { get; private set; }

        #region Свойства
        
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

        #region UI
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

        private Visibility visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnProperteyChanged();
            }
        }
        #endregion

        private IPerson person;
        public IPerson Person
        {
            get => person;
            set
            {
                person = value;
                Movies = new ObservableCollection<Movie>(Person.Movies);
                Day = value.Birth_Date.Day;
                Month = value.Birth_Date.Month;
                Year = value.Birth_Date.Year;

                Day = Person.Birth_Date.Day;
                Month = Person.Birth_Date.Month;
                Year = Person.Birth_Date.Year;

                OnProperteyChanged();
            }
        }

        #region Дата рождения
        private List<int> days = new List<int>();
        public List<int> Days
        {
            get => days;
            set
            {
                days = value;
                OnProperteyChanged();
            }
        }

        private List<int> months = new List<int>();
        public List<int> Months
        {
            get => months;
            set
            {
                months = value;
                OnProperteyChanged();
            }
        }

        private List<int> years = new List<int>();
        public List<int> Years
        {
            get => years;
            set
            {
                years = value;
                OnProperteyChanged();
            }
        }
        
        private int day;
        public int Day
        {
            get => day;
            set
            {
                day = value;
                //Actor.Birth_Date = new DateTime(Year, Month, Day);
                OnProperteyChanged();
            }
        }

        private int month;
        public int Month
        {
            get => month;
            set
            {
                month = value;
                //Actor.Birth_Date = new DateTime(Year, Month, Day);
                OnProperteyChanged();
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                year = value;
                //Actor.Birth_Date = new DateTime(Year, Month, Day);
                OnProperteyChanged();
            }
        }
        #endregion

        public ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get => movies;
            set
            {
                movies = value;
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

        #region Commands

        public ICommand EditPhoto
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
                    Person.Photo = File.ReadAllBytes(fileName);
                }
                OnProperteyChanged("Actor");
            });
        }

        public ICommand Edit
        {
            get => new DelegateCommand((obj) =>
            {
                EditMode = true;
            });
        }

        public ICommand EditPerson
        {
            get => new DelegateCommand((obj) =>
            {
                Person.Birth_Date = new DateTime(Year, Month, Day);
                model.AddOrUpdate(Person);
            });
        }

        public ICommand RemovePerson
        {
            get => new DelegateCommand((obj) =>
            {
                model.RemovePerson(Person);
            });
        }

        public ICommand ShowMovieInfo
        {
            get => new DelegateCommand((obj) =>
            {
                if (SelectedMovie != null)
                {
                    MoviePageVM moviePageVM = new MoviePageVM();

                    moviePageVM.Movie = SelectedMovie;
                    ChangePage(moviePageVM.View);
                }
            });
        }

        public ICommand AddMovie
        {
            get => new DelegateCommand((obj) =>
            {
                MovieAddingVM movieAddingVM = new MovieAddingVM(new ObservableCollection<Movie>(Person.Movies));
                movieAddingVM.SaveChanges = (movies) =>
                {
                    Movies = movies;
                    Person.Movies = movies.ToList();
                };
                movieAddingVM.ShowDialog();
            });
        }
        #endregion
    }
}
