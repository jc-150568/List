using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new SQLiteSample.MainPage();
            MainPage =  new TabbedPage1();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        static TodoItemDatabase database;


        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

    }
}
