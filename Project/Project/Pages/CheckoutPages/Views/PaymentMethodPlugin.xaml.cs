using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.CheckoutPages.Views
{
    public enum PaymentMethod
    {
        CARD_ONLINE,
        CARD_UPON_RECEIPT,
        CASH_UPON_RECEIPT,
        NOT_SELECTED
    }

    public delegate void SubmitEventHandler(PaymentMethod paymentMethod);
    public delegate void CancelEventHandler();
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentMethodPlugin : ContentView
    {
        public event SubmitEventHandler SubmitEvent;
        public event CancelEventHandler CancelEvent;
        public PaymentMethodPlugin()
        {
            InitializeComponent();
        }

        private void BackClicked(object o, EventArgs e)
        {
            CancelEvent?.Invoke();
        }

        private void ForwardClicked(object o, EventArgs e)
        {
            PaymentMethod selectedPaymentMethod = PaymentMethod.CARD_ONLINE;
            switch (choiceList.SelectedItem?.ToString())
            {
                case "Картой online":
                    selectedPaymentMethod = PaymentMethod.CARD_ONLINE;
                    break;
                case "Картой при получении":
                    selectedPaymentMethod = PaymentMethod.CARD_UPON_RECEIPT;
                    break;
                case "Наличными при получении":
                    selectedPaymentMethod = PaymentMethod.CASH_UPON_RECEIPT;
                    break;
            }

            if (choiceList.SelectedItem == null)
                selectedPaymentMethod = PaymentMethod.NOT_SELECTED;
            
            SubmitEvent?.Invoke(selectedPaymentMethod);
        }
    }
}