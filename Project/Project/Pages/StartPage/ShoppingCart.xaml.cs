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
    public partial class ShoppingCart : ContentPage
    {
        //public List<ComputerPart> Parts { get; set; }
        List<ComputerPart> Parts;
        public ShoppingCart(List<ComputerPart> parts)
        {
            InitializeComponent();

            Parts = parts;
            if (Parts.Count == 0)
            {
                forEmptyLabel.IsVisible = true;
                itemsList.IsVisible = false;
                fullPricelabel.IsVisible = false;
            }

            itemsList.BindingContext = Parts;

            double fullPrice = 0;
            foreach (var i in Parts)
            {
                fullPrice += i.Price;
            }

            fullPricelabel.Text = "Итого: " + fullPrice.ToString() + " р.";
            //FuncMy();
        }

        private async void ItemTabbedInList(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await this.Navigation.PushAsync(new SingleItemPage(e.Item as ComputerPart));
            }
        }

        private async void FinishToolBarItemClicked(object sender, EventArgs e)
        {
            //bool answer = await this.DisplayAlert("Подтверждение покупки", "Вы действительно хотите приобрести выбранный товар?", "Да", "Отмена");
            //if (answer)
            //{
            //    await this.DisplayAlert("Покупка завершена", "Отличный выбор!\nПоздравляем с покупкой!\nПриходите к нам ещё!", "OK");
            //    await this.Navigation.PopToRootAsync();
            //}

            await Navigation.PushModalAsync(new NavigationPage(new Pages.CheckoutPages.CheckoutCarouselPage(Parts, fullPricelabel.Text)));
        }

        private void ClearToolBarItemClicked(object sender, EventArgs e)
        {
            itemsList.ItemsSource = null;
            forEmptyLabel.IsVisible = true;
            itemsList.IsVisible = false;
            fullPricelabel.IsVisible = false;

            MasterDetailPage masterDetailPage = Application.Current.MainPage as MasterDetailPage;
            NavigationPage navPage = masterDetailPage.Detail as NavigationPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            Project.Pages.IndependentChoicePage indChPage = navStack[navPage.Navigation.NavigationStack.Count - 2] as Project.Pages.IndependentChoicePage;
            indChPage.SelectedParts.Clear();
            foreach (var i in indChPage.ItemsToListView)
            {
                i.SelectedItem = "";
                i.IsChecked = false;
            }
        }

        //private async void FuncMy()
        //{
        //    await this.DisplayAlert(Parts[0].ModelName, Parts[0].Price.ToString(), "OK");
        //}
    }
}