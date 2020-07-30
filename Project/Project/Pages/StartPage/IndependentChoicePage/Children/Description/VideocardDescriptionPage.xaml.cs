using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.StartPage.IndependentChoicePage.Children.Description
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideocardDescriptionPage : ContentPage
    {
        public VideocardDescriptionPage(ComputerPart item)
        {
            InitializeComponent();
        }

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
                    if (indChoicePage.SelectedParts[i].WhoIs == computerParts.VIDEOCARD)
                    {
                        indChoicePage.SelectedParts.RemoveAt(i);
                    }
                }

                indChoicePage.ItemsToListView[(int)computerParts.VIDEOCARD].IsChecked = true;
                indChoicePage.SelectedParts.Add((ComputerPart)this.BindingContext);
            }

            MessagingCenter.Send<Page>(this, "Back");
            await this.Navigation.PopAsync();
        }
    }
}