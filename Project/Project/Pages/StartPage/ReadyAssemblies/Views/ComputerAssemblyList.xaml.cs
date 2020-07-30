using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.StartPage.ReadyAssemblies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComputerAssemblyList : ContentPage
    {
        public ViewModels.RAListViewModel RAVM { get; set; }
        public ComputerAssemblyList(string assemblyType)
        {
            InitializeComponent();

            this.Title = assemblyType;
            RAVM = new ViewModels.RAListViewModel(assemblyType, this.Navigation);
            this.BindingContext = RAVM;
            //this.DisplayAlert("sadf", RAVM.RAs[0].ReadyAssemblies.Assembly.PowerSupply.Price.ToString(), "OK");
        }
    }
}