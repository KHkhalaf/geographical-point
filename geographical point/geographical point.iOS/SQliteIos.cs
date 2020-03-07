using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using geographical_point.iOS;
using geographical_point.Models;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteIos))]
namespace geographical_point.iOS
{
    class SQliteIos : Isqlite
    {
        public SQliteIos()
        {
        }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var dbpath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dbpath, "PolygonsDatabase.db3");
            var connection = new SQLiteConnection(path);
            return connection;

        }

        #endregion
    }
}