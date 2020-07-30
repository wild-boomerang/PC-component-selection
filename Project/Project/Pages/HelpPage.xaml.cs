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
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            WebView webView = new WebView()
            {
                Source = new UrlWebViewSource()
                {
                    Url = System.IO.Path.Combine(DependencyService.Get<IBaseUrl>().Get(), "helpMobile.mhtml")
                }
            };

            this.Content = webView;
        }
    }

    public interface IBaseUrl
    {
        string Get();
    }
}