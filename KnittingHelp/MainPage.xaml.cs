using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnittingHelp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromFile("Profile.jpg");
            aboutList.ItemsSource = GetMenuList();
            var homePage = typeof(Views.CurrentPage);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();
            list.Add(new MasterMenuItems()
            {
                Text = "Current projects in work",
                Detail = "Your unfinnished projects",
                ImagePath = "InWork.jpg",
                TargetPage = typeof(Views.CurrentPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Your finnished projects",
                Detail = "All projects which you marked as finnished",
                ImagePath = "Finnished.jpg",
                TargetPage = typeof(Views.FinnishedPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Your Ideas",
                Detail = "Your Ideas and future projects",
                ImagePath = "Ideas.jpg",
                TargetPage = typeof(Views.IdeasPage)
            });
            return list;
        }
        private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}

