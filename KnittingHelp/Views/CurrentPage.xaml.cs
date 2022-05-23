using KnittingHelp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnittingHelp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentPage : ContentPage
    {
        public List<Project> projects { get; set; }
        Label list_lbl;
        ListView list, projectList;

        public CurrentPage()
        {
            InitializeComponent();
            BindingContext = new ProjectListViewModel() { Navigation = this.Navigation };
            projects = new List<Project>
            {
                new Project{ Name = "Cuccinelli Rombs", Yarn = "Alize Kid", Tools = "Needls = 4 & needls = 3.5", Addons = "No", Project_pic="CuccinelliRombProj.jpg", Pattern_pic="CuccinelliRomb.jpg", Notes = "No", Pattern_url="https://youtu.be/izhaSKEmUss", TimerProject=0},
                new Project{Name="Brown bag", Yarn="Cake", Tools="crochet = 4", Addons = "Lock, accessories for belt", Project_pic="BrownBag.JPG", Pattern_pic="No", Notes="No", Pattern_url="https://youtu.be/tSoC3Q4RlZ8", TimerProject=0}
            };

            list_lbl = new Label
            {
                Text = "Current Project in work",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = projects,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding companyBinding = new Binding { Path = "Yarn", StringFormat = "Tools" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Project_pic");
                    return imageCell;
                })
            };
            list.ItemTapped += List_ItemTapped; ;
            this.Content = new StackLayout { Children = { list_lbl, list} };
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Project selectedProject = e.Item as Project;
            if (selectedProject != null)
            {
                list_lbl.Text = selectedProject.ToString();
                projectList = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = projects,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        Label name = new Label { FontSize = 20 };
                        name.SetBinding(Label.TextProperty, "Name");

                        Label yarn = new Label {FontSize = 20 };
                        yarn.SetBinding(Label.TextProperty, "Yarn");

                        Label tools = new Label { FontSize = 20 };
                        tools.SetBinding(Label.TextProperty, "Tools");

                        Label addons = new Label { FontSize = 20 };
                        addons.SetBinding(Label.TextProperty, "Addons");

                        Label notes = new Label {FontSize =20};
                        notes.SetBinding(Label.TextProperty, "Notes");

                        Label pattern_url = new Label { FontSize = 20 };
                        pattern_url.SetBinding(Label.TextProperty, "Pattern_url");

                        Label timerProject = new Label { FontSize = 20 };
                        timerProject.SetBinding(Label.TextProperty, "TimerProject");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(0, 5),
                                Orientation = StackOrientation.Vertical,
                                Children = { name, yarn, tools, addons, notes, pattern_url }
                            }
                        };
                    })
                };
                this.Content = new StackLayout { Children = { list_lbl, projectList } };
            }
        }
    }
}