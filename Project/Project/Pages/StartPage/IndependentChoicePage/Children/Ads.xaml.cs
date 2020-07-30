using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.StartPage.IndependentChoicePage.Children
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ads : ContentPage
    {
        public Ads(ComputerPart item)
        {
            InitializeComponent();
        }
    }
}