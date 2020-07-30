using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project.Pages.StartPage.IndependentChoicePage.Children;
using Project.Pages.StartPage.IndependentChoicePage.Children.Description;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleItemPage : TabbedPage
    {
        public SingleItemPage(ComputerPart item)
        {
            InitializeComponent();

            //Test(item.WhoIs.ToString());
            //this.Title = item.ModelName;
            this.BindingContext = item;
            switch (item.WhoIs)
            {
                case computerParts.CASE:
                    this.Children.Add(new CaseDescriptionPage(item));
                    break;
                case computerParts.CPU:
                    this.Children.Add(new CPUDescriptionPage(item));
                    break;
                case computerParts.HDD:             
                    this.Children.Add(new HDDDescriptionPage(item));
                    break;
                case computerParts.MOTHERBOARD:
                    this.Children.Add(new MotherboardDescriptionPage(item));
                    break;
                case computerParts.POWERSUPPLY:
                    this.Children.Add(new PowerSupplyDescriptionPage(item));
                    break;
                case computerParts.RAM:
                    this.Children.Add(new RAMDescriptionPage(item));
                    break;
                case computerParts.VIDEOCARD:
                    this.Children.Add(new VideocardDescriptionPage(item));
                    break;
            }
            
            Shops shopsPage = new Shops(item);
            Ads adsPage = new Ads(item);
            Reviews reviewsPage = new Reviews(item);
            Comments commentsPage = new Comments(item);

            //this.Children.Add(descriptionPage);
            this.Children.Add(shopsPage);
            this.Children.Add(adsPage);
            this.Children.Add(reviewsPage);
            this.Children.Add(commentsPage);

            IEnumerator<Page> enumerator = Children.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.BindingContext = item;
            }
        }

        private async void Test(string message)
        {
            await this.DisplayAlert("SingleItemPage", message, "OK");
        }
    }
}