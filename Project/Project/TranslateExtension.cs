using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace Project
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInfo;
        const string ResourceId = "Project.Resource";

        public TranslateExtension()
        {
            cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId,
                        typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, cultureInfo);

            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }
    }



    //[ContentProperty("Text")]
    //public class TranslateExtension : IMarkupExtension
    //{
    //    readonly CultureInfo cultureInfo;
    //    const string ResourceId = "Project.Resource";
    //    string Text { get; set; }

    //    public TranslateExtension()
    //    {
    //        cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
    //    }

    //    public object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (Text == null)
    //            return "";

    //        ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
    //        var translation = resourceManager.GetString(Text, cultureInfo);

    //        if (translation == null)
    //            translation = Text;

    //        return translation;
    //    }
    //}
}
