using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project.Pages;

namespace Project.Pages.StartPage.IndependentChoicePage.Children.Description
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CPUDescriptionPage : ContentPage
    {
        //public ComputerPart cpu;
        public CPUDescriptionPage(ComputerPart item)
        {
            InitializeComponent();

            this.BindingContext = item;

            //cpu = item;
            //tableView.BindingContext = item;
            //this.BindingContext = this;

            switch (item.WhoIs)
            {
                case computerParts.CASE:
                    //item = (Case)item;
                    break;
                case computerParts.CPU:
                    //item = (CPU)item;
                    break;
                case computerParts.HDD:
                    break;
                case computerParts.MOTHERBOARD:
                    break;
                case computerParts.POWERSUPPLY:
                    break;
                case computerParts.RAM:
                    break;
                case computerParts.VIDEOCARD:
                    break;
            }            
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    await image.RotateTo(360, 8000, Easing.CubicIn);
        //}
        private async void ToolBarItemClicked(object sender, EventArgs e)
        {
            MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
            NavigationPage navPage = (NavigationPage)masterDetailPage.Detail;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            Project.Pages.IndependentChoicePage indChoicePage = navStack[navPage.Navigation.NavigationStack.Count - 3] 
                as Project.Pages.IndependentChoicePage;

            if (indChoicePage != null)
            {
                for (int i = 0; i < indChoicePage.SelectedParts.Count; i++)
                {
                    if (indChoicePage.SelectedParts[i].WhoIs == computerParts.CPU)
                    {
                        indChoicePage.SelectedParts.RemoveAt(i);
                    }
                }

                indChoicePage.ItemsToListView[(int)computerParts.CPU].IsChecked = true;
                indChoicePage.SelectedParts.Add((ComputerPart)this.BindingContext);
            }

            MessagingCenter.Send<Page>(this, "Back");
            await this.Navigation.PopAsync();
        }

        private async void HeplBtnClicked(object sender, EventArgs e)
        {
            //btn.
            await this.DisplayAlert("Характеристика", "Что она означает", "OK");
        }

        //private async void ButtonItemClicked(object sender, EventArgs e)
        //{
        //    MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
        //    NavigationPage navPage = (NavigationPage)masterDetailPage.Detail;
        //    IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
        //    Project.Pages.IndependentChoicePage independentChoicePage = navStack[navPage.Navigation.NavigationStack.Count - 3]
        //        as Project.Pages.IndependentChoicePage;
        //    if (independentChoicePage != null)
        //    {
        //        independentChoicePage.SelectedParts.Add((ComputerPart)this.BindingContext);
        //    }

        //    MessagingCenter.Send<Page>(this, "Back");
        //    await this.Navigation.PopAsync();
        //}
    }
}