using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5XamarinMob.Models
{
    [Table("Cleint")]
    public class Client
    {
        public Client(string email, string login, string password)
        {
            Email = email;
            Login = login;
            Password = password;
        }

        public Client()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Email { get; set; }
        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }


    }
}
