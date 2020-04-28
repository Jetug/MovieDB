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

            Visibility = GlobalVars.AdminMode ? Visibility.Visible : Visibility.Hidden;
        }
        public Action<Page> ChangePage;
        private EntityModel model = new EntityModel();

        #region Свойства

        public Page View { get; private set; }
        public RecordMode Mode { get; set; }

        private Movie movie = new Movie();
        public Movie Movie
        {
            get => movie;
            set
            {
                movie = value;
                Actors = new ObservableCollection<Actor>(Movie.Actors);
                Directors = new ObservableCollection<Director>(Movie.Directors);
                OnProperteyChanged();
            }
        }

        #region UI
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
        
        private Visibility visibility;
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

        private ObservableCollection<Actor> actors;
        public ObservableCollection<Actor> Actors
        {
            get => actors;
            set
            {
                actors = value;
                OnProperteyChanged();
            }
        }

        private ObservableCollection<Director> directors;
        public ObservableCollection<Director> Directors
        {
            get => directors;
            set
            {
                directors = value;
                OnProperteyChanged();
            }
        }

        private Actor selectedActor = null;
        public Actor SelectedActor
        {
            get => selectedActor;
            set
            {
                selectedActor = value;
                OnProperteyChanged();
            }
        }

        private Director selectedDirector = null;
        public Director SelectedDirector
        {
            get => selectedDirector;
            set
            {
                selectedDirector = value;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Commands
                
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
                    Movie.Cover = File.ReadAllBytes(fileName);
                }
                OnProperteyChanged("Movie");
            });
        }

        public ICommand EditMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.AddOrUpdate(Movie);
            });
        }

        public ICommand Edit
        {
            get => new DelegateCommand((obj) =>
            {
                EditMode = true;
            });
        }

        public ICommand RemoveMovie
        {
            get => new DelegateCommand((obj) =>
            {
                model.RemoveMovie(Movie);
            });
        }

        public ICommand ShowActorInfo
        {
            get => new DelegateCommand((obj) =>
            {
                ShowPerson(SelectedActor);
            });
        }

        public ICommand ShowDirectorInfo
        {
            get => new DelegateCommand((obj) =>
            {
                ShowPerson(SelectedDirector);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                ActorAddingVM actorAddingVM = new ActorAddingVM(new ObservableCollection<Actor>(Movie.Actors.ToList()));
                actorAddingVM.SaveChanges = (actors) =>
                {
                    Actors = actors;
                    Movie.Actors = actors.ToList();
                };
                actorAddingVM.ShowDialog();
            });
        }
        #endregion

        private void ShowPerson(IPerson person)
        {
            if (person != null)
            {
                PersonPageVM actorPageVM = new PersonPageVM();

                actorPageVM.Actor = person;
                ChangePage(actorPageVM.View);
            }
        }
    }
}