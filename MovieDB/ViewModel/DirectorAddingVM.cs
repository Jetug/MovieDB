using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MovieDB.ViewModel
{
    class DirectorAddingVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public DirectorAddingVM(ObservableCollection<Director> director)
        {
            AddedActors = director;
            model.ShowDirectors = (dir) =>
            {
                AllActors = new ObservableCollection<Director>(dir);
                AllActors = new ObservableCollection<Director>(AllActors.Except(AddedActors));
            };
            model.GetDirectorsList_NoMTM();
            actorAdding.DataContext = this;
        }

        EntityModel model = new EntityModel();
        public Window actorAdding = new ActorAdding();
        public Action<ObservableCollection<Director>> SaveChanges;

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

        private ObservableCollection<Director> addedActors = new ObservableCollection<Director>();
        public ObservableCollection<Director> AddedActors
        {
            get => addedActors;
            set
            {
                addedActors = value;
                OnProperteyChanged();
            }
        }

        private ObservableCollection<Director> allctors = new ObservableCollection<Director>();
        public ObservableCollection<Director> AllActors
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

        private object selectedDirector1;
        public object SelectedActor1
        {
            get => selectedDirector1;
            set
            {
                selectedDirector1 = value;
                RemoveBtnEnabled = value == null ? false : true;
                OnProperteyChanged();
            }
        }

        private object selectedDirector2;
        public object SelectedActor2
        {
            get => selectedDirector2;
            set
            {
                selectedDirector2 = value;
                AddBtnEnabled = value == null ? false : true;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Команды

        public ICommand RemoveActor
        {
            get => new DelegateCommand((obj) =>
            {
                Director actor = (Director)SelectedActor1;
                AddedActors.Remove(actor);
                AllActors.Add(actor);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                Director actor = (Director)SelectedActor2;
                AddedActors.Add(actor);
                AllActors.Remove(actor);
            });
        }

        public ICommand SearchActor
        {
            get => new DelegateCommand((obj) =>
            {
                //AllActor = new ObservableCollection<Director>(model.SearchDirector(searchString, AllActor));
            });
        }

        public ICommand OkClick
        {
            get => new DelegateCommand((obj) =>
            {
                SaveChanges(AddedActors);
                actorAdding.Close();
            });
        }

        public ICommand CancleClick
        {
            get => new DelegateCommand((obj) =>
            {
                actorAdding.Close();
            });
        }

        #endregion

        #region Мтоды
        public void ShowDialog()
        {
            actorAdding.ShowDialog();
        }
        #endregion
    }
}
