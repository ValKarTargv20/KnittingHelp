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
        Label list_lbl, timer_lbl, notes,pattern_url, rows;
        ListView list, projectList;
        Button count_btn, row_btn, row_minus_btn;
        StackLayout st;
        int row;

        public CurrentPage()
        {
            InitializeComponent();
            projects = new List<Project>
            {
                new Project{ Name = "Cuccinelli Rombs", Project_pic="CuccinelliRombProj.jpg", Pattern_pic="CuccinelliRomb.jpg", Notes = "No", Pattern_url="https://youtu.be/izhaSKEmUss", TimerProject=0, Rows=5},
                new Project{Name="Brown bag", Project_pic="BrownBag.JPG", Pattern_pic="No", Notes="No", Pattern_url="https://youtu.be/tSoC3Q4RlZ8", TimerProject=0,Rows=8}
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
                    Binding rowsBinding = new Binding { Path="Rows", StringFormat="Rows: {0}"};
                    imageCell.SetBinding(ImageCell.DetailProperty, rowsBinding);
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
                list_lbl.Text = selectedProject.Name;
                Button count_btn = new Button { Text = "Continue project" }; count_btn.Clicked += Count_btn_Clicked;
                projectList = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = projects,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        
                        Label name = new Label { FontSize = 20 };
                        name.SetBinding(Label.TextProperty, "Name");

                        Label notes = new Label {FontSize =20};
                        notes.SetBinding(Label.TextProperty, "Notes");

                        Label pattern_url = new Label { FontSize = 20 };
                        pattern_url.SetBinding(Label.TextProperty, "Pattern_url");

                        //Label timerProject = new Label { FontSize = 20 };
                        //timerProject.SetBinding(Label.TextProperty, "TimerProject");

                        Label rows = new Label { FontSize = 20 };
                        rows.SetBinding(Label.TextProperty, "Rows");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(0, 5),
                                Orientation = StackOrientation.Vertical,
                                Children = { name, notes, pattern_url, rows }
                            }
                        };
                    })
                };
                this.Content = new StackLayout { Children = { list_lbl, projectList, count_btn } };
            }
        }

        private async void Count_btn_Clicked(object sender, EventArgs e)
        {
            row_btn = new Button
            {
                Text = "0",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                WidthRequest=50,
                HeightRequest=50,
                CornerRadius=20
            };
            row_minus_btn = new Button
            {
                Text = "-",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                WidthRequest = 50,
                HeightRequest = 50,
                CornerRadius = 20
            };
            timer_lbl = new Label
            {
                Text = DateTime.Now.ToString("T"),
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan
            };
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { timer_lbl, row_btn, row_minus_btn }
            };
            Content = st;

            row_btn.Clicked += Row_btn_Clicked;
            row_minus_btn.Clicked += Row_minus_btn_Clicked;
        }

        private void Row_minus_btn_Clicked(object sender, EventArgs e)
        {
            if (row > 0)
            {
                row = row - 1;
                row_btn.Text = row.ToString();
            }
        }

        private void Row_btn_Clicked(object sender, EventArgs e)
        {
            row = row + 1;
            row_btn.Text = row.ToString();
        }
    }
}