using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
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