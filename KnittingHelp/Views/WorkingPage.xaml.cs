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
    public partial class WorkingPage : ContentPage
    {
        Label timer_lbl;
        Button row_btn, row_minus_btn;
        StackLayout st;
        int row;
        public WorkingPage()
        {
            InitializeComponent();
            row_btn = new Button
            {
                Text="0",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan
            };
            row_minus_btn = new Button
            {
                Text = "-",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan
            };
            st = new StackLayout
            {
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

        bool on_off = true;

        private async void ShowTime()
        {
            while (on_off)
            {
                timer_lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
    }
}