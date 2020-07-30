using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.CheckoutPages.Views
{
    public class Buyer
    {
        public string address;
        public string street;
        public string house;
        public string building;
        public string entrance;
        public string floor;
        public string flat;
        public string name;
        public string surname;
        public string email;
        public string phoneNumber;
        public string comment;

        public Buyer(string address, string street, string house, string building, 
                    string entrance, string floor, string flat, string name, 
                    string surname, string email, string phoneNumber, string comment)
        {
            this.address = address;
            this.street = street;
            this.house = house;
            this.building = building;
            this.entrance = entrance;
            this.floor = floor;
            this.flat = flat;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.comment = comment;
        }
    }
    public delegate void SubmitClickedEventHandler(Buyer buyer);
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryAddressesPlugin : ContentView
    {
        public event SubmitClickedEventHandler SubmitEvent;
        public DeliveryAddressesPlugin()
        {
            InitializeComponent();
        }

        public void SubmitClicked(object o, EventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text))
            {
                address.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(street.Text))
            {
                street.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(house.Text))
            {
                house.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(entrance.Text))
            {
                entrance.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(floor.Text))
            {
                floor.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(flat.Text))
            {
                flat.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(name.Text))
            {
                name.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(surname.Text))
            {
                surname.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(email.Text))
            {
                email.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(phoneNumber.Text))
            {
                phoneNumber.PlaceholderColor = Color.Red;
                return;
            }

            Buyer buyer = new Buyer(address.Text, street.Text, house.Text, building.Text, 
                                    entrance.Text, floor.Text, flat.Text, name.Text, surname.Text, 
                                    email.Text, phoneNumber.Text, comment.Text);
            SubmitEvent?.Invoke(buyer);
        }
    }
}