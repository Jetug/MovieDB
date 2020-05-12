using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MovieDB.View;
using System.Windows.Controls;
using MovieDB.Model;
using MovieDB.Tables;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace MovieDB.ViewModel
{
    class PersonListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public PersonListVM()
        {
            model.ShowActors = (actorsList) => ActorsList = new ObservableCollection<IPerson>(actorsList);
            model.ShowDirectors = (actorsList) => ActorsList = new ObservableCollection<IPerson>(actorsList);
            model.BtnEnabled = () => IsEnabled = true;
            model.BtnNotEnabled = () => IsEnabled = false;

            ActorsListPage actorsListPage = new ActorsListPage();
            View = actorsListPage;

            actorsListPage.DataContext = this;
        }

        public Action<Page> ChangePage;

        private EntityModel model = new EntityModel();

        #region Свойства
        public Page View { get; private set; }

        public bool AdminMode { get; set; }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                RemoveBtnEnabled = value;
                OnProperteyChanged();
            }
        }

        private bool removeBtnEnabled = true;
        public bool RemoveBtnEnabled
        {
            get => removeBtnEnabled;
            set
            {
                removeBtnEnabled = value;
                OnProperteyChanged();
            }
        }

        private ObservableCollection<IPerson> actorsList = new ObservableCollection<IPerson>();
        public ObservableCollection<IPerson> ActorsList
        {
            get => actorsList;
            set
            {
                actorsList = value;
                OnProperteyChanged();
            }
        }

        private IPerson selectedPerson;
        public IPerson SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                RemoveBtnEnabled = value != null;
                OnProperteyChanged();
            }
        }

        public string AddBtnText
        {
            get
            {
                if (ActorsList[0] is Actor)
                    return "Добавить актёра";
                else
                    return "Добавить режиссёра";
            }
        }
        #endregion

        public ICommand ShowPersons
        {
            get => new DelegateCommand((obj) =>
            {
                
                if (ActorsList[0] is Actor)
                    model.GetActorsList();
                else
                    model.GetDirectorsList();
            });
        }

        public ICommand ShowActorInfo
        {
            get => new DelegateCommand((obj) =>
            {
                PersonPageVM personPageVM = new PersonPageVM();
                personPageVM.Person = SelectedPerson;
                personPageVM.ChangePage = ChangePage;
                ChangePage(personPageVM.View);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                PersonPageVM moviePageVM = new PersonPageVM();
                moviePageVM.EditMode = true;
                if (ActorsList[0] is Actor)
                    moviePageVM.Person = new Actor();
                else
                    moviePageVM.Person = new Director();
                ChangePage(moviePageVM.View);
            });
        }
        
        public ICommand RemoveActor
        {
            get => new DelegateCommand((obj) =>
            {
                model.RemovePerson(SelectedPerson);
                model.GetActorsList();
            });
        }
    }
}
