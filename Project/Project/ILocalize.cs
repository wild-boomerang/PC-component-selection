using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Project
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
