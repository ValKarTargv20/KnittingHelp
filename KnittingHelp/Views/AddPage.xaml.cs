using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnittingHelp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        Button add_btn;
        EntryCell name, yarn, tools, addons, project_pic, pattern_pic, notes, pattern_url;
        TableView tableView;
        StackLayout st;
        public List<Project> projects { get; set; }
        public AddPage()
        {
            InitializeComponent();
            add_btn = new Button { Text = "Save to projects" }; add_btn.Clicked += Add_btn_Clicked;

            name = new EntryCell
            {
                Label = "Project name:",
                Placeholder = "Enter your project name",
                Keyboard = Keyboard.Text
            };

            yarn = new EntryCell
            {
                Label = "Yarn:",
                Placeholder = "Enter your yarn name or color",
                Keyboard = Keyboard.Text
            };

            tools = new EntryCell
            {
                Label = "Tools:",
                Placeholder = "Enter needles/crochet and numbers",
                Keyboard = Keyboard.Text
            };

            addons = new EntryCell
            {
                Label = "Addons",
                Placeholder = "Enter here zippers, buttons and so on",
                Keyboard = Keyboard.Text
            };
            project_pic = new EntryCell
            {
                Label = "Project Picture",
                Placeholder = "Choose picture for your project. You will see on main page",
                Keyboard = Keyboard.Text
            };
            pattern_pic = new EntryCell
            {
                Label = "Pattern Picture",
                Placeholder = "Add here pattern picture or sccreenshot of it",
                Keyboard = Keyboard.Text
            };
            notes = new EntryCell
            {
                Label = "Notes",
                Placeholder = "You can add some notes or discription",
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
                        yarn,
                        tools,
                        addons,
                        project_pic,
                        pattern_pic,
                        notes,
                        pattern_url
                    },
                    new TableSection { new ViewCell() {View= st } }
                }

            };
            Content = tableView;
        }

        private void Add_btn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}