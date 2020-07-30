using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project.Pages.StartPage;
using System.ComponentModel;

namespace Project.Pages
{    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndependentChoicePage : ContentPage
    {
        public string Current { get; set; }
        public List<ComputerPart> SelectedParts { get; set; }
        public List<ItemsToListView> ItemsToListView { get; set; }

        public IndependentChoicePage()
        {
            InitializeComponent();

            ItemsToListView = new List<ItemsToListView>()
            {
                new ItemsToListView {Name = "— с процессора", ImagePath = "cpu.jpg" },
                new ItemsToListView {Name = "— с оперативной памяти", ImagePath = "ram.jpg" },
                new ItemsToListView {Name = "— с видеокарты", ImagePath = "gpu.jpg" },
                new ItemsToListView {Name = "— с материнской платы", ImagePath = "motherboard.jpg" },
                new ItemsToListView {Name = "— с жёсткого диска", ImagePath = "hdd.jpg" },
                new ItemsToListView {Name = "— с корпуса", ImagePath = "mcase.jpg" },
                new ItemsToListView {Name = "— с блока питания", ImagePath = "powerSupply.jpg" },

                //new ItemsToListView {Name = Resource.IndPageListItemCPU, ImagePath = "cpu.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemRAM, ImagePath = "ram.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemGPU, ImagePath = "gpu.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemMotherboard, ImagePath = "motherboard.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemHDD, ImagePath = "hdd.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemCase, ImagePath = "mcase.jpg" },
                //new ItemsToListView {Name = Resource.IndPageListItemPowerSupply, ImagePath = "powerSupply.jpg" },
            };

            listView.BindingContext = ItemsToListView;
            Subscribe();
            SelectedParts = new List<ComputerPart>();            
        }

        protected override void OnAppearing()
        {
            foreach (var selectedComputerPart in SelectedParts)
            {
                switch (selectedComputerPart.WhoIs)
                {
                    case computerParts.CPU:
                        ItemsToListView[(int)computerParts.CPU].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.RAM:
                        ItemsToListView[(int)computerParts.RAM].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.VIDEOCARD:
                        ItemsToListView[(int)computerParts.VIDEOCARD].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.MOTHERBOARD:
                        ItemsToListView[(int)computerParts.MOTHERBOARD].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.HDD:
                        ItemsToListView[(int)computerParts.HDD].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.CASE:
                        ItemsToListView[(int)computerParts.CASE].SelectedItem = selectedComputerPart.ModelName;
                        break;
                    case computerParts.POWERSUPPLY:
                        ItemsToListView[(int)computerParts.POWERSUPPLY].SelectedItem = selectedComputerPart.ModelName;
                        break;
                }
            }

            base.OnAppearing();
        }

        private void Subscribe()
        {
            MessagingCenter.Subscribe<Page>(this, "ItemSelected", (sender) => 
            {
                label.Text = "dsf";
                //FuncMy();
                //SelectedParts.Add(PageToPush.itemsList.SelectedItem as ComputerPart);

                //listView.BackgroundColor = Color.Yellow;
                //listView.SelectedItem;

                //ImageCell imageCell = (ImageCell)listView.SelectedItem;
                //imageCell.DetailColor = Color.Blue;

                //switch (Current)
                //{
                //    case "— с процессора":

                //        break;
                //    case "— с оперативной памяти":
                //        break;
                //    case "— с видеокарты":
                //        break;
                //    case "— с материнской платы":
                //        break;
                //    case "— с жёсткого диска":
                //        break;
                //    case "— с корпуса":
                //        break;
                //    case "— с блока питания":
                //        break;
                //    default:
                //        break;
                //}

                //IEnumerator enumerator = listView.ItemsSource.GetEnumerator();
                ////IEnumerator<Page> enumerator = listView.ItemsSource.GetEnumerator();
                //while (enumerator.MoveNext())
                //{
                //    //enumerator.Current.BindingContext = item;
                //    ImageCell emageCell = (ImageCell)enumerator.Current;
                //    emageCell.TextColor = Color.Blue;
                //}
            });
        }

        private async void ItemTabbedInList(object sender, ItemTappedEventArgs e)
        {
            Current = e.Item.ToString();
            ItemsToListView item = e.Item as ItemsToListView;

            if (e.Item != null)
            {
                ItemsPage PageToPush = new ItemsPage(item.Name);
                await this.Navigation.PushAsync(PageToPush);
            }
        }

        private async void ToShopToolBarItemClicked(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart(SelectedParts);
            await this.Navigation.PushAsync(shoppingCart);
            //shoppingCart.Parts.Add(PageToPush.itemsList.SelectedItem as ComputerPart);
            //shoppingCart.Parts = SelectedParts;
        }

        private void ClearToolBarItemClicked(object sender, EventArgs e)
        {
            SelectedParts.Clear();
            foreach (var i in ItemsToListView)
            {
                i.SelectedItem = "";
                i.IsChecked = false;
            }
        }

        private async void ClearMenuItemClicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("Attention", "Menu item", "OK");
            int index = 0;
            ItemsToListView[index].SelectedItem = "";
        }

        private async void FuncMy()
        {
            await this.DisplayAlert(SelectedParts[0].ModelName, SelectedParts[0].Price.ToString(), "OK");
        }
    }

    public class ItemsToListView : INotifyPropertyChanged
    {
        private string name;
        private string imageSource;
        private string selectedItem;
        private bool isChecked = false;
        public string Name 
        {
            get { return name; } 
            set
            {
                if (name != value)
                {
                    name = value;
                    onPropertyChanged("Name");
                }
            }
        }
        public string ImagePath
        {
            get { return imageSource; }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    onPropertyChanged("ImageSource");
                }
            }
        }
        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    onPropertyChanged("SelectedItem");
                }
            }
        }

        public bool IsChecked 
        { 
            get => isChecked;
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    onPropertyChanged("IsChecked");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}