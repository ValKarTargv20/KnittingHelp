using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnittingHelp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        Button add_btn, getProject, getPattern;
        EntryCell name, notes, pattern_url, rows;
        TableView tableView;
        StackLayout st, btn;
        Image project_pic, pattern_pic;
        bool sp = false;
        public static ReositoryDB database;

        public ObservableCollection<Project> projects { get; set; }
        public AddPage()
        {
            InitializeComponent();
            database = App.Database;
            add_btn = new Button { Text = "Save to projects" }; add_btn.Clicked += Add_btn_Clicked;
            getProject = new Button { Text = "Add project's picture" }; getProject.Clicked += GetProject_Clicked;
            getPattern = new Button { Text = "Add pattern's picture" }; getPattern.Clicked += GetPattern_Clicked;
            btn = new StackLayout
            {
                Children = {getProject, getPattern},
                Orientation=StackOrientation.Horizontal,
                HorizontalOptions=LayoutOptions.CenterAndExpand
            };
            name = new EntryCell
            {
                Label = "Project name:",
                Placeholder = "Enter your project name",
                Keyboard = Keyboard.Text
            };
            notes = new EntryCell
            {
                Label = "Notes",
                Placeholder = "You can add discription, nidles, yarn and so on.",
                Keyboard = Keyboard.Text
            };
            pattern_url = new EntryCell
            {
                Label = "Pattern URL",
                Placeholder = "You can copy here pattern link",
                Keyboard = Keyboard.Url
            };
            rows = new EntryCell
            {
                Label="Rows",
                Placeholder="Enter rows",
                Keyboard= Keyboard.Numeric
            };
            st = new StackLayout
            {
                Children = { add_btn },
                Orientation = StackOrientation.Horizontal
            };
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("New project creating")
                {
                    new TableSection("Main:") { name },
                    new TableSection("Project Data:")
                    {
                        notes,
                        pattern_url,
                        rows
                    },
                    new TableSection { new ViewCell() {View= st } }
                }

            };
            Content = tableView;
        }

        async void GetPattern_Clicked(object sender, EventArgs e)
        {
            pattern_pic = new Image();
            var photo = await MediaPicker.PickPhotoAsync();
            pattern_pic.Source = ImageSource.FromFile(photo.FullPath);
        }

        async void GetProject_Clicked(object sender, EventArgs e)
        {
            project_pic = new Image();
            var photo = await MediaPicker.PickPhotoAsync();
            project_pic.Source = ImageSource.FromFile(photo.FullPath);
            if (project_pic != null)
            {
                bool sp = true;
                return;
            }
        }

        private async void Add_btn_Clicked(object sender, EventArgs e)
        {
            if (sp)
            {
                foreach (Project item in projects.ToList())
                {
                    if (item.Name != name.Text)
                    {
                        projects.Add(new Project { Name = name.Text, Project_pic = project_pic.ToString(), Pattern_pic = pattern_pic.ToString(), Notes = notes.Text, Pattern_url = pattern_url.Text, TimerProject = 0, Rows = Convert.ToInt32(rows.Text) });
                    }
                    else if (item.Name == name.Text)
                    {
                        await DisplayAlert("Attention", "Please enter new name", "OK");
                    }
                }
            }
            else if (!sp)
            {
                DisplayAlert("Attention!", "Please add pattern picture", "Ok");
            }
        }
    }
}