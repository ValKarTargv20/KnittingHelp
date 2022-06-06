using KnittingHelp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnittingHelp
{
    public class ReositoryDB
    {
        SQLiteConnection database;
        private List<Project> projects;
        public List<Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
            }
        }
        public ReositoryDB(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ProjectDB>();
            Projects = new List<Project>();

        }
        public IEnumerable<ProjectDB> GetItems()
        {
            return database.Table<ProjectDB>().ToList();
        }
        public ProjectDB GetItem(int id)
        {
            return database.Get<ProjectDB>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<ProjectDB>(id);
        }
        public int SaveItem(ProjectDB item)
        {
            if(item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
