using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPageObject.listView.ItemSelected += SelectedItemInMasterPage;
        }        

        private void SelectedItemInMasterPage(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem item = e.SelectedItem as MasterPageItem;

            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                //((ListView)sender).SelectedItem = null;
                masterPageObject.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
