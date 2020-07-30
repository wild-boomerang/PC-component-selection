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
    public partial class ItemsPage : ContentPage
    {
        public string Type { get; set; }
        public ItemsPage(string type = null)
        {
            InitializeComponent();

            Type = type;

            switch (Type)
            {
                case "— с процессора":
                    this.Title = Resource.ItemsPageCPUTitle;
                    break;
                case "— с видеокарты":
                    this.Title = Resource.ItemsPageGPUTitle;
                    break;
                case "— с оперативной памяти":
                    this.Title = Resource.ItemsPageRAMTitle;
                    break;
                case "— с материнской платы":
                    this.Title = Resource.ItemsPageMotherboardTitle;
                    break;
                case "— с жёсткого диска":
                    this.Title = Resource.ItemsPageHDDTitle;
                    break;
                case "— с корпуса":
                    this.Title = Resource.ItemsPageCaseTitle;
                    break;
                case "— с блока питания":
                    this.Title = Resource.ItemsPagePowerSupplyTitle;
                    break;
            }

            Subscribe();
        }

        protected override void OnAppearing()
        {
            MasterDetailPage masterDetailPage = Application.Current.MainPage as MasterDetailPage;
            NavigationPage navPage = masterDetailPage.Detail as NavigationPage;
            IReadOnlyList<Page> pages = navPage.Navigation.NavigationStack;
            IndependentChoicePage indChoicePage = pages[navPage.Navigation.NavigationStack.Count - 2]
                                                            as IndependentChoicePage;

            switch (Type)
            {
                case "— с процессора":                                        
                    if (indChoicePage != null)
                    {
                        foreach (var selectedPart in indChoicePage.SelectedParts)
                        {
                            if (selectedPart.WhoIs == computerParts.MOTHERBOARD)
                                itemsList.BindingContext = App.cpuDatabase.ItemDatabase.GetItems(computerParts.CPU, 
                                                                                ((Motherboard)(selectedPart)).Socket);
                        }
                    }                    

                    if (itemsList.BindingContext == null)
                    {
                        //itemsList.ItemsSource = App.CPUDatabase.GetItems();
                        itemsList.BindingContext = App.cpuDatabase.ItemDatabase.GetItems(computerParts.CPU);
                    }
                    
                    break;
                case "— с видеокарты":
                    itemsList.BindingContext = App.videoCardDatabase.ItemDatabase.GetItems(computerParts.VIDEOCARD);
                    break;
                case "— с оперативной памяти":
                    itemsList.BindingContext = App.ramDatabase.ItemDatabase.GetItems(computerParts.RAM);
                    break;
                case "— с материнской платы":
                    if (indChoicePage != null)
                    {
                        foreach (var selectedPart in indChoicePage.SelectedParts)
                        {
                            if (selectedPart.WhoIs == computerParts.CPU)
                                itemsList.BindingContext = App.motherboardDatabase.ItemDatabase.GetItems(computerParts.MOTHERBOARD,
                                                                                ((CPU)(selectedPart)).Socket);
                        }
                    }

                    if (itemsList.BindingContext == null)
                    {
                        itemsList.BindingContext = App.motherboardDatabase.ItemDatabase.GetItems(computerParts.MOTHERBOARD);
                    }                    
                    break;
                case "— с жёсткого диска":
                    itemsList.BindingContext = App.hddDatabase.ItemDatabase.GetItems(computerParts.HDD);
                    break;
                case "— с корпуса":
                    if (indChoicePage != null)
                    {
                        foreach (var selectedPart in indChoicePage.SelectedParts)
                        {
                            if (selectedPart.WhoIs == computerParts.MOTHERBOARD)
                                itemsList.BindingContext = App.caseDatabase.ItemDatabase.GetItems(computerParts.CASE,
                                                                                ((Motherboard)(selectedPart)).FormFactor);
                        }
                    }

                    if (itemsList.BindingContext == null)
                    {
                        itemsList.BindingContext = App.caseDatabase.ItemDatabase.GetItems(computerParts.CASE/*, "сталь, стекло"*/);
                    }
                    
                    break;
                case "— с блока питания":
                    itemsList.BindingContext = App.powerSupplyDatabase.ItemDatabase.GetItems(computerParts.POWERSUPPLY);
                    break;
            }

            IEnumerable<ComputerPart> items = (IEnumerable<ComputerPart>)itemsList.BindingContext;
            if (items.Count() == 0)
            {
                itemsList.IsVisible = false;
                label.IsVisible = true;
            }

            base.OnAppearing();
        }
        private async void ItemTabbedInList(object sender, ItemTappedEventArgs e)
        {
            ComputerPart computerPart = e.Item as ComputerPart;
            if (computerPart != null)
            {
                //await this.Navigation.PushAsync(new SingleItemPage(computerPart.ModelName));
                await this.Navigation.PushAsync(new SingleItemPage(computerPart));
            }
        }

        private async void Display(string message)
        {
            await this.DisplayAlert("ItemsPage", message, "OK");
        }
        private async void MenuItemSelected(object sender, EventArgs e)
        {
            //itemsList.SelectedItem;
            MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
            NavigationPage navPage = (NavigationPage)masterDetailPage.Detail;
            //NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            IndependentChoicePage independentChoicePage = navStack[navPage.Navigation.NavigationStack.Count - 2] as IndependentChoicePage;
            if (independentChoicePage != null)
            {
                ComputerPart computerPart = new ComputerPart()
                {
                    ModelName = "gugu",
                    Manufacturer = "gugugug"
                };
                //ComputerPart computerPart = itemsList.SelectedItem as ComputerPart;
                //this.Display(computerPart.Manufacturer);
                independentChoicePage.SelectedParts.Add(computerPart);
                //independentChoicePage.SelectedParts.Add(new ComputerPart { Manufacturer = "asdf", ModelName = "dfsg", Price = 111 });
            }

            //ComputerPart computerPart = itemsList.SelectedItem as ComputerPart;

            //this.DisplayAlert(computerPart.ModelName, computerPart.Price.ToString(), "OK");

            MessagingCenter.Send<Page>(this, "ItemSelected");
            await this.Navigation.PopAsync();
        }

        private void Subscribe()
        {
            testDelegateObject = Back;
            MessagingCenter.Subscribe<Page>(this, "Back", (sender) => testDelegateObject());
        }

        delegate void testDelegate();
        testDelegate testDelegateObject;

        private async void Back()
        {
            //label.Text = "Сработало!!!!!!!!!!!!!";
            await this.Navigation.PopAsync();
        }
    }
}