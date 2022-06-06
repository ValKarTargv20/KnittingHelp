using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnittingHelp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "projectDB.db";
        public static ReositoryDB database;

        public static ReositoryDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReositoryDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
            
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
