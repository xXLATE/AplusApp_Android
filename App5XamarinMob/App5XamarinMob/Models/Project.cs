using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5XamarinMob.Models
{
    [Table("Project1")]
    public class Project
    {
        public Project(string name, string description, string telephoneNumber1, string email, string address, string path)
        {
            Name = name;
            Description = description;
            TelephoneNumber1 = telephoneNumber1;
            Email = email;
            Address = address;
            ImagePath = path;
        }

        public Project()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber1 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}
