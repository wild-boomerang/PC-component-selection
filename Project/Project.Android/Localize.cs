using System.Globalization;
using Xamarin.Forms;
[assembly: Dependency(typeof(Project.Droid.Localize))]

namespace Project.Droid
{
    class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new CultureInfo(netLanguage);
        }
    }
}