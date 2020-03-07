using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using geographical_point.Droid;
using geographical_point.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Dependency(typeof(SQliteDroid))]
namespace geographical_point.Droid
{
    public class SQliteDroid : Isqlite
    {
        public SQliteDroid()
        {
        }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "PolygonsDatabase.db3");

            var connection = new SQLiteConnection(path);

            return connection;
        }

        #endregion
    }
}