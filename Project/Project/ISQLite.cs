using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface ISQLite
    {
        string GetDataBasePath(string fileName);
    }
}
