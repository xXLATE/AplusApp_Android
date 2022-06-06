using SQLite;
using System;
using System.Collections.Generic;
using App5XamarinMob.Models;
using System.Text;

namespace App5XamarinMob.db
{
    public class CRUDOperation
    {
        readonly SQLiteConnection db;
        public CRUDOperation(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Project>();
            db.CreateTable<Client>();
        }
        public IEnumerable<Project> GetProjects()
        {
            return db.Table<Project>();
        }
        public IEnumerable<Client> GetClients()
        {
            return db.Table<Client>();
        }

        public Project GetProjectItem(int id)
        {
            return db.Get<Project>(id);
        }

        public int DelProj(int id) { return db.Delete<Project>(id); }

        public int SaveItem(Project projectModel)
        {
            if (projectModel.Id != 0)
            {
                db.Update(projectModel);
                return projectModel.Id;
            }
            else
            {
                return db.Insert(projectModel);
            }
        }

        public int SaveClient(Client projectModel)
        {
            return db.Insert(projectModel);
        }
    }
}