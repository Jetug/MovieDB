using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MovieDB.View;
using System.Text;
using System.Threading.Tasks;
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
        #endregion

        public ICommand ShowActors
        {
            get => new DelegateCommand((obj) =>
            {
                model.GetActorsList();
            });
        }

        public ICommand ShowActorInfo
        {
            get => new DelegateCommand((obj) =>
            {
                PersonPageVM actorPageVM = new PersonPageVM();
                actorPageVM.Actor = SelectedPerson;
                actorPageVM.ChangePage = ChangePage;
                ChangePage(actorPageVM.View);
            });
        }

        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                PersonPageVM moviePageVM = new PersonPageVM();
                moviePageVM.EditMode = true;
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
