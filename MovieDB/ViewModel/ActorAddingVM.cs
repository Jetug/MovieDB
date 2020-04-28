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
    class ActorAddingVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ActorAddingVM(ObservableCollection<Actor> act)
        {
            AddedActors = act;
            model.ShowActors = (actors) => 
            { 
                AllActors = new ObservableCollection<Actor>(actors); 
                AllActors = new ObservableCollection<Actor>(AllActors.Except(AddedActors)); 
            };
            model.GetActorsList_NoMTM();
            actorAdding.DataContext = this;
        }

        EntityModel model = new EntityModel();
        public Window actorAdding = new ActorAdding();
        public Action<ObservableCollection<Actor>> SaveChanges;

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

        private ObservableCollection<Actor> addedActors = new ObservableCollection<Actor>();
        public ObservableCollection<Actor> AddedActors 
        {
            get => addedActors;
            set
            {
                addedActors = value;
                OnProperteyChanged();
            }
        } 

        private ObservableCollection<Actor> allctors = new ObservableCollection<Actor>();
        public ObservableCollection<Actor> AllActors
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

        private object selectedActor1;
        public object SelectedActor1
        {
            get => selectedActor1;
            set
            {
                selectedActor1 = value;
                RemoveBtnEnabled = value == null ? false : true;
                OnProperteyChanged();
            }
        }

        private object selectedActor2;
        public object SelectedActor2
        {
            get => selectedActor2;
            set
            {
                selectedActor2 = value;
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
                Actor actor = (Actor)SelectedActor1;
                AddedActors.Remove(actor);
                AllActors.Add(actor);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                Actor actor = (Actor)SelectedActor2;
                AddedActors.Add(actor);
                AllActors.Remove(actor);
            });
        }

        public ICommand SearchActors
        {
            get => new DelegateCommand((obj) =>
            {
                AllActors = new ObservableCollection<Actor>(model.SearchActor(searchString, AllActors));
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
