using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using System.IO;
using Project.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Project.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }

        public string GetDataBasePath(string fileName)
        {
            string documetsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documetsPath, fileName);

            // Копирование файла бд из папки Assets по пути path на устройство
            //if (!File.Exists(path))
            //{
                Context context = Android.App.Application.Context;
                var dbAssetStream = context.Assets.Open(fileName);

                var dbFileStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int bufLength = buffer.Length;
                int readedLength;

                while ((readedLength = dbAssetStream.Read(buffer, 0, bufLength)) > 0)
                {
                    dbFileStream.Write(buffer, 0, readedLength);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            //}

            return path;
        }
    }
}