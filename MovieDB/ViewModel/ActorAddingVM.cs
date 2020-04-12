using MovieDB.Model;
using MovieDB.Tables;
using MovieDB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            model.GetActorsList();
            actorAdding.DataContext = this;
            //List<Actor> buff = AllActors.ToList().RemoveAll(el => AddedActors.Exists(el2 => el2.Id == el.Id));

            //AllActors = new ObservableCollection<Actor>(AllActors.Except(AddedActors));

            //AddedActors = new ObservableCollection<Actor>();
        }

        EntityModel model = new EntityModel();
        public Window actorAdding = new ActorAdding();
        public Action<List<Actor>> SaveChanges;

        #region Свойства
        public List<Actor> NewActors { get; set; }

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
                NewActors.Remove(actor);
                AllActors.Add(actor);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                Actor actor = (Actor)SelectedActor2;
                AddedActors.Add(actor);
                NewActors.Add(actor);
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
                SaveChanges(NewActors);
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

        public void ShowDialog()
        {
            actorAdding.ShowDialog();
        }


    }
}
