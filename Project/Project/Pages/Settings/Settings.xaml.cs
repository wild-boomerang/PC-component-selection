using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Plugin.Settings;
using System.Globalization;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();

            picker.Title = Resource.SettingsPagePickerTitle;

            //if (DependencyService.Get<ILocalize>().GetCurrentCultureInfo().Name.Equals("en-US"))
            //{
            //    picker.SelectedIndex = 1;
            //}              

            //else
            //{
            //    picker.SelectedIndex = 0;
            //}


            switch (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
            {
                case "en":
                    picker.SelectedItem = "English";
                    break;
                case "ru":
                    picker.SelectedItem = "Русский";
                    break;
            }

            //string jsonStr = CrossSettings.Current.GetValueOrDefault("user_settings", "null");

            //if (jsonStr != "null")
            //{
            //    SettingsItem settingsItem = JsonConvert.DeserializeObject<SettingsItem>(jsonStr);
            //    picker.SelectedItem = settingsItem.Language;
            //}            
        }

        protected /*async*/ override void OnAppearing()
        {
            //await this.DisplayAlert("Attention", CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, "OK");

            base.OnAppearing();
        }

        private async void Test()
        {
            await this.DisplayAlert("sadf", DependencyService.Get<ILocalize>().GetCurrentCultureInfo().Name, "OK");
        }
        private async void PickerItemsIndexSelected(object sender, EventArgs e)
        {
            SettingsItem settingsItem = new SettingsItem(picker.SelectedItem.ToString());

            string jsonStr = JsonConvert.SerializeObject(settingsItem);
            CrossSettings.Current.AddOrUpdateValue("user_settings", jsonStr);

            CultureInfo.CurrentUICulture = new CultureInfo(settingsItem.Language);

            await this.DisplayAlert(Resource.SettingsPageDisplayAlertTitle, Resource.SettingsPageDisplayAlertText, 
                                    "OK");
            //await this.DisplayAlert("Attention", CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, "OK");

            //await this.DisplayAlert(picker.SelectedItem.ToString(), jsonStr, "OK");

            //DependencyService.Get<ILocalize>().GetCurrentCultureInfo() = new System.Globalization.CultureInfo("ru-Ru");
            //Test();
            //Project.ResourceLoader.Instance.SetCultureInfo(new System.Globalization.CultureInfo("en-US"));
            //await this.DisplayAlert("Pickers item was selected", picker.Items[picker.SelectedIndex], "OK");
        }
    }

    public class SettingsItem
    {
        public string Language { get; set; }
        public SettingsItem()
        {
            Language = "en";
        }
        public SettingsItem(string language)
        {
            switch (language)
            {
                case "English":
                    Language = "en";
                    break;
                case "Русский":
                    Language = "ru";
                    break;
                default:
                    Language = "en";
                    break;
            }
        }
    }
}