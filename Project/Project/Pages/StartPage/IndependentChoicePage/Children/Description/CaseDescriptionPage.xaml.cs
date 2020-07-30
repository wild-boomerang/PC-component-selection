using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages.StartPage.IndependentChoicePage.Children.Description
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaseDescriptionPage : ContentPage
    {
        public List<DescriptionItem> DescriptionItems;
        public CaseDescriptionPage(ComputerPart item)
        {
            InitializeComponent();

            this.BindingContext = item;
            //DescriptionItems = new List<DescriptionItem>
            //{
            //    new DescriptionItem {DescriptionName = "Тип корпуса", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Блок питания", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Материал корпуса", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Форм-фактор материнской платы", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Поддержка жидкостного охлаждения", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Прозрачное окно", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Макс. длина видеокарты", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Макс. высота процессорного кулера", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Высота", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Ширина", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Глубина", DescriptionHelp = "dfsfg"},
            //    new DescriptionItem {DescriptionName = "Вес", DescriptionHelp = "dfsfg"}
            //};
        }

        private async void ToolBarItemClicked(object sender, EventArgs e)
        {
            MasterDetailPage masterDetailPage = (MasterDetailPage)Application.Current.MainPage;
            NavigationPage navPage = (NavigationPage)masterDetailPage.Detail;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            Project.Pages.IndependentChoicePage indChoicePage = navStack[navPage.Navigation.NavigationStack.Count - 3]
                as Project.Pages.IndependentChoicePage;

            if (indChoicePage != null)
            {
                for (int i = 0; i < indChoicePage.SelectedParts.Count; i++)
                {
                    if (indChoicePage.SelectedParts[i].WhoIs == computerParts.CASE)
                    {
                        indChoicePage.SelectedParts.RemoveAt(i);
                    }
                }

                indChoicePage.ItemsToListView[(int)computerParts.CASE].IsChecked = true;
                indChoicePage.SelectedParts.Add((ComputerPart)this.BindingContext);
            }

            MessagingCenter.Send<Page>(this, "Back");
            await this.Navigation.PopAsync();
        }

        private async void HeplBtnClicked(object sender, EventArgs e)
        {
            //btn.
            await this.DisplayAlert("Характеристика", "Что она означает", "OK");
        }
    }

    public class DescriptionItem
    {
        private string descriptionName;
        private string descriptionHelp;

        public string DescriptionName { get => descriptionName; set => descriptionName = value; }
        public string DescriptionHelp { get => descriptionHelp; set => descriptionHelp = value; }
    }
}