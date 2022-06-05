using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Project> projects { get; set; }
        public AddPage()
        {
            InitializeComponent();
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

        private void GetPattern_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GetProject_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Add_btn_Clicked(object sender, EventArgs e)
        {
            foreach(Project item in projects.ToList())
            {
                if(item.Name != name.Text)
                {
                    projects.Add(new Project { Name = name.Text, Project_pic = project_pic.ToString(), Pattern_pic = pattern_pic.ToString(), Notes = notes.Text, Pattern_url = pattern_url.Text, TimerProject = 0, Rows = Convert.ToInt32(rows.Text) });
                }
                else if (item.Name == name.Text)
                {
                    await DisplayAlert("Attention", "Please enter new name", "OK");
                }
            }
        }
    }
}