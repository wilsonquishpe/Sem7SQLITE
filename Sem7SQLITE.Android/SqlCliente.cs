using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sem7SQLITE.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly:Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace Sem7SQLITE.Droid
{
    public class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var databasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(databasePath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}