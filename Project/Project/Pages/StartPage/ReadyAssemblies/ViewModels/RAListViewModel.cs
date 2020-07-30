using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Project.Pages.StartPage.ReadyAssemblies.ViewModels
{     
    public class RAListViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ICommand ToDetailCommand { protected set; get; }
        private RAViewModel selectedRA;
        public ObservableCollection<RAViewModel> RAs { get; set; }
        public RAListViewModel(string assemblyType, INavigation navigation)
        {
            Navigation = navigation;
            ToDetailCommand = new Command(ToDetail);
            RAs = new ObservableCollection<RAViewModel>();
            this.AddRAs(assemblyType);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public RAViewModel SelectedRA
        {
            get { return selectedRA; }
            set
            {
                if (selectedRA != value)
                {
                    RAViewModel ravm = value;
                    selectedRA = null;
                    OnPropertyChanged("SelectedRA");
                    Navigation.PushAsync(new Views.RADetailPage(ravm.Computer, ravm.Name));
                }
            }
        }
        private void ToDetail()
        {
            Navigation.PushAsync(new Views.RADetailPage(SelectedRA.Computer, SelectedRA.Name));
        }

        private void AddRAs(string assemblyType)
        {
            RAViewModel ravm = new RAViewModel();
            Computer computer = new Computer();
            switch (assemblyType)
            {
                default:
                    List<VideoCard> videoCards = (List<VideoCard>) App.videoCardDatabase.ItemDatabase.GetItems(computerParts.VIDEOCARD);
                    List<CPU> cpus = (List<CPU>)App.cpuDatabase.ItemDatabase.GetItems(computerParts.CPU);
                    List<Motherboard> motherboards = (List<Motherboard>)App.motherboardDatabase.ItemDatabase.GetItems(computerParts.MOTHERBOARD);
                    List<RAM> rams = (List<RAM>)App.ramDatabase.ItemDatabase.GetItems(computerParts.RAM);
                    List<HDD> hdds = (List<HDD>)App.hddDatabase.ItemDatabase.GetItems(computerParts.HDD);
                    List<PowerSupply> powerSupplies = (List<PowerSupply>)App.powerSupplyDatabase.ItemDatabase.GetItems(computerParts.POWERSUPPLY);
                    List<Case> cases = (List<Case>)App.caseDatabase.ItemDatabase.GetItems(computerParts.CASE);
                    computer.VideoCard = videoCards[0];
                    computer.Cpu = cpus[0];
                    computer.Motherboard = motherboards[0];
                    computer.Ram = rams[0];
                    computer.Hdd = hdds[0];
                    computer.PowerSupply = powerSupplies[0];
                    computer.ComputerCase = cases[0];                  

                    ravm.Name = "Сборка 1";
                    break;
            }

            ravm.Computer = computer;
            RAs.Add(ravm);
        }
    }
}
