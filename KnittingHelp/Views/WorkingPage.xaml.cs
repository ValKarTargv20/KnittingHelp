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
        public WorkingPage()
        {
            InitializeComponent();
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