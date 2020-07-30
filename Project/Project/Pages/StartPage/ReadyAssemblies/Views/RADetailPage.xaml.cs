using Project.Pages.StartPage.IndependentChoicePage.Children.Description;
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
    public partial class RADetailPage : TabbedPage
    {
        public RADetailPage(Computer computer, string assemblyName)
        {
            InitializeComponent();

            this.Title = assemblyName;
            this.Children.Add(new CaseDescriptionPage(computer.ComputerCase));
            this.Children.Add(new CPUDescriptionPage(computer.Cpu));
            this.Children.Add(new HDDDescriptionPage(computer.Hdd));
            this.Children.Add(new MotherboardDescriptionPage(computer.Motherboard));
            this.Children.Add(new PowerSupplyDescriptionPage(computer.PowerSupply) { BindingContext = computer.PowerSupply });
            this.Children.Add(new RAMDescriptionPage(computer.Ram) { BindingContext = computer.Ram });
            this.Children.Add(new VideocardDescriptionPage(computer.VideoCard) { BindingContext = computer.VideoCard });
        }
    }
}