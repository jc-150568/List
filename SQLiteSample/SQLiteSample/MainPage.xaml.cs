using Xamarin.Forms;
using SQLiteSample;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            //((App)App.Current).ResumeAtTodoId = -1;
            //listView.ItemsSource = await App.Database.GetItemsAsync();
            TodoItemDatabase itemDataBase = getDatabase();
            List<TodoItem> itemList;
            itemList = await itemDataBase.GetItemsAsync();
            int size = itemList.Count;
            layout.Children.Add(new Label() { Text = size + "件のデータ" });
            ScrollView view = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions=LayoutOptions.CenterAndExpand
            };
            layout.Children.Add(view);

            var layout2 = new StackLayout()
            {
            };
            view.Content = layout2;


            foreach ( var i in itemList ){
                layout2.Children.Add(new Label() { Text = i.ID+"" });
                layout2.Children.Add(new Label() { Text = i.Name });
                layout2.Children.Add(new Label() { Text = i.Notes });
                layout2.Children.Add(new Label() { Text = i.Count + "" });
            }

            Content = layout;
        }

    private static TodoItemDatabase db = null;

    public static  TodoItemDatabase getDatabase()
    {
        if (db == null)
            {
                db = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            }
            return db;
        }
    }
}
