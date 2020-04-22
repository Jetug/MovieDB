using System.ComponentModel.DataAnnotations;

namespace MovieDB.Tables
{
    class Account
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public byte Role { get; set; }

        public Account() { }

        public Account(string login, string password, byte role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
