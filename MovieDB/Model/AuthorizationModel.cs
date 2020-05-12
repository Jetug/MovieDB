using MovieDB.Tables;
using System.Linq;

namespace MovieDB.Model
{
    class AuthorizationModel
    {
        public bool CheckLogin(string login, ref string message)
        {
            using (AccountContext db = new AccountContext())
            {
                if (login.Length < 5)
                {
                    message = "Логин слишком короткий (не менее 5 символов)";
                    return false;
                }

                if (login.Length > 50)
                {
                    message = "Логин слишком длинный (не более 50 символов)";
                    return false;
                }

                foreach (var c in login)
                {
                    if (c == ' ')
                    {
                        message = "Логин не должен содержать пробелов";
                        return false;
                    }
                }

                if (db.Accounts.Any(a => a.Login == login))
                {
                    message = "Данный логин уже занят";
                    return false;
                }

                return true;
            }
        }

        public bool CheckPassword(string password, ref string message)
        {
            if (password.Length < 6)
            {
                message = "Пароль слишком короткий (не менее 6 символов)";
                return false;
            }
            if (password.Length > 50)
            {
                message = "Пароль слишком длинный (не более 50 символов)";
                return false;                
            }
            foreach (var c in password)
            {
                if(c == ' ')
                {
                    message = "Пароль не должен содержать пробелов";
                    return false;
                }
            }
            return true;    
        }

        public bool CanLogin(string login, string password)
        {
            using (AccountContext db = new AccountContext())
            {
                Account account = db.Accounts.Find(login);
                if (account != null && account.Password == password)
                {
                    bool buf = account.Role == 1;
                    GlobalVars.AdminMode = buf;
                    return true; 
                }
                return false;
            }
        }

        public void Register(Account account)
        {
            using (AccountContext db = new AccountContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }
    }
}
