using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.StartPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            
            //readyBtn.ImageSource = ImageSource.FromFile("splash_logo.jpeg");
        }

        protected async override void OnAppearing()
        {
            readyBtn.Opacity = 0;
            readyBtn.FadeTo(1, 5000, Easing.CubicInOut);
            singleBtn.Opacity = 0;
            singleBtn.FadeTo(1, 5000, Easing.CubicInOut);
            aboutBtn.Opacity = 0;
            await aboutBtn.FadeTo(1, 5000, Easing.CubicInOut);

            base.OnAppearing();            
        }
        private async void ReadyClicked(object o, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ReadyAssemblies());
        }
        private async void SingleClicked(object o, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.IndependentChoicePage());
        }
        private async void HelpClicked(object o, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.HelpPage());
        }

    }
}