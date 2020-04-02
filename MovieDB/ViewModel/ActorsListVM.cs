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

namespace MovieDB.ViewModel
{
    class ActorsListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ActorsListVM()
        {
            model.ShowActors = (actorsList) => ActorsList = actorsList;
            model.BtnEnabled = () => IsEnabled = true;
            model.BtnNotEnabled = () => IsEnabled = false;

            ActorsListPage actorsListPage = new ActorsListPage();
            View = actorsListPage;

            actorsListPage.DataContext = this;
        }

        public bool AdminMode { get; set; }
        public Action<Page> ChangePage;

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

        public Page View { get; private set; }
        private MainModel model = new MainModel();

        private List<Actor> actorsList = new List<Actor>();
        public List<Actor> ActorsList
        {
            get => actorsList;
            set
            {
                actorsList = value;
                OnProperteyChanged();
            }
        }

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
                ActorPageVM actorPageVM = new ActorPageVM();

                int i = ((ListBox)obj).SelectedIndex;

                actorPageVM.Actor = ActorsList[i];
                actorPageVM.AdminMode = true;
                ChangePage(actorPageVM.View);
            });
        }


        public ICommand AddActor
        {
            get => new DelegateCommand((obj) =>
            {
                ActorPageVM moviePageVM = new ActorPageVM();
                moviePageVM.AdminMode = true;
                moviePageVM.EditMode = true;
                ChangePage(moviePageVM.View);
            });
        }
    }
}
