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
    class AuthorizationWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public AuthorizationWindowVM()
        {
            authorization.DataContext = this;
        }

        public AuthorizationModel model = new AuthorizationModel();

        #region Свойства
        public bool CanContinue { get; private set; }
        //private bool adminMode;
        //public bool AdminMode 
        //{
        //    get => adminMode;
        //    private set { adminMode = value; }
        //}
        public AuthorizationWindow authorization { get; private set; } = new AuthorizationWindow();

        public string login = "";
        public string Login
        {
            get => login;
            set
            {
                login = value.Trim();
                OnProperteyChanged();
            }
        }

        public string password = "";
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnProperteyChanged();
            }
        }
        #endregion

        #region Команды
        public ICommand SignUp
        {
            get => new DelegateCommand((obj) =>
            {
                string message = "";
                if(model.CheckLogin(Login, ref  message) && model.CheckPassword(Password, ref message))
                {
                    model.Register(new Account(Login, Password, 0));
                    MessageBox.Show("Пользователь зарегистрирован");
                }
                else
                {
                    MessageBox.Show(message);
                }
            });
        }

        public ICommand SignIn
        {
            get => new DelegateCommand((obj) =>
            {
                if (model.CanLogin(Login, Password))
                {
                    CanContinue = true;
                    authorization.Close();
                }
                else MessageBox.Show("Не правильный логин или пароль");
            });
        }
        #endregion

        public void ShowDialog()
        {
            authorization.ShowDialog();
        }
    }
}
