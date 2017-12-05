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
            TodoItemDatabase itemDataBase = new TodoItemDatabase("TodoSQLite.db3");
            List<TodoItem> itemList;
            itemList = await itemDataBase.GetItemsAsync();
            int size = itemList.Count;
            layout.Children.Add(new Label() { Text = size + "件のデータ" });



            foreach ( var i in itemList ){
                layout.Children.Add(new Label() { Text = i.ID+"" });
                layout.Children.Add(new Label() { Text = i.Name });
                layout.Children.Add(new Label() { Text = i.Notes });
                layout.Children.Add(new Switch(){ IsEnabled=i.Done});
            }

            Content = layout;
        }
    }
}
