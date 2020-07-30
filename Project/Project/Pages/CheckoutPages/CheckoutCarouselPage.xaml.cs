using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.CheckoutPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutCarouselPage : CarouselPage
    {
        Views.Buyer Buyer;
        string FullPrice;
        enum CheckoutPages
        {
            DELIV_ADDR,
            PAYMENT_METHOD,
            ORDER_CONFIRMATION
        }
        public CheckoutCarouselPage(List<ComputerPart> Parts, string fullPrice)
        {
            InitializeComponent();

            itemsList.BindingContext = Parts;
            FullPrice = fullPrice;
            this.Title = "Оформление заказа, шаг " + (1 + (int)(CheckoutPages.DELIV_ADDR)) + " из 3";
            //this.DisplayAlert("Поздравляем!", Parts.Count.ToString(), "OK");
        }

        private void UserInfoRequest(Views.Buyer buyer)
        {
            Buyer = buyer;
            this.CurrentPage = this.Children[(int)(CheckoutPages.PAYMENT_METHOD)];
            this.Title = "Оформление заказа, шаг " + (1 + (int)(CheckoutPages.PAYMENT_METHOD)) + " из 3";
            //FormattedString title = new FormattedString();
            //title.Spans.Add(new Span
            //{
            //    Text = "Оформление заказа\n",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //    FontAttributes = FontAttributes.Bold
            //});
            //title.Spans.Add(new Span
            //{
            //    Text = "шаг " + (int)CheckoutPages.PAYMENT_METHOD + " из 3",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});
            //this.Title = (string)title;
        }

        private void PaymentForward(Views.PaymentMethod paymentMethod)
        {
            if (paymentMethod == Views.PaymentMethod.NOT_SELECTED)
            {
                DisplayAlert("Не выбран способ оплаты", "Вы должны выбрать способ оплаты", "OK");
                return;
            }
            this.CurrentPage = this.Children[(int)(CheckoutPages.ORDER_CONFIRMATION)];
            this.Title = "Оформление заказа, шаг " + (1 + (int)(CheckoutPages.ORDER_CONFIRMATION)) + " из 3";



            // Настройка последней страницы
            switch (paymentMethod)
            {
                case Views.PaymentMethod.CARD_ONLINE:
                    paymentMethodLbl.BindingContext = "Картой online";
                    break;
                case Views.PaymentMethod.CARD_UPON_RECEIPT:
                    paymentMethodLbl.BindingContext = "Картой при получении";
                    break;
                case Views.PaymentMethod.CASH_UPON_RECEIPT:
                    paymentMethodLbl.BindingContext = "Наличными при получении";
                    break;
            }

            addressLbl.BindingContext = Buyer.address + ", " + Buyer.street + ", д. " +
                                        Buyer.house + ", кв. " + Buyer.flat + ", подъезд " +
                                        Buyer.building + ", э. " + Buyer.floor;
            fullNameLbl.BindingContext = Buyer.name + " " + Buyer.surname;
            emailLbl.BindingContext = Buyer.email;
            phoneNumberLbl.BindingContext = Buyer.phoneNumber;

            priceLbl.BindingContext = FullPrice;
        }

        private void PaymentBack()
        {
            this.CurrentPage = this.Children[(int)(CheckoutPages.DELIV_ADDR)];
            this.Title = "Оформление заказа, шаг " + (1 + (int)(CheckoutPages.DELIV_ADDR)) + " из 3";
        }

        private async void ItemTabbedInList(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await this.Navigation.PushAsync(new SingleItemPage(e.Item as ComputerPart));
            }
        }

        private void BackClicked(object o, EventArgs e)
        {
            this.CurrentPage = this.Children[(int)(CheckoutPages.PAYMENT_METHOD)];
            this.Title = "Оформление заказа, шаг " + (1 + (int)(CheckoutPages.PAYMENT_METHOD)) + " из 3";
        }

        private async void SendOrder(object o, EventArgs e)
        {
            await this.DisplayAlert("Поздравляем!", "Мы скоро свяжемся с Вами", "OK"); 
            await this.Navigation.PopModalAsync();
        }
    }
}