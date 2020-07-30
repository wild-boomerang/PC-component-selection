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
    public partial class ReadyAssemblies : ContentPage
    {
        public ReadyAssemblies()
        {
            InitializeComponent();
        }

        private void StudentsClicked(object o, EventArgs eventArgs)
        {
            this.Navigation.PushAsync(new StartPage.ReadyAssemblies.Views.ComputerAssemblyList("students"));
        }
        private void GamersClicked(object o, EventArgs eventArgs)
        {

        }
        private void MediaClicked(object o, EventArgs eventArgs)
        {

        }
        private void CompactClicked(object o, EventArgs eventArgs)
        {

        }
        private void MonstrsClicked(object o, EventArgs eventArgs)
        {

        }
        private void MinimalClicked(object o, EventArgs eventArgs)
        {

        }
        private void UpgradeClicked(object o, EventArgs eventArgs)
        {

        }
        private void AliClicked(object o, EventArgs eventArgs)
        {

        }
    }
}