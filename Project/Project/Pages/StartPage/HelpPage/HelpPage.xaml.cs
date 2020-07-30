using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            //Xamarin.Forms.WebView webView = new Xamarin.Forms.WebView()
            //{
                //HorizontalOptions = LayoutOptions.CenterAndExpand,
                //VerticalOptions = LayoutOptions.FillAndExpand,
                
            //    Source = new UrlWebViewSource()
            //    {
            //        Url = System.IO.Path.Combine(DependencyService.Get<IBaseUrl>().Get(), "Help1.html")
            //    }

            //};

            //Xamarin.Forms.PlatformConfiguration.AndroidSpecific.WebView.SetEnableZoomControls(webView, true);
            //Xamarin.Forms.PlatformConfiguration.AndroidSpecific.WebView.SetDisplayZoomControls(webView, true);

            //this.Content = webView;

            //DisplayAlert("sdf", Convert.ToString(webView.Width), "OK");
        }
    }

    public interface IBaseUrl
    {
        string Get();
    }
}